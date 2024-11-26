using UnityEngine;

[CreateAssetMenu(menuName = "SO/Input/Right")]
public class RightInputSO : InputReaderSO, KeyAction.IRightInputActions
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _keyAction.RightInput.SetCallbacks(this);
        _keyAction.RightInput.Enable();
        GameManager.Instance.OnGameWin.AddListener(v => _keyAction.RightInput.Disable());
        GameManager.Instance.OnFadeIn += v => _keyAction.RightInput.Disable();
        GameManager.Instance.OnSettingUi += HandleSetting;

        IsRight = true;
    }
    
    private void HandleSetting(bool obj)
    {
        Debug.Log("in");
        if (obj)
        {
            _keyAction.RightInput.Disable();
        }
        else
        {
            _keyAction.RightInput.Enable();
        }
    }
    
    private void OnDisable()
    {
        GameManager.Instance.OnSettingUi -= HandleSetting;
        _keyAction.RightInput.Disable();
    }
}
