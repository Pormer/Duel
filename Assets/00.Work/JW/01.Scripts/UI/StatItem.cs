using UnityEngine;
using UnityEngine.UIElements;

public class StatItem
{
    private VisualElement _root;
    private VisualElement _activeElem;
    private Sprite _sprite;

    public bool IsActive
    {
        get => _activeElem.ClassListContains("active");
        set
        {
            if(value)
                _activeElem.AddToClassList("active");
            else
            {
                _activeElem.RemoveFromClassList("active");
            }
        }
    }
    
    public StatItem(VisualElement root, Sprite sprite, Color spriteColor)
    {
        _root = root;
        _activeElem = _root.Q<VisualElement>("ActiveItem");

        // 4. VisualElement의 Background 설정
        _activeElem.style.backgroundImage = new StyleBackground(sprite);
        _root.style.backgroundImage = new StyleBackground(sprite);
        
        //_activeElem.style.backgroundColor = spriteColor;
        _activeElem.style.unityBackgroundImageTintColor = spriteColor;
    }
}