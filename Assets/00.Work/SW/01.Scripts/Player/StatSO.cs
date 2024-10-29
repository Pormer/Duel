using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Stat")]
public class StatSO : ScriptableObject
{
    public int hp;
    public int barrierCount;
    public int damage;
    public int curBlletCount;
    public float cooltime;
}
