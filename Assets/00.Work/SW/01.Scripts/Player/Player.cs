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

    private Gun GunCompo;
    private Dictionary<Type, IPlayerComponents> _components;
    [field: SerializeField] public bool IsRight {  get; private set; }
    public bool IsOnBarrier { get; private set; }


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

        _components = new Dictionary<Type, IPlayerComponents>();

        GetComponentsInChildren<IPlayerComponents>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Add(inputReader.GetType(), inputReader);

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        if (IsRight)
            inputReader.OnRightMoveEvemt += GetCompo<PlayerMovement>().SetMovement;
        else
            inputReader.OnLeftMoveEvemt += GetCompo<PlayerMovement>().SetMovement;
    }
}

