using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PhoenixSkill : CharacterSkill
{
    public UnityEvent OnResurrection;
    protected override void AwakePlayer()
    {
        _health.isResurrection = true;
        if (eventFeedbacks != null)
            OnResurrection.AddListener(eventFeedbacks.PlayFeedbacks);
    }
    protected override void UpdateCharacterSkill()
    {
        if (_stat.Health <= 0)
        {
            OnResurrection?.Invoke();
            _health.isResurrection = false;
            StartCoroutine(SkillStart());
        }
    }

    private IEnumerator SkillStart()
    {
        yield return new WaitForSeconds(0.5f);
        _stat.Health = 1;
    }

    private void OnDisable()
    {
        OnResurrection.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
