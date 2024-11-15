using UnityEngine;

public class BeastSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    protected override void AwakePlayer()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
    }

    public override void ActiveSkill()
    {
        if (isSkillStart) return;
        isSkillStart = true;
        print("��ȿ!!");
        _stat.damage += 2;
        _curBulletCount = _stat.CurBulletCount - 2;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_curBulletCount == null) return;

        if (_curBulletCount == _stat.CurBulletCount)
        {
            _stat.damage -= 2;
        }
    }
}
