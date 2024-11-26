using UnityEngine;
using UnityEngine.UIElements;

public class LobbyUi : MonoBehaviour
{
    private UIDocument _uIDocument;
    private VisualElement _root;
    private Button[] _buttons = new Button[2];

    private void Awake()
    {
        _uIDocument = GetComponent<UIDocument>();
        _root = _uIDocument.rootVisualElement;
        _buttons[0] = _root.Q<Button>("Play");
        _buttons[1] = _root.Q<Button>("Title");
        _buttons[0].RegisterCallback<ClickEvent>((v) => SceneMove(2));
        _buttons[1].RegisterCallback<ClickEvent>((v) => SceneMove(0));
    }

    private void SceneMove(int value)
    {
        print(value);
        GameManager.Instance.OnFadeIn(value);
    }
}
