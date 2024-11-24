using UnityEngine;
using UnityEngine.Events;

public class BloodrootSkill : GunSkill
{
    public UnityEvent OnMinusHealth;

    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _stat.wantLoadCount = 0;
        
        if(eventFeedbacks == null) return;
        _stat.IsNotBullet = true;
        
        OnMinusHealth.AddListener(eventFeedbacks.PlayFeedbacks);

    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        OnMinusHealth?.Invoke();
        _stat.Health--;
        
        Shoot();
    }
}
