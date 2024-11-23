using UnityEngine;
using UnityEngine.Events;

public class BeastSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    public UnityEvent OnRoaring;
    protected override void AwakePlayer()
    {
        _player.InputReaderCompo.OnSkillEvent += ActiveSkill;
        OnRoaring.AddListener(eventFeedbacks.PlayFeedbacks);
    }

    public override void ActiveSkill()
    {
        if (isSkillStart) return;
        isSkillStart = true;
        OnRoaring?.Invoke();
        _stat.Damage += 2;
        _curBulletCount = _stat.CurBulletCount - 2;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_curBulletCount == null) return;

        if (_curBulletCount == _stat.CurBulletCount)
        {
            _stat.Damage -= 2;
        }
    }

    private void OnDisable()
    {
        _player.InputReaderCompo.OnSkillEvent -= ActiveSkill;
        OnRoaring.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
