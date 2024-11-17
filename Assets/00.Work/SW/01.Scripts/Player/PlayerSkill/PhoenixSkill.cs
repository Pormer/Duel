using UnityEngine;

public class PhoenixSkill : CharacterSkill
{
    protected override void AwakePlayer()
    {
        _health.isResurrection = true;
    }
    protected override void UpdateCharacterSkill()
    {
        if (_stat.Health <= 0)
        {
            _health.isResurrection = false;
            _stat.Health = 1;
        }
    }
}
