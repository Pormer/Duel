using System;
using UnityEngine;
using UnityEngine.UIElements;

public class keyBindUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;
    private VisualElement _keys;
    private VisualElement[] _playrs = new VisualElement[2];  
    private Button[] _leftButtons = new Button[7];
    private Button[] _rightButtons = new Button[7];
    private KeyRebinder _keyRebinder;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _keyRebinder = new KeyRebinder();
        _root = _uiDocument.rootVisualElement;
        _keys = _root.Q<VisualElement>("Keys");
        _playrs[0] = _keys.Q<VisualElement>("LeftPlayer");
        _playrs[1] = _keys.Q<VisualElement>("RightPlayer");

        ButtonsSetting(ref _leftButtons, 0);
        ButtonsSetting(ref _rightButtons, 1);

        //초기화()
        KeyRebinder(ref _leftButtons, 0);
        KeyRebinder(ref _rightButtons, 1);
    }

    private void ButtonsSetting(ref Button[] buttons,int valur)
    {
        buttons[0] = _playrs[valur].Q<Button>("Up");
        buttons[1] = _playrs[valur].Q<Button>("Down");
        buttons[2] = _playrs[valur].Q<Button>("Left");
        buttons[3] = _playrs[valur].Q<Button>("Right");
        buttons[4] = _playrs[valur].Q<Button>("Shoot");
        buttons[5] = _playrs[valur].Q<Button>("Barrier");
        buttons[6] = _playrs[valur].Q<Button>("Skill");
    }

    private void KeyRebinder(ref Button[] buttons, int valur)
    {
        buttons[0].RegisterCallback<ClickEvent>(evt => _leftButtons[0].text = _keyRebinder.StartRebinding((KeyMapType)valur, KeyActionType.MovementUp));
        buttons[1].RegisterCallback<ClickEvent>(evt => _leftButtons[1].text = _keyRebinder.StartRebinding((KeyMapType)valur, KeyActionType.MovementDown));
        buttons[2].RegisterCallback<ClickEvent>(evt => _leftButtons[2].text = _keyRebinder.StartRebinding((KeyMapType)valur, KeyActionType.MovementLeft));
        buttons[3].RegisterCallback<ClickEvent>(evt => _leftButtons[3].text = _keyRebinder.StartRebinding((KeyMapType)valur, KeyActionType.MovementRight));
        buttons[4].RegisterCallback<ClickEvent>(evt => _leftButtons[4].text = _keyRebinder.StartRebinding((KeyMapType)valur, KeyActionType.Shoot));
        buttons[5].RegisterCallback<ClickEvent>(evt => _leftButtons[5].text = _keyRebinder.StartRebinding((KeyMapType)valur, KeyActionType.Barrier));
        buttons[6].RegisterCallback<ClickEvent>(evt => _leftButtons[6].text = _keyRebinder.StartRebinding((KeyMapType)valur, KeyActionType.Skill));
    }

}