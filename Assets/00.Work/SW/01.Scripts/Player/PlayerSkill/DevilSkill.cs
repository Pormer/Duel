using UnityEngine;

public class DevilSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    protected override void AwakePlayer()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
    }
    public override void ActiveSkill()
    {
        if (_stat.barrierCount == 0) return;
        _stat.barrierCount--;
        _stat.damage++;
        _curBulletCount = _stat.CurBulletCount - 1;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_curBulletCount == null) return;

        if  (_curBulletCount == _stat.CurBulletCount)
        {
            _curBulletCount = null;
            _stat.damage--;
        }
    }
}
