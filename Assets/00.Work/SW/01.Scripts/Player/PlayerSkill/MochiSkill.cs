using UnityEngine;

public class MochiSkill : CharacterSkill
{
    protected override void AwakePlayer()
    {
        _health.IsInvincibility = true;
    }
    protected override void UpdateCharacterSkill()
    {
        if (_health.IsInvincibilityHit >= 3)
        {
            _health.IsInvincibility = false;
        }
    }
}
