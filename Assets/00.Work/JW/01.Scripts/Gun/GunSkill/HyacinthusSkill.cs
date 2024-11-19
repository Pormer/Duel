using UnityEngine;
using UnityEngine.Events;

public class HyacinthusSkill : GunSkill
{
    public UnityEvent OnHealth;
    [SerializeField] private int wantShootCount = 5;
    private int _shootCount = 0;
    private bool _isOneCool;
    
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _gun.DamageCastCompo.OnShoot += HandleCheckShoot;
    }

    private void HandleCheckShoot(bool isTrigger)
    {
        _shootCount++;
        
        if(!_isOneCool && _shootCount >= wantShootCount)
        {
            _stat.Health++;
            OnHealth?.Invoke();
            _isOneCool = true;
        }
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        Shoot();
    }
}
