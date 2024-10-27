using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] InputReaderSO inputReader;
    [SerializeField] CharacterDataSO characterData;
    private Dictionary<Type, IPlayerComponents> _components;
    public bool IsRight {  get; private set; }
    public bool IsOnLeftBarrier{ get; private set; }
    public bool IsOnRightBarrier { get; private set; }

    private void Awake()
    {
        _components = new Dictionary<Type, IPlayerComponents>();

        GetComponentsInChildren<IPlayerComponents>().ToList()
            .ForEach(x => _components.Add(x.GetType(), x));

        _components.Add(inputReader.GetType(), inputReader);

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));

        if(IsRight)
            inputReader.OnRightMoveEvemt += GetCompo<PlayerMovement>().SetMovement;
        else
            inputReader.OnLeftMoveEvemt += GetCompo<PlayerMovement>().SetMovement;

        GetCompo<Health>().Hp = characterData.hp;
    }

    public T GetCompo<T>() where T : class
    {
        Type type = typeof(T);
        if (_components.TryGetValue(type, out IPlayerComponents compo))
        {
            return compo as T;
        }

        return default;
    }
}

