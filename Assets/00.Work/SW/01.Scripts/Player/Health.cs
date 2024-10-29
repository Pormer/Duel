using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IPlayerComponents
{
    private Player _player;

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
            if(_player.Stat.barrierCount > 0)
            {
                _player.Stat.barrierCount--;
                _player.OnHitBarrier?.Invoke();
                return;
            }
        }
        _player.Stat.hp -= damage;

        if (_player.Stat.hp <= 0) OnDeadEvent?.Invoke();
        else OnHitEvent?.Invoke();
    }


}
