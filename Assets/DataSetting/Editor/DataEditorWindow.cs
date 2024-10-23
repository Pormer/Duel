using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DataEditorWindow : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Tools/DataEditorWindow")]
    public static void ShowExample()
    {
        DataEditorWindow wnd = GetWindow<DataEditorWindow>();
        wnd.titleContent = new GUIContent("DataEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
