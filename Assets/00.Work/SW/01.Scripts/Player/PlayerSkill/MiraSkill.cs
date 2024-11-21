using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MiraSkill : CharacterSkill
{
    public UnityEvent OnCurse;
    protected override void AwakePlayer()
    {
        _health.isResurrection = true;
        OnCurse.AddListener(eventFeedbacks.PlayFeedbacks);
    }

    protected override void UpdateCharacterSkill()
    {
        if (_stat.Health <= 0 &&!isSkillStart)
        {
            isSkillStart = true;
            MireSkillStart();
        }
    }

    private void MireSkillStart()
    {
        print("????? ???????");
        _stat.Damage++;
        _stat.CoolTime--;
        StartCoroutine(DieTime());
    }

    private IEnumerator DieTime()
    {
        yield return new WaitForSeconds(5f);
        print("??");
        _health.OnDeadEvent?.Invoke();
    }

    private void OnDisable()
    {
        OnCurse.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }

}
