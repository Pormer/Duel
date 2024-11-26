using UnityEngine;

[CreateAssetMenu(menuName = "SO/Input/Left")]
public class LeftInputSO : InputReaderSO, KeyAction.ILeftInputActions
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _keyAction.LeftInput.SetCallbacks(this);
        _keyAction.LeftInput.Enable();
        GameManager.Instance.OnGameWin.AddListener(v => _keyAction.LeftInput.Disable());
        GameManager.Instance.OnFadeIn += v => _keyAction.LeftInput.Disable();
        GameManager.Instance.OnSettingUi += HandleSetting;
        
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
        _keyAction.LeftInput.Disable();
    }
}
