using System;
using UnityEngine;
using UnityEngine.Events;

public class DianthusSkill : GunSkill
{
    public UnityEvent OnDamageUp;
    
    private int _stackCount = 0;
    [SerializeField] private int maxStackCount = 3;
    private bool _isHit = false;

    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _stackCount = 0;

        _gun.DamageCastCompo.OnShoot += HandleShootTrigger;
        _player.GetCompo<Health>().OnHitEvent.AddListener(() => _isHit = true);
    }

    private void HandleShootTrigger(bool isTrigger)
    {
        if (!_isHit) return;
        
        if (isTrigger)
        {
            _isHit = false;
            _stat.Damage = 1;
        }
        else
        {
            _stat.Damage = 1 + Mathf.Clamp(_stat.Damage + 1, 0, maxStackCount + 1);
            OnDamageUp?.Invoke();
        }
    }


    public override void EnterSkill()
    {
        base.EnterSkill();
        
        Shoot();
    }

    private void OnDestroy()
    {
        _gun.DamageCastCompo.OnShoot -= HandleShootTrigger;
    }
}