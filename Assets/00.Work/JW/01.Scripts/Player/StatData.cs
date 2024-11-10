using UnityEngine;

public class StatData : IPlayerComponents
{
    public int hp; // 체력
    public int barrierCount; // 베리어 수
    public int damage; // 총알데미지

    public int maxBulletCount; //최대 총알 수
    public int curBulletCount; //현재 총알 수
    public float cooltime; // 다음 총알 발사 가능 시간
    public int wantLoadCount; //장전되는데 필요한 움직임 수
    private int curLoadCount;
    public int CurLoadCount //현재 움직인 수
    {
        get => curLoadCount;
        set
        {
            if (wantLoadCount <= value)
            {
                curLoadCount = 0;
                
                if(maxBulletCount > curBulletCount)
                    curBulletCount++;
            }
            else
            {
                curLoadCount = value;
            }
        }
    } 
    public bool IsCanShoot => curLoadCount > 0; //발사 가능 여부

    public void Initialize(Player player)
    {
        
    }
    
    public StatData(CharacterDataSO cdata, GunDataSO gData)
    {
        curBulletCount = gData.bulletCount;
        cooltime = gData.coolTime;
        damage = gData.damage;
        wantLoadCount = gData.wantLoadCount;
        curLoadCount = 0;
        
        
        barrierCount = cdata.barrierCount;
        hp = cdata.hp;
    }
}
