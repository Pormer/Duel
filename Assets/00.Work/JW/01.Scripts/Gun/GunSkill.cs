using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GunSkill : MonoBehaviour
{
    protected FeedbackPlayer eventFeedbacks;
    private static readonly int DoShoot = Animator.StringToHash("doShoot");
    protected Player _player;
    protected Gun _gun;
    protected StatData _stat;
    protected bool _isFormChange;

    protected bool isCoolTime = false;
    
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
        _gun.OnShoot?.Invoke();
        
        _gun.AnimCompo.SetTrigger(DoShoot);
        _gun.DamageCastCompo.CastDamage(_stat.Damage);
        _stat.CurBulletCount--;
        
        isCoolTime = true;
        StartCoroutine(CoolDown());
    }

    public void EnterShoot()
    {
        if(isCoolTime || !_stat.IsCanShoot || _player.GetCompo<PlayerMovement>().IsMove) return;
        EnterSkill();
    }

    public virtual void EnterSkill()
    {
        //여기에 변경사항 모두 한 후 Shoot()실행
        
    }

    protected virtual void UpdateGunState()
    {
        
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_stat.CoolTime);
        isCoolTime = false;
    }
}
