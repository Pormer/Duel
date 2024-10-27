using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IPlayerComponents
{
    private Player _player;
    public int Hp {  get; set; }

    public event Action OnDeadEvent;
    public event Action OnHitEvent;
    public void Initialize(Player player)
    {
        _player = player;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;

        if (Hp <= 0) OnDeadEvent?.Invoke();
        else OnHitEvent?.Invoke();
    }


}
