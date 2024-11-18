using System;
using UnityEngine;
using UnityEngine.Events;

public class HydrengeaSkill : GunSkill
{
    public UnityEvent OnBarrierChanged;
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _gun.DamageCastCompo.OnShoot += HandleOnShoot;
    }
    
    public override void EnterSkill()
    {
        base.EnterSkill();
        Shoot();
    }

    private void HandleOnShoot(bool isTrigger)
    {
        _stat.BarrierCount++;
        OnBarrierChanged?.Invoke();
    }

    private void OnDestroy()
    {
        _gun.DamageCastCompo.OnShoot -= HandleOnShoot;
    }
}
