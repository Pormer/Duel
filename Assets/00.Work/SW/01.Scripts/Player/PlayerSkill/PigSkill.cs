using UnityEngine;
using UnityEngine.Events;

public class PigSkill : CharacterSkill
{
    public UnityEvent OnEat;
    protected override void AwakePlayer()
    {
        _stat.Damage = 1;
        _player.InputReaderCompo.OnSkillEvent += ActiveSkill;
        OnEat.AddListener(eventFeedbacks.PlayFeedbacks);
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
        OnEat.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
