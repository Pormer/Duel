using UnityEngine;
using UnityEngine.Events;

public class DelphiniumSkill : GunSkill
{
    public UnityEvent OnFormChanged;
    [SerializeField] private float wantTimer = 15;
    private float currentTimer = 0;
    private int _changeDamage = 5;
    private int _tempDamage;
    private bool _isTimeOut;

    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _tempDamage = _stat.Damage;
        OnFormChanged.AddListener(eventFeedbacks.PlayFeedbacks);
        _player.GetCompo<Health>().OnHitEvent.AddListener(() => currentTimer = 0);
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        if(_isTimeOut)
        {
            _stat.Damage = _changeDamage;
            _isTimeOut = false;
        }
        Shoot();
        _stat.Damage = 1;
    }

    protected override void UpdateGunState()
    {
        base.UpdateGunState();

        currentTimer += Time.deltaTime;
        
        if (currentTimer >= wantTimer)
        {
            OnFormChanged?.Invoke();
            _isTimeOut = true;
            currentTimer = 0;
        }
    }
}
