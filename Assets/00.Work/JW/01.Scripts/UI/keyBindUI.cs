using System;
using UnityEngine;
using UnityEngine.UIElements;

public class keyBindUI : MonoBehaviour
{
    [SerializeField] private KeyAction[] keyActions;
    private UIDocument _uiDocument;
    private Button[] _buttons;
    private Label[] _labels;
    private KeyRebinder _keyRebinder;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _keyRebinder = GetComponent<KeyRebinder>();
        _buttons = new Button[keyActions.Length];
        _labels = new Label[keyActions.Length];

        //초기화()
        _buttons[0].RegisterCallback<ClickEvent>(evt =>
        {
            _labels[0].text = _keyRebinder.StartRebinding(KeyMapType.LeftInput, KeyActionType.Shoot);
        });
    }
}