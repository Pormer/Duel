using UnityEngine;
using UnityEngine.UIElements;

public class DataUiSet : MonoBehaviour
{
    [SerializeField] private UIDocument DataUiPanel;
    private VisualElement _root;
    private void Start()
    {
        _root = DataUiPanel.rootVisualElement;
    }
}
