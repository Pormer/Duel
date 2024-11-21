using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MedusaSkill : CharacterSkill
{
    public UnityEvent OnPetrification;
    protected override void AwakePlayer()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
        OnPetrification.AddListener(eventFeedbacks.PlayFeedbacks);
    }
    public override void ActiveSkill()
    {
        _health.SkillNumder = 2;
    }

    private IEnumerator SkillTime()
    {
        yield return new WaitForSeconds(2f);
        _health.SkillNumder = 0;
    }

    private void OnDisable()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent -= ActiveSkill;
        OnPetrification.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
