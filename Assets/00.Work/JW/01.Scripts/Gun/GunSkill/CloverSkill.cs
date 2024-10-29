using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloverSkill : GunSkill
{
    public override void EnterSkill()
    {
        base.EnterSkill();
        //여기 스킬 기능 다 적기
        
        Shoot();
    }
}
