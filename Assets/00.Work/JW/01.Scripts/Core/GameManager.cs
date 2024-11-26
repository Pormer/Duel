using System;
using DataType;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    [field: SerializeField] public bool IsOnlinePlay { get; private set; }

    public UnityEvent<bool> OnGameWin;
    public Action<bool> OnFinalWin;

    public Action<int> OnFadeIn;

    public Action OnGameStart;

    [SerializeField] private int leftScore;
    public int LeftScore
    {
        get => scoreData.leftScore;
        set
        {
            if(value > 5) return;
            leftScore = value;
            if(scoreData != null) scoreData.leftScore = value;
        }
    }

    [SerializeField] private int rightScore;
    public int RightScore
    {
        get => scoreData.rightScore;
        set
        {
            if(value > 5) return;
            rightScore = value;
            if(scoreData != null) scoreData.rightScore = value;
        }
    }

    [SerializeField] private ScoreDataSO scoreData;
    [SerializeField] SelectDataManagerSO selectDataM;

    private void Awake()
    {
        OnGameWin.AddListener(HandleScoreChange);
        var item = FindFirstObjectByType<FadeInOutUi>();
        if (item == null)
        {
            OnGameStart?.Invoke();
        }
    }

    private void HandleScoreChange(bool isRight)
    {
        if (isRight)RightScore++;
        else LeftScore++;

        selectDataM.LeftCharType = CharacterType.Default;
        selectDataM.RightCharType = CharacterType.Default;
        selectDataM.LeftGunType =  GunType.Default;
        selectDataM.RightGunType = GunType.Default;
        
        OnFadeIn?.Invoke(2);
    }
}