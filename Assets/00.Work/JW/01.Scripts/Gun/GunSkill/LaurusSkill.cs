using UnityEngine;
using UnityEngine.Events;

public class LaurusSkill : GunSkill
{
    public UnityEvent OnFormChanged;
    
    [SerializeField] private int curStep;
    [SerializeField] private int wantStep = 7;
    [SerializeField] private int wantDamage = 3;
    protected override void AwakeSkill()
    {
        base.AwakeSkill();
        _player.GetCompo<PlayerMovement>().OnMove += () => curStep++;
    }

    public override void EnterSkill()
    {
        base.EnterSkill();
        if (curStep > wantStep)
        {
            OnFormChanged?.Invoke();
            _player.StatDataCompo.damage = wantDamage;
            curStep = 0;
        }
        Shoot();
        _player.StatDataCompo.damage = 1;
    }
}
