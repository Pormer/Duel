using System.Collections;
using UnityEngine;

public class MiraSkill : CharacterSkill
{
    protected override void AwakePlayer()
    {
        _health.isResurrection = true;
    }

    protected override void UpdateCharacterSkill()
    {
        if (_stat.Health <= 0 &&!isSkillStart)
        {
            isSkillStart = true;
            MireSkillStart();
        }
    }

    private void MireSkillStart()
    {
        print("�̶��� ���ֽ���");
        _stat.damage++;
        _stat.cooltime--;
        StartCoroutine(DieTime());
    }

    private IEnumerator DieTime()
    {
        yield return new WaitForSeconds(5f);
        print("��");
        _health.OnDeadEvent?.Invoke();
    }

}
