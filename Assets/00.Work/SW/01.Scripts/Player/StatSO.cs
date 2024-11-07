using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/StatData")]
public class StatSO : ScriptableObject, IPlayerComponents
{
    public int hp; // 체력
    public int barrierCount; // 베리어 수
    public int damage; // 총알데미지
    public int curBulletCount; //현재 총알 수
    public float cooltime; // 다음 총알 발사 가능 시간
    public void Initialize(Player player)
    {

    }
}
