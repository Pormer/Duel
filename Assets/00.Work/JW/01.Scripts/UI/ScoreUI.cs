using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreUI : MonoBehaviour
{
    private UIDocument _uiDocument;

    [SerializeField] private VisualTreeAsset scoreAsset;
    [SerializeField] private VisualTreeAsset lastScoreAsset;

    private StatItem[][] scoreItems;
    private StatItem lastScoreItem;

    [SerializeField] private Color[] colors;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();

        scoreItems = new StatItem[2][];
        scoreItems[0] = new StatItem[4];
        scoreItems[1] = new StatItem[4];

        VisualElement root = _uiDocument.rootVisualElement;

        VisualElement rightScoreGroup = root.Q<VisualElement>("RightScoreElem");
        VisualElement leftScoreGroup = root.Q<VisualElement>("LeftScoreElem");
        VisualElement lastScoreGroup = root.Q<VisualElement>("LastScoreElem");

        rightScoreGroup.Clear();
        leftScoreGroup.Clear();
        lastScoreGroup.Clear();

        //스코어 아이템 소환
        for (int i = 0; i < 4; i++)
        {
            var tempL = scoreAsset.CloneTree();
            var itemL = tempL.Q<VisualElement>("BackgroundIcon");

            scoreItems[0][i] = new StatItem(itemL, null, colors[0]);
            leftScoreGroup.Add(tempL);

            var tempR = scoreAsset.CloneTree();
            var itemR = tempR.Q<VisualElement>("BackgroundIcon");

            scoreItems[1][i] = new StatItem(itemR, null, colors[1]);
            rightScoreGroup.Add(tempR);
        }

        var tempLs = lastScoreAsset.CloneTree();
        var itemLs = tempLs.Q<VisualElement>("BackgroundIcon");

        lastScoreItem = new StatItem(itemLs, null, Color.white);
        lastScoreGroup.Add(tempLs);
    }

    private void Start()
    {
        StartCoroutine(ScoreUpdater(GameManager.Instance.LeftScore, scoreItems[0]));
        
        print(GameManager.Instance.RightScore);
        StartCoroutine(ScoreUpdater(GameManager.Instance.RightScore, scoreItems[1]));
    }

    IEnumerator ScoreUpdater(int score, StatItem[] stats)
    {
        int curSettingScoreNum = 0;
        
        while (score > curSettingScoreNum)
        {
            yield return new WaitForSeconds(0.5f);
            
            if(curSettingScoreNum >= 4)
            {
                lastScoreItem.IsActive = true;
                yield break;
            }
            
            stats[3 - curSettingScoreNum].IsActive = true;
            
            curSettingScoreNum++;
        }
    }
}