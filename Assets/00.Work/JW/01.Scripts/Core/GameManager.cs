using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    [field: SerializeField] public bool IsOnlinePlay { get; private set; }

    public UnityEvent<bool> OnGameWin;

    public UnityEvent<int> OnFadeIn;

    public UnityEvent OnGameStart;

    [SerializeField] private int leftScore;
    public int LeftScore
    {
        get => leftScore;
        set
        {
            if(value > 5) return;
            leftScore = value;
        }
    }

    [SerializeField] private int rightScore;
    public int RightScore
    {
        get => rightScore;
        set
        {
            if(value > 5) return;
            rightScore = value;
        }
    }
}