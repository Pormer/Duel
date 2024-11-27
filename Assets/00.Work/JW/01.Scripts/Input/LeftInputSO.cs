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
    
    private void OnDisable()
    {
        _keyAction.LeftInput.Disable();
    }
}
