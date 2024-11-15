using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloverSkill : GunSkill
{
    [SerializeField] 
    public override void EnterSkill()
    {
        base.EnterSkill();
        //여기 스킬 기능 다 적기
        _stat.damage = RandomDamage();
        Shoot();
    }

    private int RandomDamage()
    {
        int rand = Random.Range(0, 10);
        return rand > 4 ? 1 : rand;
    }
}
