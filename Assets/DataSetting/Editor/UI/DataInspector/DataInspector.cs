using System;
using DataType;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Color = System.Drawing.Color;
using Object = System.Object;

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

    #region DataUI

    private VisualElement _spritePreviewElem;
    private ObjectField _spriteField;
    private EnumField _typeField;
    private SliderInt _dataPropSlider1;
    private SliderInt _dataPropSlider2;
    private SliderInt _dataPropSlider3;
    private SliderInt _dataPropSlider4;
    private FloatField _dataPropField;
    private ColorField _baseColorField;
    private TextField _explanationField;

    #endregion

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
        if (!_editorWnd.IsGunSelect) return;

        if (_curGunData == null) return;
        if (string.IsNullOrEmpty(_assetNameField.value.Trim())) return;

        string newName = _assetNameField.value;

        if (EditorUtility.DisplayDialog("데이터 변경", $"데이터 값을 정말 바꾸시겠습니까?", "Yes", "No"))
        {
            GunNameChangeEvent?.Invoke(_curGunData, newName);
        }
    }

    private void HandleCharacterDataChange()
    {
        if (_editorWnd.IsGunSelect) return;

        if (_curCharData == null) return;
        if (string.IsNullOrEmpty(_assetNameField.value.Trim())) return;

        string newName = _assetNameField.value;

        if (EditorUtility.DisplayDialog("데이터 변경", $"데이터 값을 정말 바꾸시겠습니까?", "Yes", "No"))
        {
            CharNameChangeEvent?.Invoke(_curCharData, newName);
        }
    }

    public void HandleItemViewGUI(DataItem item)
    {
        _dataSettingRootElem.Clear();

        if (_editorWnd.IsGunSelect)
        {
            if (_curGunData == null) return;

            var itemDataUI = _gunDataAsset.CloneTree();
            _dataSettingRootElem.Add(itemDataUI);
            //여기에서 세팅 값 받는 Q값 가져오고 글로벌 변수로 저장

            _spritePreviewElem = itemDataUI.Q<VisualElement>("Image");
            _spriteField = itemDataUI.Q<ObjectField>("SpriteField");
            _typeField = itemDataUI.Q<EnumField>("TypeField");
            _dataPropSlider1 = itemDataUI.Q<SliderInt>("DamageSlider");
            _dataPropSlider2 = itemDataUI.Q<SliderInt>("BulletCountSlider");
            _dataPropSlider3 = itemDataUI.Q<SliderInt>("RangeSlider");
            _dataPropSlider4 = itemDataUI.Q<SliderInt>("LoadCountSlider");
            _dataPropField = itemDataUI.Q<FloatField>("CoolTimeField");
            _explanationField = itemDataUI.Q<TextField>("ExplanationTxt");
            
            //데이터 불러오기
            _spriteField.value = item.gunItemData.itemSprite;
            _typeField.value = item.gunItemData.gunType;
            _dataPropSlider1.value = item.gunItemData.damage;
            _dataPropSlider2.value = item.gunItemData.bulletCount;
            _dataPropSlider3.value = item.gunItemData.range;
            _dataPropSlider4.value = item.gunItemData.wantLoadCount;
            _dataPropField.value = item.gunItemData.coolTime;
            _explanationField.value = item.gunItemData.explanation;
        }
        else
        {
            if (_curCharData == null) return;

            var itemDataUI = _characterDataAsset.CloneTree();
            _dataSettingRootElem.Add(itemDataUI);
            //여기에서 세팅 값 받는 Q값 가져오고 글로벌 변수로 저장

            _spritePreviewElem = itemDataUI.Q<VisualElement>("Image");
            _spriteField = itemDataUI.Q<ObjectField>("SpriteField");
            _typeField = itemDataUI.Q<EnumField>("TypeField");
            _dataPropSlider1 = itemDataUI.Q<SliderInt>("HPSlider");
            _dataPropSlider2 = itemDataUI.Q<SliderInt>("BarrierSlider");
            _baseColorField = itemDataUI.Q<ColorField>("BaseColorField");
            _explanationField = itemDataUI.Q<TextField>("ExplanationTxt");
            
            //데이터 불러오기
            _spriteField.value = item.charItemData.itemSprite;
            _typeField.value = item.charItemData.charType;
            _dataPropSlider1.value = item.charItemData.hp;
            _dataPropSlider2.value = item.charItemData.barrierCount;
            _baseColorField.value = item.charItemData.baseColor;
            _explanationField.value = item.charItemData.explanation;
        }
        
        _spriteField.RegisterCallback<ChangeEvent<UnityEngine.Object>>(HandleChangeSprite);
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

    public void GunDataSave(GunDataSO data)
    {
        data.itemSprite = _spriteField.value as Sprite;
        data.gunType = (GunType)_typeField.value;
        data.damage = _dataPropSlider1.value;
        data.bulletCount = _dataPropSlider2.value;
        data.range = _dataPropSlider3.value;
        data.wantLoadCount = _dataPropSlider4.value;
        data.coolTime = _dataPropField.value;
        data.explanation = _explanationField.value;
    }

    public void CharDataSave(CharacterDataSO data)
    {
        data.itemSprite = _spriteField.value as Sprite;
        data.charType = (CharacterType)_typeField.value;
        data.hp = _dataPropSlider1.value;
        data.barrierCount = _dataPropSlider2.value;
        data.baseColor = _baseColorField.value;
        data.explanation = _explanationField.value;
    }
    
    private void HandleChangeSprite(ChangeEvent<UnityEngine.Object> evt)
    {
        StyleBackground texture;
        if (_curCharData?.itemSprite != null)
        {
            texture = new StyleBackground(
                AssetPreview.GetAssetPreview(evt.newValue));
            _spritePreviewElem.style.backgroundImage = texture;
        }
        else if(_curGunData?.itemSprite != null)
        {
            texture = new StyleBackground(
                AssetPreview.GetAssetPreview(evt.newValue));
            _spritePreviewElem.style.backgroundImage = texture;
        }
    }
}