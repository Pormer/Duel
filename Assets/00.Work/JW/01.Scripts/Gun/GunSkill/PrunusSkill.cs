using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrunusSkill : GunSkill
{
    [SerializeField] private int wantHitCount = 3;
    private int targetHitCount;
    
    private bool[] hitCombos;
    private int currentComboNum;

    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        targetHitCount = 0;
        hitCombos = new bool[wantHitCount];
        _gun.DamageCastCompo.OnShoot += HandleHitEvent;
    }

    private void HandleHitEvent(bool isTrigger)
    {
        hitCombos[currentComboNum] = isTrigger;
        
        if(!isTrigger)
        {
            hitCombos.ToList().ForEach(i => i = false);
            currentComboNum = 0;
        }

        currentComboNum++;
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        if (hitCombos.All(item => true))
        {
            _stat.damage = 1000000000;
        }
        
        Shoot();
        _stat.damage = 0;
    }
}
