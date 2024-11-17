using UnityEngine;

public class PrunusSkill : GunSkill
{
    [SerializeField] private int wantHitCount = 3;
    private int targetHitCount;
    
    private bool isShootGun;
    private bool isHitTarget;

    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        this.targetHitCount = 0;
        
    }

    public override void EnterSkill()
    {
        base.EnterSkill();

        if (targetHitCount > wantHitCount)
        {
            
        }        
        Shoot();
    }
}
