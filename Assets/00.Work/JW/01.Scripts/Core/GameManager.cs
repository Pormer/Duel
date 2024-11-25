using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    [field: SerializeField] public bool IsOnlinePlay { get; private set; }

    public UnityEvent<bool> OnGameWin;
    public event Action<bool> OnFinelWin;

    public Action<int> OnFadeIn;

    public UnityEvent OnGameStart;

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

    private void Awake()
    {
        OnGameWin.AddListener(HandleScoreChange);
    }

    private void HandleScoreChange(bool isRight)
    {
        if (isRight)RightScore++;
        else LeftScore++;
        OnFadeIn?.Invoke(2);
    }
}