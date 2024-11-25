using UnityEngine;
using UnityEngine.Events;

public class BeastSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    public UnityEvent OnRoaring;
    protected override void AwakePlayer()
    {
        _player.InputReaderCompo.OnSkillEvent += ActiveSkill;
        if (eventFeedbacks != null)
            OnRoaring.AddListener(eventFeedbacks.PlayFeedbacks);
    }

    public override void ActiveSkill()
    {
        if (isSkillStart) return;
        print("포효");
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
            print("능력끝");
            _stat.Damage -= 2;
        }
    }

    private void OnDisable()
    {
        _player.InputReaderCompo.OnSkillEvent -= ActiveSkill;
        OnRoaring.RemoveListener(eventFeedbacks.PlayFeedbacks);
    }
}
