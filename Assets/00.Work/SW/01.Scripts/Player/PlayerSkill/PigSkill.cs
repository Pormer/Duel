using UnityEngine;

public class PigSkill : CharacterSkill
{
    protected override void AwakePlayer()
    {
        _stat.damage = 1;
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
    }

    public override void ActiveSkill()
    {
        _health.IsInvincibility = true;
        _health.isHpRecovery = true;
    }
}
