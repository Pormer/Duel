using UnityEngine;

public class GamblerSkill : CharacterSkill
{
    protected override void AwakePlayer()
    {
        int hp = Random.Range(1, 1000);
        int barrier = Random.Range(1, 1000);
        Probability(hp, true);
        Probability(barrier, false);
    }

    private void Probability(int number, bool ishp)
    {
        if (number <= 0 && number >= 100)
        {
            if (ishp) _stat.hp = Random.Range(1, 2);
            else _stat.barrierCount = 1;
        }
        else if (number <= 101 && number >= 600)
        {
            if (ishp) _stat.hp = Random.Range(3, 4);
            else _stat.barrierCount = 2;
        }
        else if (number <= 601 && number >= 800)
        {
            if (ishp) _stat.hp = Random.Range(5, 6);
            else _stat.barrierCount = 3;
        }
        else if(number <= 801 && number >= 999)
        {
            if (ishp) _stat.hp = 7;
            else _stat.barrierCount = 4;
        }
        else
        {
            if (ishp) _stat.hp = 8;
            else _stat.barrierCount = 5;
        }
    }

}
