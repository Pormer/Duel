using System;
using UnityEngine;
using UnityEngine.Events;

public class BloodrootSkill : GunSkill
{
    public Action OnMinusHealth;

    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _stat.wantLoadCount = 0;
        
        _stat.IsNotBullet = true;
        
        if(eventFeedbacks != null) OnMinusHealth += eventFeedbacks.PlayFeedbacks;
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        OnMinusHealth?.Invoke();
        _stat.Health--;
        
        Shoot();
    }
}
