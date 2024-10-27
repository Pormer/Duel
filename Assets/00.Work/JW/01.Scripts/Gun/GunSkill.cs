using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunSkill : MonoBehaviour
{
    private Gun _gun;
    
    public void Initialize(Player player)
    {
        _gun = player.GetCompo<Gun>();
        
    }

    public virtual void EnterSkill()
    {
        _gun.DamageCastCompo.CastDamage(_gun.gunData.damage);
    }

    protected virtual void UpdateGunState()
    {
        
    }
}
