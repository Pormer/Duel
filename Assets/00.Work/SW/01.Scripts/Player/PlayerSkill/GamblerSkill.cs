using System;
using UnityEngine;
using UnityEngine.Events;

public class GamblerSkill : CharacterSkill
{
    public Action OnGamb;
    protected override void AwakePlayer()
    {
        if (eventFeedbacks != null)
            OnGamb -= eventFeedbacks.PlayFeedbacks;
        OnGamb?.Invoke();
        int hp = UnityEngine.Random.Range(1, 1000);
        int barrier = UnityEngine.Random.Range(1, 1000);
        Probability(hp, true);
        Probability(barrier, false);
    }

    private void Probability(int number, bool ishp)
    {
        if (number >= 0 && number <= 100)
        {
            if (ishp) _stat.Health = UnityEngine.Random.Range(1, 2);
            else _stat.maxBarrierCount = 1;
        }
        else if (number >= 101 && number <= 600)
        {
            if (ishp) _stat.Health = UnityEngine.Random.Range(3, 4);
            else _stat.maxBarrierCount = 2;
        }
        else if (number >= 601 && number <= 800)
        {
            if (ishp) _stat.Health = UnityEngine.Random.Range(5, 6);
            else _stat.maxBarrierCount = 3;
        }
        else if(number >= 801 && number <= 999)
        {
            if (ishp) _stat.Health = 7;
            else _stat.maxBarrierCount = 4;
        }
        else
        {
            if (ishp) _stat.Health = 8;
            else _stat.maxBarrierCount = 5;
        }
        print($"{_stat.Health} , {_stat.maxBarrierCount}");
    }
    private void OnDisable()
    {if (eventFeedbacks != null)
        OnGamb -= eventFeedbacks.PlayFeedbacks;
    }

}
