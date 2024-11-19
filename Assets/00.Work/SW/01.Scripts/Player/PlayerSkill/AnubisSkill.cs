using UnityEngine;
using UnityEngine.Events;

public class AnubisSkill : CharacterSkill
{
    public UnityEvent OnDamageUp;
    protected override void AwakePlayer()
    {
        OnDamageUp.AddListener(feedbacks.PlayFeedbacks);
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
        OnDamageUp.RemoveListener(feedbacks.PlayFeedbacks);
    }
}
