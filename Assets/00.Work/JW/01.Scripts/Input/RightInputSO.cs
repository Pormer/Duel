using UnityEngine;

[CreateAssetMenu(menuName = "SO/Input/Right")]
public class RightInputSO : InputReaderSO, KeyAction.IRightInputActions
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _keyAction.RightInput.SetCallbacks(this);
        _keyAction.RightInput.Enable();

        IsRight = true;
    }
    
    private void OnDisable()
    {
        _keyAction.RightInput.Disable();
    }
}
