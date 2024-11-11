using UnityEngine;

public class AnubisSkill : CharacterSkill
{
    protected override void UpdateCharacterSkill()
    {
        if (_stat.hp == 1 && !isSkillStart)
        {
            isSkillStart = true;
            _stat.damage++;
        }
    }
}
