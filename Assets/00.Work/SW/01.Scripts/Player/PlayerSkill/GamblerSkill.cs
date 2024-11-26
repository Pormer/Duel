using System;
using UnityEngine;
using UnityEngine.Events;

public class GamblerSkill : CharacterSkill
{
    public Action OnGamb;
    protected override void AwakePlayer()
    {
        _health.OnHitEvent.AddListener(HitAvoidance);
        _player.OnHitBarrier += HitAvoidance;
    }

    private void HitAvoidance()
    {
        OnGamb?.Invoke();
        if(RandomDamage())
        {
            print("���ڼ���");
            _stat.BarrierCount++;
            return;
        }
        print("���ڽ���");
    }

    private bool RandomDamage()
    {
        int rand = UnityEngine.Random.Range(0, 10);
        return rand <= 2 ? true : false;
    }

    private void OnDisable()
    {
        OnGamb -= eventFeedbacks.PlayFeedbacks;
    }

}
