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
            if(_player.GetCompo<StatSO>().barrierCount > 0)
            {
                _player.GetCompo<StatSO>().barrierCount--;
                _player.OnHitBarrier?.Invoke();
                return;
            }
        }
        _player.GetCompo<StatSO>().hp -= damage;

        if (_player.GetCompo<StatSO>().hp <= 0) OnDeadEvent?.Invoke();
        else OnHitEvent?.Invoke();
    }


}
