using ObjectPooling;
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
        if (_shootCount >= wantShootCount)
        {
            HyacinthusSkillChild item = PoolManager.Instance.Pop(PoolingType.HyacinthusChildItem) as HyacinthusSkillChild;
            
            if (_player.GetCompo<InputReaderSO>().IsRight)
            {
                item.transform.position = new Vector3(4, 0);
            }
            else
            {
                item.transform.position = new Vector3(-3, 0);
            }
            
            item.Initialize(this);
            _shootCount = 0;
        }
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        Shoot();
    }

    public void HandleActiveStat()
    {
        _stat.Health++;
        _stat.CurBulletCount++;
        OnHealth?.Invoke();
        _isOneCool = true;
    }
}
