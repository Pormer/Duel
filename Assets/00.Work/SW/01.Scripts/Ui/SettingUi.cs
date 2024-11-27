using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SettingUi : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;
    private VisualElement penel;
    private Slider[] sliders = new Slider[2];
    private VisualElement _keys;
    private VisualElement[] _KeyPenel = new VisualElement[2];
    private VisualElement[] _leftKeys = new VisualElement[7];
    private VisualElement[] _rightKeys = new VisualElement[7];
    private Label[] _leftLabel = new Label[7];
    private Label[] _rightLabel = new Label[7];
    private Button[] buttons = new Button[2];

    private SettingUITrigger _settingUITrigger;
    private bool _start;

    private void Awake()
    {
        GameManager.Instance.OnSettingUi = null;
        _uiDocument = GetComponent<UIDocument>();
        _root = _uiDocument.rootVisualElement;
        penel = _root.Q<VisualElement>("Penel");
        sliders[0] = penel.Q<Slider>("SFXSettingSlider");
        sliders[1] = penel.Q<Slider>("BGMSettingSlider");
        _keys = penel.Q<VisualElement>("Keys");
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

        buttons[0] = penel.Q<Button>("Exit");
        buttons[1] = penel.Q<Button>("Title");

        buttons[0].RegisterCallback<ClickEvent>((v) => Application.Quit());
        buttons[1].RegisterCallback<ClickEvent>((v) =>
        {
            GameManager.Instance.OnFadeIn?.Invoke(0);
            SettingOn(false);
        });
        GameManager.Instance.OnSettingUi += SettingOn;
        _settingUITrigger = GetComponent<SettingUITrigger>();
    }



    public void SettingOn(bool isOpen)
    {
        if(_start == false)
        {
            _start = true;
        }
        if (isOpen && _settingUITrigger.IsPenel)
        {
            StartCoroutine(DownSettingOnTime(100));
        }
        else if(!isOpen && _settingUITrigger.IsPenel)
        {
            penel.RemoveFromClassList("IsMove");
            StartCoroutine(UpSettingOnTime(-1));
        }
        print(isOpen);
    }

    private IEnumerator UpSettingOnTime(int valur)
    {
        yield return new WaitForSeconds(0.5f);
        _uiDocument.sortingOrder = valur;
        _settingUITrigger.IsPenel = false;
    }

    private IEnumerator DownSettingOnTime(int valur)
    {
        _uiDocument.sortingOrder = valur;
        yield return null;
        penel.ToggleInClassList("IsMove");
        yield return new WaitForSeconds(0.5f);
        _settingUITrigger.IsPenel = false;
    }
    private void OnDestroy()
    {
    }

}
