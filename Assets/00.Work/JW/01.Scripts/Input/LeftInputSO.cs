using UnityEngine;

[CreateAssetMenu(menuName = "SO/Input/Left")]
public class LeftInputSO : InputReaderSO, KeyAction.ILeftInputActions
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _keyAction.LeftInput.SetCallbacks(this);
        
        IsRight = false;
    }
}
