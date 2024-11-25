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
        
        IsRight = false;
    }
    
    private void OnDisable()
    {
        _keyAction.LeftInput.Disable();
    }
}
