using System;
using UnityEngine;
using UnityEngine.Events;

public class BeastSkill : CharacterSkill
{
    private int? _curBulletCount = null;
    public Action OnRoaring;
    protected override void AwakePlayer()
    {
        if (eventFeedbacks != null)
            OnRoaring += eventFeedbacks.PlayFeedbacks;
    }

    public override void ActiveSkill()
    {
        if (isSkillStart) return;
        print("��ȿ");
        isSkillStart = true;
        OnRoaring?.Invoke();
        _stat.Damage += 2;
        _curBulletCount = _stat.CurBulletCount - 2;
        base.ActiveSkill();
    }

    protected override void UpdateCharacterSkill()
    {
        if (_curBulletCount == null) return;

        if (_curBulletCount == _stat.CurBulletCount)
        {
            print("�ɷ³�");
            _stat.Damage -= 2;
        }
    }

    private void OnDisable()
    {
        _player.InputReaderCompo.OnSkillEvent -= ActiveSkill;
        OnRoaring -= eventFeedbacks.PlayFeedbacks;
    }
}
