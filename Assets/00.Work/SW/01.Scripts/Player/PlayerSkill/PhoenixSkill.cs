using UnityEngine;
using UnityEngine.Events;

public class PhoenixSkill : CharacterSkill
{
    public UnityEvent OnResurrection;
    protected override void AwakePlayer()
    {
        _health.isResurrection = true;
        OnResurrection.AddListener(feedbacks.PlayFeedbacks);
    }
    protected override void UpdateCharacterSkill()
    {
        if (_stat.Health <= 0)
        {
            OnResurrection?.Invoke();
            _health.isResurrection = false;
            _stat.Health = 1;
        }
    }

    private void OnDisable()
    {
        OnResurrection.RemoveListener(feedbacks.PlayFeedbacks);
    }
}
