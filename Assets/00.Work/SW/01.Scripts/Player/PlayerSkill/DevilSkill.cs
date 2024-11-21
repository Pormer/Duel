using UnityEngine;
using UnityEngine.Events;

public class DevilSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    public UnityEvent OnTransaction;
    protected override void AwakePlayer()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
        OnTransaction.AddListener(eventFeedbacks.PlayFeedbacks);
    }
    public override void ActiveSkill()
    {
        if (_stat.BarrierCount == 0) return;
        OnTransaction?.Invoke();
        _stat.BarrierCount--;
        _stat.Damage++;
        _curBulletCount = _stat.CurBulletCount - 1;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_curBulletCount == null) return;

        if  (_curBulletCount == _stat.CurBulletCount)
        {
            _curBulletCount = null;
            _stat.Damage--;
        }
    }

    private void OnDisable()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent -= ActiveSkill;
        OnTransaction.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
