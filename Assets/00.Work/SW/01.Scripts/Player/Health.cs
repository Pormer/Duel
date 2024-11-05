using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;

public class Health : MonoBehaviour, IPlayerComponents
{
    public UnityEvent OnDeadEvent;
    public UnityEvent OnHitEvent;
    
    private Player _player;
    private StatSO _stat;
    public bool IsInvincibility {  get; set; }
    private float invincibilityTime = 1f;

    public bool isResurrection { get; set; }

    public void Initialize(Player player)
    {
        _player = player;
        _stat = _player.GetCompo<StatSO>();
    }

    public void TakeDamage(int damage)
    {
        if (IsInvincibility)
        {
            print("¹«Àû¤»");
            return;
        }

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

        if (_stat.hp <= 0 && !isResurrection) OnDeadEvent?.Invoke();
        else
        {
            OnHitEvent?.Invoke();
            IsInvincibility = true;
            _player.SpriteRenderer.DOFade(0.6f, 0.2f);
            StartCoroutine(PlayerInvincibilityStart(invincibilityTime));
        }
    }


    private IEnumerator PlayerInvincibilityStart(float Time)
    {
        yield return new WaitForSeconds(Time);
        IsInvincibility = false;
        _player.SpriteRenderer.DOFade(1f, 0.2f);
    }
}
