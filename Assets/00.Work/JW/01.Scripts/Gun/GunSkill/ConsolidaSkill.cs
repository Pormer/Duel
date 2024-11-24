using UnityEngine;

public class ConsolidaSkill : GunSkill
{
    private int _hitCount = 0;
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _gun.DamageCastCompo.OnShoot += HandleOnShoot;
    }

    private void HandleOnShoot(bool isTrigger)
    {
        if (isTrigger)
        {
            if (_hitCount >= 3)
            {
                _stat.CoolTime = 0.3f;
                _stat.wantLoadCount = 1;
            }
            _hitCount++;
        }
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        Shoot();
    }
}