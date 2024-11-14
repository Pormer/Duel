using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Compo

    [SerializeField] private InputReaderSO inputReader;
    public StatData StatDataCompo {get; private set;}

    public SpriteRenderer PlayerSpriteRenderer { get; private set; }
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

    private void Awake()
    {
        PlayerSpriteRenderer = transform.Find("Visual")?.GetComponent<SpriteRenderer>();
        MaskSpriteRenderer = transform.Find("Visual").transform.Find("Mask").GetComponent<SpriteRenderer>();
        
        _components = new Dictionary<Type, IPlayerComponents>();

        GetComponentsInChildren<IPlayerComponents>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));
        
        _components.Add(inputReader.GetType(), inputReader);
        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        inputReader.OnMoveEvent += GetCompo<PlayerMovement>().SetMovement;

        inputReader.OnBarrierPressEvent += () => { IsOnBarrier = true; };
        inputReader.OnBarrierReleseEvent += () => { IsOnBarrier = false; };
    }

    public void Initialize(CharacterDataSO cdata, GunDataSO gData)
    {
        GunData = gData;
        
        if(cdata == null || gData ==null) return;

        StatDataCompo = new StatData(cdata, gData);
        //_components.Add(StatDataCompo.GetType(), StatDataCompo);
        
        GetComponentInChildren<Gun>().Initialize(this);
        
        print(MaskSpriteRenderer == null);
        MaskSpriteRenderer.sprite = cdata.itemSprite;

        //리플렉션
        string skillStr = $"{cdata.charType.ToString()}Skill";
        var type = Type.GetType(skillStr);
        print($"Character: {skillStr}");
        var skillCompo = gameObject.AddComponent(type) as CharacterSkill;
        skillCompo?.Initialize(this);
        if (skillCompo != null) inputReader.OnSkillEvent += skillCompo.ActiveSkill;
    }

    private void OnDestroy()
    {
        inputReader.OnMoveEvent -= GetCompo<PlayerMovement>().SetMovement;
    }
}