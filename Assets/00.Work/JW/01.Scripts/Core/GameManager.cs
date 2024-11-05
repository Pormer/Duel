using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    [field: SerializeField] public bool IsOnlinePlay { get; private set; }

    public Action OnAddPlayer;

    public UnityEvent OnGameStart;
}
