using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    #region Compo

    [SerializeField] private InputReaderSO inputReader;
    public StatData StatDataCompo {get; private set;}
    public FeedbackPlayer EventFeedbacksCompo { get; private set; }
    private PlayerMovement _movementCompo;

    public SpriteRenderer PlayerSpriteRenderer { get; private set; }
    public SpriteRenderer MaskSpriteRenderer { get; private set; }

    #endregion

    public GunDataSO GunData { get; private set; }

    private Dictionary<Type, IPlayerComponents> _components;

    public bool IsOnBarrier { get; private set; }
    public Action OnHitBarrier;

    List<GameObject> sdsds;
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
        
    }

    public void Initialize(CharacterDataSO cdata, GunDataSO gData)
    {
        _movementCompo = GetComponent<PlayerMovement>();
        _movementCompo.Initialize(this);
        _components.Add(inputReader.GetType(), inputReader);

        var itemCaster = GetComponentInChildren<ItemCaster>();
        if(itemCaster != null) itemCaster.Initialize(this);
        
        //구독
        inputReader.OnMoveEvent += _movementCompo.SetMovement;

        inputReader.OnBarrierPressEvent += () => { IsOnBarrier = true; };
        inputReader.OnBarrierReleseEvent += () => { IsOnBarrier = false; };
        
        if(cdata == null || gData ==null) return;
        
        //초기화
        GunData = gData;
        StatDataCompo = new StatData(cdata, gData);
        _components.Add(StatDataCompo.GetType(), StatDataCompo);
        
        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
        
        GetComponentInChildren<Gun>()?.Initialize(this);
        
        MaskSpriteRenderer.sprite = cdata.itemSprite;

        if (cdata.eventFeedback != null) EventFeedbacksCompo = Instantiate(cdata.eventFeedback, transform);

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
        inputReader.OnMoveEvent -= _movementCompo.SetMovement;
    }
}