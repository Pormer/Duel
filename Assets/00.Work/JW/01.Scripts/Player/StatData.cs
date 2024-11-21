using System;
using UnityEngine;
using UnityEngine.Events;

public class StatData : IPlayerComponents
{
    public UnityEvent<int> OnHealthChanged;
    public UnityEvent<int> OnBarrierChanged;

    private int health;

    public int Health // 체력
    {
        get => health;
        set
        {
            if(value < 0) return;
            OnHealthChanged?.Invoke(value);
            health = value;
        }
    }

    private int barrierCount;

    public int BarrierCount // 베리어 수
    {
        get => barrierCount;
        set
        {
            OnBarrierChanged?.Invoke(value);
            
            if (value < 0) return;
            barrierCount = value;
        }
    }

    private int damage; 
    
    public int Damage // 총알데미지
    {
        get => damage;
        set
        {
            if(value < 0) return;
            damage = value;
        }
    }

    public int maxBulletCount; //최대 총알 수
    private int curBulletCount;

    public int CurBulletCount //현재 총알 수 
    {
        get => curBulletCount;
        set
        {
            if (maxBulletCount < value) return;
            curBulletCount = value;
        }
    }

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
                CurBulletCount++;
            }
            else
            {
                curLoadCount = value;
            }
        }
    }

    public bool IsCanShoot => curBulletCount > 0; //발사 가능 여부

    public void Initialize(Player player)
    {
    }

    public StatData(CharacterDataSO cdata, GunDataSO gData)
    {
        curBulletCount = gData.bulletCount;
        cooltime = gData.coolTime;
        Damage = gData.damage;
        wantLoadCount = gData.wantLoadCount;
        curLoadCount = 0;

        barrierCount = cdata.barrierCount;
        health = cdata.hp;
    }
}