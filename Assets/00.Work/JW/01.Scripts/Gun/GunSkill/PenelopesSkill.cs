using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PenelopesSkill : GunSkill
{
    public UnityEvent OnBulletDamageChanged;
    [SerializeField] private int wantBulletCount = 5;
    private int _curBulletShootCount;

    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _curBulletShootCount = 0;
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        _curBulletShootCount++;
        
        if (_curBulletShootCount >= wantBulletCount)
        {
            OnBulletDamageChanged.Invoke();
            _stat.damage *= 2;
            _curBulletShootCount = 0;
        }
        Shoot();
        _stat.damage = 1;
    }
}
