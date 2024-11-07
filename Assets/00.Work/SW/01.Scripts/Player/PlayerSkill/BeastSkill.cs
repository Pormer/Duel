using UnityEngine;

public class BeastSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    public override void ActiveSkill()
    {
        base.ActiveSkill();
        print("Æ÷È¿!!");
        _stat.damage += 2;
        _curBulletCount = _stat.curBulletCount - 2;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_curBulletCount == null) return;

        if (_curBulletCount == _stat.curBulletCount)
        {
            _stat.damage -= 2;
        }
    }
}
