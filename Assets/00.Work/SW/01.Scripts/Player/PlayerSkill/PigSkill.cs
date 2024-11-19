using UnityEngine;
using UnityEngine.Events;

public class PigSkill : CharacterSkill
{
    public UnityEvent OnEat;
    protected override void AwakePlayer()
    {
        _stat.Damage = 1;
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
        OnEat.AddListener(feedbacks.PlayFeedbacks);
    }

    public override void ActiveSkill()
    {
        OnEat?.Invoke();
        _health.IsInvincibility = true;
        _health.SkillNumder = 1;
    }

    private void OnDisable()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent -= ActiveSkill;
        OnEat.RemoveListener(feedbacks.PlayFeedbacks);
    }
}
