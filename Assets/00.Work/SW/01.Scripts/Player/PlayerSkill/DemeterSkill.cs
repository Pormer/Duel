using UnityEngine;
using UnityEngine.Events;

public class DemeterSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    private DamageCaster _damageCaster;
    public UnityEvent OnHpRecovery;
    protected override void AwakePlayer()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
        _damageCaster = _player.GetComponentInChildren<DamageCaster>();
        OnHpRecovery.AddListener(eventFeedbacks.PlayFeedbacks);
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
        _player.GetCompo<InputReaderSO>().OnSkillEvent -= ActiveSkill;
        OnHpRecovery.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
