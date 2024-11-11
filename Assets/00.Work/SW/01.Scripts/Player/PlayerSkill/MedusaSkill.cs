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

    }

    private IEnumerator SkillTime()
    {
        yield return new WaitForSeconds(2f);

    }
}
