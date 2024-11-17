using System;
using UnityEngine;
using UnityEngine.Events;

public class CallicarpaSkill : GunSkill
{
    public UnityEvent OnFormChange;
    [SerializeField] private int wantMaxBulletCount = 4;
    private int curShootBulletCount;
    
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        curShootBulletCount = 0;
    }

    public override void EnterSkill()
    {
        base.EnterSkill();

        curShootBulletCount++;
        
        if (!_isFormChange && curShootBulletCount >= wantMaxBulletCount)
        {
            _stat.maxBulletCount = wantMaxBulletCount;
            _stat.CurBulletCount = wantMaxBulletCount;
            _isFormChange = true;
            OnFormChange?.Invoke();
        }
        
        Shoot();
    }
}
