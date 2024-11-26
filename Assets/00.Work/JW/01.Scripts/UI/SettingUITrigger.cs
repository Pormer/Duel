using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingUITrigger : MonoBehaviour, KeyAction.IUIActions
{
    private bool _isSettingUI;
    private KeyAction _keyAction;

    private void Awake()
    {
        _keyAction = new KeyAction();
        _keyAction.UI.SetCallbacks(this);
        _keyAction.UI.Enable();
    }

    public void OnSetting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isSettingUI = !_isSettingUI;
            print(GameManager.Instance.OnSettingUi == null);
            GameManager.Instance.OnSettingUi?.Invoke(_isSettingUI);
        }
    }
}