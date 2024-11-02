using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO inputReader;
    public CharacterDataSO CharacterData { get; private set; }
    public GunDataSO GunData { get; private set; }
    [SerializeField] private StatSO StatData;

    private Gun GunCompo;
    private Dictionary<Type, IPlayerComponents> _components;
    public bool IsOnBarrier { get; private set; }

    public Action OnHitBarrier;

    public SpriteRenderer SpriteRenderer {  get; set; }


    public T GetCompo<T>() where T : class
    {
        Type type = typeof(T);
        if (_components.TryGetValue(type, out IPlayerComponents compo))
        {
            return compo as T;
        }

        return default;
    }

    public void Initialize(CharacterDataSO cdata, GunDataSO gData)
    {
        CharacterData = cdata;
        GunData = gData;


        StatData.curBulletCount = GunData.bulletCount;
        StatData.cooltime = GunData.coolTime;
        StatData.damage = GunData.damage;

        StatData.barrierCount = CharacterData.barrierCount;
        StatData.hp = CharacterData.hp;

        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _components = new Dictionary<Type, IPlayerComponents>();

        GetComponentsInChildren<IPlayerComponents>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Add(inputReader.GetType(), inputReader);
        _components.Add(StatData.GetType(), StatData);

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        inputReader.OnMoveEvent += GetCompo<PlayerMovement>().SetMovement;
        inputReader.OnBarrierPressEvent += () => 
        { 
            IsOnBarrier = true; 
        };
        inputReader.OnBarrierReleseEvent += () => 
        { 
            IsOnBarrier = false; 
        };
    }
}

