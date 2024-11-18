using UnityEngine;

public class NinjaSkill : CharacterSkill
{
    private int deductedBarrierCount;
    private DamageCaster _damageCaster;

    protected override void AwakePlayer()
    {
        deductedBarrierCount = _stat.BarrierCount - 1;
        _damageCaster = _player.GetComponentInChildren<DamageCaster>();
    }
    protected override void UpdateCharacterSkill()
    {
        if(deductedBarrierCount == _stat.BarrierCount)
        {
            _damageCaster.CastDamage(1);
            deductedBarrierCount = _stat.BarrierCount - 1;
        }
    }
}