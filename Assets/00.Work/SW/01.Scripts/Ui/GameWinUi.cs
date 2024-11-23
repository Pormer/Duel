using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameWinUi : MonoBehaviour
{
    [SerializeField] private UIDocument gameMinPanel;
    private VisualElement _root;
    private VisualElement[] _visual = new VisualElement[4];
    private Label _playerName;
    [SerializeField] private List<Sprite> crownSprites;

    private void Awake()
    {
        _root = gameMinPanel.rootVisualElement;
        _visual[0] = _root.Q<VisualElement>("UpPanel");
        _visual[1] = _root.Q<VisualElement>("DownPanel");
        _visual[2] = _root.Q<VisualElement>("Character");
        _visual[3] = _root.Q<VisualElement>("Crown");
        _playerName = _root.Q<Label>("PlayerName");
    }

    public void WinPanelStart(bool player)
    {
        if (player)
        {
            _visual[2].style.backgroundImage = new StyleBackground(crownSprites[0]);
            _playerName.text = "LeftPlayerWin";
        }
        else
        {
            _visual[2].style.backgroundImage = new StyleBackground(crownSprites[1]);
            _playerName.text = "RightPlayerWin";
        }
        StartCoroutine(WinPanelStart());
    }

    private IEnumerator WinPanelStart()
    {
        _visual[0].ToggleInClassList("UpMove");
        yield return new WaitForSeconds(0.3f);
        _visual[1].ToggleInClassList("DownMove");
        yield return new WaitForSeconds(0.5f);
        _visual[2].ToggleInClassList("IsMove");
        yield return new WaitForSeconds(1);
        _visual[3].ToggleInClassList("IsMove");
        yield return new WaitForSeconds(0.8f);
        _playerName.ToggleInClassList("IsMove");
    }
}
