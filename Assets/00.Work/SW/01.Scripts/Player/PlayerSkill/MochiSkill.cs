using UnityEngine;
using UnityEngine.Events;

public class MochiSkill : CharacterSkill
{
    public UnityEvent OnHit; 
    protected override void AwakePlayer()
    {
        if(eventFeedbacks != null)
            OnHit.AddListener(eventFeedbacks.PlayFeedbacks);
        _health.IsInvincibility = true;
    }
    protected override void UpdateCharacterSkill()
    {

        if (_health.IsInvincibilityHit >= 3 && _health.IsInvincibility)
        {
            _health.IsInvincibility = false;
            OnHit?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    private void OnDisable()
    {
        OnHit.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
