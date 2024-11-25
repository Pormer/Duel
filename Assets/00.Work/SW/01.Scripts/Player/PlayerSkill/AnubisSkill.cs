using System;
using UnityEngine;
using UnityEngine.Events;

public class AnubisSkill : CharacterSkill
{
    public Action OnDamageUp;
    protected override void AwakePlayer()
    {
        OnDamageUp += eventFeedbacks.PlayFeedbacks;
    }
    protected override void UpdateCharacterSkill()
    {
        if (_stat.Health == 1 && !isSkillStart)
        {
            isSkillStart = true;
            OnDamageUp?.Invoke();
            _stat.Damage++;
        }
    }

    private void OnDisable()
    {
        OnDamageUp -= eventFeedbacks.PlayFeedbacks;
    }
}
