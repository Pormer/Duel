using System;
using UnityEngine;
using UnityEngine.Events;

public class DemeterSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    private DamageCaster _damageCaster;
    public Action OnHpRecovery;
    protected override void AwakePlayer()
    {
        _player.InputReaderCompo.OnSkillEvent += ActiveSkill;
        _damageCaster = _player.GetComponentInChildren<DamageCaster>();
        OnHpRecovery += eventFeedbacks.PlayFeedbacks;
    }

    public override void ActiveSkill()
    {
        _stat.Damage = 0;
        _curBulletCount = _stat.CurBulletCount - 1;
        OnHpRecovery?.Invoke();
        _damageCaster.OnShoot += HpRecovery;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_stat.CurBulletCount == _curBulletCount)
            _damageCaster.OnShoot -= HpRecovery;
    }

    private void HpRecovery(bool isTrigger)
    {
        _stat.Health++;
        _damageCaster.OnShoot -= HpRecovery;
    }

    private void OnDisable()
    {
        _player.InputReaderCompo.OnSkillEvent -= ActiveSkill;
        OnHpRecovery -= eventFeedbacks.PlayFeedbacks;
    }
}
