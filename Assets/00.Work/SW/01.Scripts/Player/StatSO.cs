using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/StatData")]
public class StatSO : ScriptableObject, IPlayerComponents
{
    public int hp; // ü��
    public int barrierCount; // ������ ��
    public int damage; // �Ѿ˵�����
    public int curBulletCount; //���� �Ѿ� ��
    public float cooltime; // ���� �Ѿ� �߻� ���� �ð�
    public void Initialize(Player player)
    {

    }
}
