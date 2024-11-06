using System.Collections;
using UnityEngine;

public class MiraSkill : CharacterSkill
{
    protected override void UpdateCharacterSkill()
    {
        if (!isSkillStart && !_health.isResurrection) _health.isResurrection = true;

        if (_stat.hp <= 0&&!isSkillStart)
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