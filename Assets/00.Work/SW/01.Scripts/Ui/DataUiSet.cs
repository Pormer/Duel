using UnityEngine;
using UnityEngine.UIElements;

public class DataUiSet : MonoBehaviour
{
    [SerializeField] private UIDocument DataUiPanel;
    private VisualElement _root;
    private VisualElement[] _playerData = new VisualElement[2];
    private VisualElement[] _visualImages = new VisualElement[2];
    private Label[] leftPlayerLabel = new Label[4];
    private Label[] rightPlayerLabel = new Label[4];
    private void Start()
    {
        _root = DataUiPanel.rootVisualElement;
        _playerData[0] = _root.Q<VisualElement>("LeftPlayerData");
        _playerData[1] = _root.Q<VisualElement>("RightPlayerData");
        _visualImages[0] = _playerData[0].Q<VisualElement>("VisualImage");
        _visualImages[0] = _playerData[1].Q<VisualElement>("VisualImage");
        LabelSet(ref leftPlayerLabel,0);
        LabelSet(ref rightPlayerLabel,1);
    }

    private void LabelSet(ref Label[] labels, int number)
    {
        labels[0] = _playerData[number].Q<Label>("Hp");
        labels[1] = _playerData[number].Q<Label>("Barrier");
        labels[2] = _playerData[number].Q<Label>("Description");
        labels[3] = _playerData[number].Q<Label>("Name");
    }

    public void UiSet(CharacterDataSO characterData, bool isLeft)
    {
        if (isLeft)
        {
            leftPlayerLabel[0].text = characterData.hp.ToString();
            leftPlayerLabel[1].text = characterData.barrierCount.ToString();
            leftPlayerLabel[2].text = characterData.explanation;
            leftPlayerLabel[3].text = characterData.name;
        }
        else
        {
            rightPlayerLabel[0].text = characterData.hp.ToString();
            rightPlayerLabel[1].text = characterData.barrierCount.ToString();
            rightPlayerLabel[2].text = characterData.explanation;
            rightPlayerLabel[3].text = characterData.name;
        }
    }
}
