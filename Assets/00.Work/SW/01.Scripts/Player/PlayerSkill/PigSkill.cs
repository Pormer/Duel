using System;
using UnityEngine;
using UnityEngine.Events;

public class PigSkill : CharacterSkill
{
    public Action OnEat;
    protected override void AwakePlayer()
    {
        OnEat += eventFeedbacks.PlayFeedbacks;
        _stat.Damage = 1;
        _player.InputReaderCompo.OnSkillEvent += ActiveSkill;
        
    }

    public override void ActiveSkill()
    {
        OnEat?.Invoke();
        _health.IsInvincibility = true;
        _health.SkillNumder = 1;
    }

    private void OnDisable()
    {
        _player.InputReaderCompo.OnSkillEvent -= ActiveSkill;
        OnEat -= eventFeedbacks.PlayFeedbacks;
    }
}
