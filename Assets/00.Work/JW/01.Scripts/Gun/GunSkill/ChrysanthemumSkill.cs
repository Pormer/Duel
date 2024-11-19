using UnityEngine;
using UnityEngine.Events;

public class ChrysanthemumSkill : GunSkill
{
    public UnityEvent OnHit;
    
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _player.GetCompo<Health>().OnHitEvent.AddListener(() =>
        {
            _stat.Damage--;
            OnHit?.Invoke();
        });
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        Shoot();
    }
}