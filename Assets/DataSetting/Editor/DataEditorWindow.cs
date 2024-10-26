using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class DataEditorWindow : EditorWindow
{
    [SerializeField] private VisualTreeAsset m_VisualTreeAsset;

    private Button _createBtn;
    private Button _charSelectBtn;
    private Button _gunSelectBtn;

    private ScrollView _itemView;

    [SerializeField] private VisualTreeAsset _dataItemUXMLAsset;
    [SerializeField] private ToolInfoSO _toolInfo;

    [FormerlySerializedAs("datManager")] [SerializeField]
    private DataManagerSO dataManager;

    private List<DataItem> _dataItems = new();
    private DataItem _currentItem;
    
    private DataInspector _inspector;

    public bool IsGunSelect { get; set; }

    [MenuItem("Tools/DataEditorWindow")]
    public static void ShowExample()
    {
        DataEditorWindow wnd = GetWindow<DataEditorWindow>();
        wnd.titleContent = new GUIContent("DataEditorWindow");
        wnd.minSize = new Vector2(600, 450);
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        VisualElement content = m_VisualTreeAsset.Instantiate();
        content.style.flexGrow = 1;
        root.Add(content);

        InitializeItem(content);
        GenerateDataItemUI();
    }

    private void GenerateDataItemUI()
    {
        _itemView.Clear();
        _dataItems.Clear();
        _inspector.ClearInspector();

        if (IsGunSelect)
        {
            foreach (var item in dataManager.gunDatas)
            {
                var itemUIAsset = _dataItemUXMLAsset.CloneTree();
                DataItem dataItem = new DataItem(itemUIAsset, item);
                _itemView.Add(itemUIAsset);
                _dataItems.Add(dataItem);

                dataItem.Name = item.name;
                dataItem.OnSelectEvent += HandleSelectItem;
                dataItem.OnDeleteEvent += HandleDeleteItem;
            }
        }
        else
        {
            foreach (var item in dataManager.characterDatas)
            {
                var itemUIAsset = _dataItemUXMLAsset.CloneTree();
                DataItem dataItem = new DataItem(itemUIAsset, item);
                _itemView.Add(itemUIAsset);
                _dataItems.Add(dataItem);

                
                dataItem.Name = item.name.Replace("Data", "");
                dataItem.OnSelectEvent += HandleSelectItem;
                dataItem.OnDeleteEvent += HandleDeleteItem;
            }
        }
    }

    private void HandleDeleteItem(DataItem item)
    {
        if (IsGunSelect)
        {
            dataManager.gunDatas.Remove(item.gunItemData);
            AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(item.gunItemData));
        }
        else
        {
            dataManager.characterDatas.Remove(item.charItemData);
            AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(item.charItemData));
        }

        EditorUtility.SetDirty(dataManager);

        AssetDatabase.SaveAssets();

        if (_currentItem == item)
        {
            _currentItem = null;
            //나중에 인스펙터에 추가
        }

        GenerateDataItemUI();
    }

    private void HandleSelectItem(DataItem item)
    {
        _dataItems.ForEach(i => i.IsActive = false);
        item.IsActive = true;
        _currentItem = item;
        
        if(IsGunSelect) _inspector.UpdateInspector(_currentItem.gunItemData);
        else
        {
            _inspector.UpdateInspector(_currentItem.charItemData);
        }
    }
    
    private void InitializeItem(VisualElement content)
    {
        _createBtn = content.Q<Button>("CreateBtn");
        _charSelectBtn = content.Q<Button>("CharacterSelectBtn");
        _gunSelectBtn = content.Q<Button>("GunSelectBtn");
        
        _itemView = content.Q<ScrollView>("ItemScrollView");
        
        _itemView.Clear();

        _inspector = new DataInspector(content, this);
        
        _inspector.GunNameChangeEvent += HandleGunAssetNameChange;
        _inspector.CharNameChangeEvent += HandleCharacterAssetNameChange;
        
        IsGunSelect = false;
        GenerateDataItemUI();

        _charSelectBtn.clicked += () =>
        {
            IsGunSelect = false;
            GenerateDataItemUI();
        };
        _gunSelectBtn.clicked += () =>
        {
            IsGunSelect = true;
            GenerateDataItemUI();
        };
        
        _createBtn.clicked += HandleGunCreateItem;
        _createBtn.clicked += HandleCharacterCreateItem;
    }

    private void HandleCharacterCreateItem()
    {
        if(IsGunSelect) return;
        
        Guid typeGuid = Guid.NewGuid();
        
        CharacterDataSO itemSO = ScriptableObject.CreateInstance<CharacterDataSO>();

        itemSO.itemName = typeGuid.ToString();
        
        string itemFileName = $"{itemSO.itemName}Data.asset";
        string itemFillPath = $"{_toolInfo.dataSettingFolder}/{_toolInfo.charFolder}";
        
        CreateFolderIfNotExist(itemFillPath);

        AssetDatabase.CreateAsset(itemSO, $"{itemFillPath}/{itemFileName}");
        dataManager.characterDatas.Add(itemSO);
        
        EditorUtility.SetDirty(dataManager);
        AssetDatabase.SaveAssets();
        
        GenerateDataItemUI();
    }
    
    private void HandleGunCreateItem()
    {
        if(!IsGunSelect) return;
        
        Guid typeGuid = Guid.NewGuid();
        
        GunDataSO itemSO = ScriptableObject.CreateInstance<GunDataSO>();
        
        itemSO.itemName = typeGuid.ToString();
        
        string itemFileName = $"{itemSO.itemName}Data.asset";
        string itemFillPath = $"{_toolInfo.dataSettingFolder}/{_toolInfo.gunFolder}";
        
        CreateFolderIfNotExist(itemFillPath);

        AssetDatabase.CreateAsset(itemSO, $"{itemFillPath}/{itemFileName}");
        dataManager.gunDatas.Add(itemSO);
        
        EditorUtility.SetDirty(dataManager);
        AssetDatabase.SaveAssets();
        
        GenerateDataItemUI();
    }
    
    private void HandleCharacterAssetNameChange(CharacterDataSO data, string newName)
    {
        if(IsGunSelect) return;
        
        string itemPath = AssetDatabase.GetAssetPath(data);
        
        AssetDatabase.RenameAsset(itemPath, $"{newName}Data");
        
        data.itemName = newName;
        EditorUtility.SetDirty(data);
        AssetDatabase.SaveAssets();
        
        GenerateDataItemUI();
    }
    
    private void HandleGunAssetNameChange(GunDataSO data, string newName)
    {
        if(!IsGunSelect) return;
        
        string itemPath = AssetDatabase.GetAssetPath(data);
        
        AssetDatabase.RenameAsset(itemPath, $"{newName}Data");
        
        data.itemName = newName;
        EditorUtility.SetDirty(data);
        AssetDatabase.SaveAssets();
        
        GenerateDataItemUI();
    }
    
    private void CreateFolderIfNotExist(string fullPath)
    {
        if (!System.IO.Directory.Exists(fullPath))
        {
            System.IO.Directory.CreateDirectory(fullPath);
        }
    }
    
    private void OnDestroy()
    {
        _inspector.Dispose();
    }
}