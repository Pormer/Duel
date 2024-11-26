using UnityEngine;
using UnityEngine.UIElements;

public class SettingUi : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;
    private Slider[] sliders = new Slider[2];
    private VisualElement _keys;
    private VisualElement[] _KeyPenel = new VisualElement[2];
    private VisualElement[] _leftKeys = new VisualElement[7];
    private VisualElement[] _rightKeys = new VisualElement[7];
    private Label[] _leftLabel = new Label[7];
    private Label[] _rightLabel = new Label[7];
    private Button[] buttons = new Button[3];

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _root = _uiDocument.rootVisualElement;
        sliders[0] = _root.Q<Slider>("SFXSettingSlider");
        sliders[1] = _root.Q<Slider>("BGMSettingSlider");
        _keys = _root.Q<VisualElement>("Keys");
        _KeyPenel[0] = _keys.Q<VisualElement>("LeftPlayer");
        _KeyPenel[1] = _keys.Q<VisualElement>("RightPlayer");
        _leftKeys[0] = _KeyPenel[0].Q<VisualElement>("W");
        _leftKeys[1] = _KeyPenel[0].Q<VisualElement>("S");
        _leftKeys[2] = _KeyPenel[0].Q<VisualElement>("A");
        _leftKeys[3] = _KeyPenel[0].Q<VisualElement>("D");
        _leftKeys[4] = _KeyPenel[0].Q<VisualElement>("C");
        _leftKeys[5] = _KeyPenel[0].Q<VisualElement>("V");
        _leftKeys[6] = _KeyPenel[0].Q<VisualElement>("B");

        _rightKeys[0] = _KeyPenel[1].Q<VisualElement>("Up");
        _rightKeys[1] = _KeyPenel[1].Q<VisualElement>("Down");
        _rightKeys[2] = _KeyPenel[1].Q<VisualElement>("Left");
        _rightKeys[3] = _KeyPenel[1].Q<VisualElement>("Right");
        _rightKeys[4] = _KeyPenel[1].Q<VisualElement>("L");
        _rightKeys[5] = _KeyPenel[1].Q<VisualElement>("1");
        _rightKeys[6] = _KeyPenel[1].Q<VisualElement>("K");

        for (int i = 0; i < _leftKeys.Length; i++) _leftLabel[i] = _leftKeys[i].Q<Label>();
        for(int i = 0; i < _rightKeys.Length; i++) _rightLabel[i] = _rightKeys[i].Q<Label>();

        buttons[0] = _root.Q<Button>("Exit");
        buttons[1] = _root.Q<Button>("Title");
        buttons[2] = _root.Q<Button>("Reset");

        buttons[0].RegisterCallback<ClickEvent>((v) => Application.Quit());
        buttons[1].RegisterCallback<ClickEvent>((v) =>
        {
            GameManager.Instance.OnFadeIn?.Invoke(0);
            SettingOn(false);
        });
        //buttons[2].RegisterCallback<ClickEvent>((v) => {
    }



    public void SettingOn(bool isOpen)
    {
        if (isOpen) _uiDocument.sortingOrder = 100;
        else _uiDocument.sortingOrder = -50;
    }
}
