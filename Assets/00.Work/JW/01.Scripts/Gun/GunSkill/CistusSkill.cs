using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class CistusSkill : GunSkill
{
    public bool IsFire { get; set; }
    [SerializeField] private CistusSkillChild childPrefab = default;
    private int _hitStack = 0;
    
    
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _player.GetCompo<Health>().OnHitEvent.AddListener(() =>
        {
            _hitStack++;
            if (_hitStack >= 2)
            {
                CistusSkillChild item;
                item = Instantiate(childPrefab);
                
                if (_player.GetCompo<InputReaderSO>().IsRight)
                {
                    item.transform.position = new Vector3(4, 0);
                }
                else
                {
                    item.transform.position = new Vector3(-3, 0);
                }
                
                item.Initialize(this);
            }
        });
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        
        if (IsFire)
        {
            _stat.Damage += _stat.Damage;
        }
        Shoot();
        _stat.Damage = 1;
    }
}
