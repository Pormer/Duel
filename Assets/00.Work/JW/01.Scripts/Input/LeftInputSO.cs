using UnityEngine;

[CreateAssetMenu(menuName = "SO/Input/Left")]
public class LeftInputSO : InputReaderSO, KeyAction.ILeftInputActions
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _keyAction.LeftInput.SetCallbacks(this);
        _keyAction.LeftInput.Enable();
        
        IsRight = false;
    }
    
    private void HandleSetting(bool obj)
    {
        Debug.Log("in");
        if (obj)
        {
            _keyAction.LeftInput.Disable();
        }
        else
        {
            _keyAction.LeftInput.Enable();
        }
    }
    private void OnDisable()
    {
        GameManager.Instance.OnSettingUi -= HandleSetting;
        _keyAction.LeftInput.Disable();
    }
}
