using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameWinUi : MonoBehaviour
{
    [SerializeField] private UIDocument gameMinPanel;
    private VisualElement _root;
    private VisualElement[] _visual = new VisualElement[4];
    private 

    private void Awake()
    {
        _root = gameMinPanel.rootVisualElement;
        _visual[0] = _root.Q<VisualElement>("UpPanel");
        _visual[1] = _root.Q<VisualElement>("DownPanel");
        _visual[2] = _root.Q<VisualElement>("Character");
        _visual[3] = _root.Q<VisualElement>("Crown");
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
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
    }
}
