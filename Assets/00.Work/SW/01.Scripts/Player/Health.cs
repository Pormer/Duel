using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IPlayerComponents
{
    private Player _player;
    private StatSO stat;

    public event Action OnDeadEvent;
    public event Action OnHitEvent;
    public void Initialize(Player player)
    {
        _player = player;

    }

    public void TakeDamage(int damage)
    {
        if (_player.IsOnBarrier)
        {
            if(stat.barrierCount > 0)
            {
                stat.barrierCount--;
                _player.OnHitBarrier?.Invoke();
                return;
            }
        }
        stat.hp -= damage;

        if (stat.hp <= 0) OnDeadEvent?.Invoke();
        else OnHitEvent?.Invoke();
    }


}
