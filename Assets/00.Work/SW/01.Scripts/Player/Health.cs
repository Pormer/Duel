using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IPlayerComponents
{
    public UnityEvent OnDeadEvent;
    public UnityEvent OnHitEvent;
    
    private Player _player;
    private StatSO _stat;
    
    
    public void Initialize(Player player)
    {
        _player = player;
        _stat = _player.GetCompo<StatSO>();
    }

    public void TakeDamage(int damage)
    {
        if (_player.IsOnBarrier)
        {
            if(_stat.barrierCount > 0)
            {
                _stat.barrierCount--;
                _player.OnHitBarrier?.Invoke();
                return;
            }
        }
        _stat.hp -= damage;

        if (_stat.hp <= 0) OnDeadEvent?.Invoke();
        else OnHitEvent?.Invoke();
    }
}
