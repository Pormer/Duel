using UnityEngine;

[CreateAssetMenu(menuName = "SO/Input/Right")]
public class RightInputSO : InputReaderSO, KeyAction.IRightInputActions
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _keyAction.RightInput.SetCallbacks(this);
        
        IsRight = true;
    }
}
