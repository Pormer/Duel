using UnityEngine;

public class CallicarpaSkill : GunSkill
{
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        
        
        Shoot();
    }
}
