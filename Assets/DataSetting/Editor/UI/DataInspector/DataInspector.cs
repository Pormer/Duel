using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DataInspector : IDisposable
{
    private TextField _assetNameField;
    private Button _nameChangeBtn;

    private VisualTreeAsset _characterDataAsset;
    private VisualTreeAsset _gunDataAsset;
    private VisualElement _dataSettingRootElem;
    
    private DataEditorWindow _editorWnd;

    private CharacterDataSO _curCharData;
    private GunDataSO _curGunData;
    
    #region DataNameChangeEvent
    public delegate void GunDataNameChangeDelegate(GunDataSO target, string newNameData);
    public event GunDataNameChangeDelegate GunNameChangeEvent;
    
    public delegate void CharacterDataNameChangeDelegate(CharacterDataSO target, string newNameData);
    public event CharacterDataNameChangeDelegate CharNameChangeEvent;
    
    #endregion
    
    public DataInspector(VisualElement content, DataEditorWindow editorWnd)
    {
        _editorWnd = editorWnd;

        _gunDataAsset = editorWnd.GunDataUxmlAsset;
        _characterDataAsset = editorWnd.CharacterDataUxmlAsset;
        
        _assetNameField = content.Q<TextField>("NameField");
        _nameChangeBtn = content.Q<Button>("ChangeBtn");
        _dataSettingRootElem = editorWnd.DataSettingRootElem;
        
        //_itemView.onGUIHandler += HandleItemViewGUI;

        _nameChangeBtn.clicked += HandleGunDataChange;
        _nameChangeBtn.clicked += HandleCharacterDataChange;
    }
    
    private void HandleGunDataChange()
    {
        if(!_editorWnd.IsGunSelect) return;
        
        if(_curGunData == null) return;
        if (string.IsNullOrEmpty(_assetNameField.value.Trim())) return;
        
        string newName = _assetNameField.value;

        if (EditorUtility.DisplayDialog("이름 변경", $"이름을 정말 바꾸시겠습니까?", "Yes", "No"))
        {
            GunNameChangeEvent?.Invoke(_curGunData, newName);
        }
    }
    
    private void HandleCharacterDataChange()
    {
        if(_editorWnd.IsGunSelect) return;
        
        if(_curCharData == null) return;
        if (string.IsNullOrEmpty(_assetNameField.value.Trim())) return;
        
        string newName = _assetNameField.value;

        if (EditorUtility.DisplayDialog("이름 변경", $"이름을 정말 바꾸시겠습니까?", "Yes", "No"))
        {
            CharNameChangeEvent?.Invoke(_curCharData, newName);
        }
    }

    public void HandleItemViewGUI(DataItem item)
    {
        _dataSettingRootElem.Clear();
        
        if(_editorWnd.IsGunSelect)
        {
            if(_curGunData == null) return;
            
            var itemDataUI = _gunDataAsset.CloneTree();
            _dataSettingRootElem.Add(itemDataUI);
            //여기에서 세팅 값 받는 Q값 가져오고 글로벌 변수로 저장
        }
        else
        {
            if(_curCharData == null) return;
            
            var itemDataUI = _characterDataAsset.CloneTree();
            _dataSettingRootElem.Add(itemDataUI);
            //여기에서 세팅 값 받는 Q값 가져오고 글로벌 변수로 저장
        }
    }
    
    public void UpdateInspector(GunDataSO item)
    {
        _assetNameField.SetValueWithoutNotify(item.itemName);
        _curGunData = item;
    }
    
    public void UpdateInspector(CharacterDataSO item)
    {
        _assetNameField.SetValueWithoutNotify(item.itemName);
        _curCharData = item;
    }
    
    public void ClearInspector()
    {
        _assetNameField.SetValueWithoutNotify(string.Empty);
        _curCharData = null;
        _curGunData = null;
    }
    
    public void Dispose()
    {
        /*UnityEngine.Object.DestroyImmediate(_typeEditor);
        UnityEngine.Object.DestroyImmediate(_itemEditor);*/
    }
}
