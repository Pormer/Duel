using UnityEngine;

public class DemeterSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    private DamageCaster _damageCaster;
    protected override void AwakePlayer()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
        _damageCaster = _player.GetComponentInChildren<DamageCaster>();
    }

    public override void ActiveSkill()
    {
        _stat.damage = 0;
        _curBulletCount = _stat.curBulletCount - 1;
        _damageCaster.OnHitTarget += HpRecovery;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_stat.curBulletCount == _curBulletCount)
            _damageCaster.OnHitTarget -= HpRecovery;
    }

    private void HpRecovery()
    {
        _stat.hp++;
        _damageCaster.OnHitTarget -= HpRecovery;
    }
}
