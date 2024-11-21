using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GunSkill : MonoBehaviour
{
    [SerializeField] protected FeedbackPlayer eventFeedbacks;
    private static readonly int DoShoot = Animator.StringToHash("doShoot");
    protected Player _player;
    protected Gun _gun;
    protected StatData _stat;
    protected bool _isFormChange;

    protected bool isCoolTimeOut;
    
    public void Initialize(Gun gun, Player player)
    {
        _gun = gun;
        _stat = player.StatDataCompo;
        _player = player;
        
        if (_player.GunData.eventFeedback != null) eventFeedbacks = Instantiate(_player.GunData.eventFeedback, transform);


        AwakeSkill();
    }

    protected virtual void AwakeSkill()
    {
        
    }

    protected void Shoot()
    {
        _gun.AnimCompo.SetTrigger(DoShoot);
        _gun.DamageCastCompo.CastDamage(_stat.Damage);
        _stat.CurBulletCount--;
        isCoolTimeOut = false;
        StartCoroutine(CoolDown());
    }

    public virtual void EnterSkill()
    {
        //여기에 변경사항 모두 한 후 Shoot()실행
        if(!isCoolTimeOut || !_stat.IsCanShoot || _player.GetCompo<PlayerMovement>().IsMove) return;
        
    }

    protected virtual void UpdateGunState()
    {
        
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_stat.cooltime);
        isCoolTimeOut = true;
    }
}
