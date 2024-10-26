using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DataInspector : MonoBehaviour
{
    private TextField _assetNameField;
    private Button _nameChangeBtn;

    private VisualElement _characterDataElem;
    private VisualElement _gunDataElem;
    
    private DataEditorWindow _editorWnd;

    private CharacterDataSO _curCharData;
    private GunDataSO _curGunData;
    
    public delegate void GunDataNameChangeDelegate(GunDataSO target, string newNameData);
    public event GunDataNameChangeDelegate GunNameChangeEvent;
    
    public delegate void CharacterDataNameChangeDelegate(CharacterDataSO target, string newNameData);
    public event CharacterDataNameChangeDelegate CharNameChangeEvent;
    
    public DataInspector(VisualElement content, DataEditorWindow editorWnd)
    {
        _editorWnd = editorWnd;
        
        _assetNameField = content.Q<TextField>("NameField");
        _nameChangeBtn = content.Q<Button>("ChangeBtn");
        
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

    private void HandleItemViewGUI()
    {
        VisualElement itemView;
        if(_editorWnd.IsGunSelect) itemView = new VisualElement();
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
