using UnityEngine;
using UnityEngine.UIElements;

public class CharacterDataUiSet : MonoBehaviour
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
        _visualImages[1] = _playerData[1].Q<VisualElement>("VisualImage");
        LabelSet(ref leftPlayerLabel,0);
        LabelSet(ref rightPlayerLabel,1);
    }

    private void LabelSet(ref Label[] labels, int number)
    {
        labels[0] = _playerData[number].Q<Label>("Name");
        labels[1] = _playerData[number].Q<Label>("Hp");
        labels[2] = _playerData[number].Q<Label>("Barrier");
        labels[3] = _playerData[number].Q<Label>("Description");
    }

    public void UiSet(CharacterDataSO characterData, bool isLeft)
    {
        if (isLeft)
        {
            _visualImages[0].style.backgroundImage = new StyleBackground(characterData.itemSprite);
            leftPlayerLabel[0].text = $"Name : {characterData.itemName}";
            leftPlayerLabel[1].text = $"Hp : {characterData.hp.ToString()}";
            leftPlayerLabel[2].text = $"Barrier : {characterData.barrierCount.ToString()}";
            leftPlayerLabel[3].text = characterData.explanation;
        }
        else
        {
            _visualImages[1].style.backgroundImage = new StyleBackground(characterData.itemSprite);
            rightPlayerLabel[0].text = $"Name : {characterData.itemName}";
            rightPlayerLabel[1].text = $"Hp : {characterData.hp.ToString()}";
            rightPlayerLabel[2].text = $"Barrier : {characterData.barrierCount.ToString()}";
            rightPlayerLabel[3].text = characterData.explanation;
        }
    }
}
