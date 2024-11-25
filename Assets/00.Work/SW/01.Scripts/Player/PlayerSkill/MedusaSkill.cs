using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MedusaSkill : CharacterSkill
{
    public UnityEvent OnPetrification;
    protected override void AwakePlayer()
    {
        _player.InputReaderCompo.OnSkillEvent += ActiveSkill;
        if (eventFeedbacks != null)
            OnPetrification.AddListener(eventFeedbacks.PlayFeedbacks);
    }
    public override void ActiveSkill()
    {
        OnPetrification?.Invoke();
        _player.Barrier.GetComponent<SpriteRenderer>().color = new Color(Color.gray.r,Color.gray.g,Color.gray.b,0.85f);
        _health.SkillNumder = 2;
        StartCoroutine(SkillTime());
    }

    private IEnumerator SkillTime()
    {
        yield return new WaitForSeconds(2f);
        _player.Barrier.GetComponent<SpriteRenderer>().color = _player.BarrierColer;
        _health.SkillNumder = 0;
    }

    private void OnDisable()
    {
        _player.InputReaderCompo.OnSkillEvent -= ActiveSkill;
        OnPetrification.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
