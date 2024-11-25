using UnityEngine;
using UnityEngine.Events;

public class NinjaSkill : CharacterSkill
{
    private int deductedBarrierCount;
    private DamageCaster _damageCaster;
    public UnityEvent OnReflex;

    protected override void AwakePlayer()
    {
        OnReflex.AddListener(eventFeedbacks.PlayFeedbacks);
        deductedBarrierCount = _stat.BarrierCount - 1;
        _damageCaster = _player.GetComponentInChildren<DamageCaster>();
    }
    protected override void UpdateCharacterSkill()
    {
        if(deductedBarrierCount == _stat.BarrierCount)
        {
            _damageCaster.CastDamage(1);
            OnReflex?.Invoke();
            deductedBarrierCount = _stat.BarrierCount - 1;
        }
    }

    private void OnDisable()
    {
        OnReflex.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
