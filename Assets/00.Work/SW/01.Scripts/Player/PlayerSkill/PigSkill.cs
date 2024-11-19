using UnityEngine;

public class PigSkill : CharacterSkill
{
    protected override void AwakePlayer()
    {
        _stat.Damage = 1;
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
    }

    public override void ActiveSkill()
    {

        _health.IsInvincibility = true;
        _health.SkillNumder = 1;
    }
}
