using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Compo

    [SerializeField] private InputReaderSO inputReader;
    private Gun GunCompo;
    private StatData _statData;
    
    public SpriteRenderer PlayerSpriteRenderer {  get; private set; }
    public SpriteRenderer MaskSpriteRenderer { get; private set; }

    #endregion
    
    public GunDataSO GunData { get; private set; }
    
    private Dictionary<Type, IPlayerComponents> _components;
    
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
        GunData = gData;

        _statData = new StatData(cdata, gData);

        PlayerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        MaskSpriteRenderer = transform.Find("Visual").transform.Find("Mask").GetComponent<SpriteRenderer>();
        MaskSpriteRenderer.sprite = cdata.itemSprite;
        
        _components = new Dictionary<Type, IPlayerComponents>();

        GetComponentsInChildren<IPlayerComponents>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        //리플렉션
        string skillStr = $"{cdata.charType.ToString()}Skill";

        var type = Type.GetType(skillStr);

        print(type);
        var skillCompo = gameObject.AddComponent(type) as CharacterSkill;

        _components.Add(skillCompo.GetType(), skillCompo);
        _components.Add(inputReader.GetType(), inputReader);
        _components.Add(_statData.GetType(), _statData);

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
        
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

