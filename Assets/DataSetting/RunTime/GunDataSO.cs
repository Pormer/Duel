using DataType;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Gun/Data")]
public class GunDataSO : ItemDataSO
{
    public GunType gunType; //스킬 이름
    public int damage; //공격 데미지
    public float coolTime; //다음 발사가능 시간
    public int bulletCount; //총알의 수
    public int wantLoadCount; //장전을 위한 움직임 수
    public float range; //총의 사거리
}
