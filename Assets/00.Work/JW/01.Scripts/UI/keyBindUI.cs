using System;
using UnityEngine;
using UnityEngine.UIElements;

public class keyBindUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private Button[] _buttons;
    private Label[] _labels;
    private KeyRebinder _keyRebinder;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _keyRebinder = new KeyRebinder();
        _buttons = new Button[0];
        _labels = new Label[0];

        //초기화()
        _buttons[0].RegisterCallback<ClickEvent>(evt =>
        {
            _labels[0].text = _keyRebinder.StartRebinding(KeyMapType.LeftInput, KeyActionType.Shoot);
        });
    }
}