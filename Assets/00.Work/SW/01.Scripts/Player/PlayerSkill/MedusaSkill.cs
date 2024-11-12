using System.Collections;
using UnityEngine;

public class MedusaSkill : CharacterSkill
{
    protected override void AwakePlayer()
    {
        _player.GetCompo<InputReaderSO>().OnSkillEvent += ActiveSkill;
    }
    public override void ActiveSkill()
    {
        _health.SkillNumder = 2;
    }

    private IEnumerator SkillTime()
    {
        yield return new WaitForSeconds(2f);
        _health.SkillNumder = 0;
    }
}
