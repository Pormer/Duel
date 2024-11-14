using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunSkill : MonoBehaviour
{
    private static readonly int DoShoot = Animator.StringToHash("doShoot");
    protected Gun _gun;
    protected StatData _stat;

    protected bool isActiveShoot;
    
    public void Initialize(Gun gun, Player player)
    {
        _gun = gun;
        _stat = player.GetCompo<StatData>();
    }

    protected virtual void Shoot()
    {
        _gun.AnimCompo.SetTrigger(DoShoot);
        _gun.DamageCastCompo.CastDamage(_stat.damage);
        
        isActiveShoot = false;
        StartCoroutine(CoolDown());
    }

    public virtual void EnterSkill()
    {
        //여기에 변경사항 모두 한 후 Shoot()실행
        if(!isActiveShoot) return;
        
    }

    protected virtual void UpdateGunState()
    {
        
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_stat.cooltime);
        isActiveShoot = true;
    }
}
