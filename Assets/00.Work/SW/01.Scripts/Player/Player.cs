using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] InputReaderSO inputReader;
    public CharacterDataSO CharacterData { get; private set; }
    public GunDataSO GunData { get; private set; }
    public StatSO Stat { get; private set; }

    private Gun GunCompo;
    private Dictionary<Type, IPlayerComponents> _components;
    [field: SerializeField] public bool IsRight {  get; private set; }
    public bool IsOnBarrier { get; private set; }

    public Action OnHitBarrier;


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

        Stat = new StatSO();

        Stat.curBlletCount = GunData.bulletCount;
        Stat.cooltime = GunData.coolTime;
        Stat.damage = GunData.damage;

        Stat.barrierCount = CharacterData.barrierCount;
        Stat.hp = CharacterData.hp;

        _components = new Dictionary<Type, IPlayerComponents>();

        GetComponentsInChildren<IPlayerComponents>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Add(inputReader.GetType(), inputReader);

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        if (IsRight)
        {
            inputReader.OnMoveRightEvent += GetCompo<PlayerMovement>().SetMovement;
            inputReader.OnRightBarrierPressEvent += () => 
            { 
                IsOnBarrier = true; 
            };
            inputReader.OnRightBarrierReleseEvent += () => 
            { 
                IsOnBarrier = false; 
            };

        }
        else
        {
            inputReader.OnMoveLeftEvent += GetCompo<PlayerMovement>().SetMovement;
            inputReader.OnLeftBarrierPressEvent += () => 
            { 
                IsOnBarrier = true; 
            };
            inputReader.OnLeftBarrierReleseEvent += () => 
            { 
                IsOnBarrier = false; 
            };

        }
    }
}

