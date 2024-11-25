using System;
using System.Collections.Generic;
using System.Linq;
using DataType;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "SO/Manager/Select")]
public class SelectDataManagerSO : ScriptableObject
{
    public event Action OnSelect;

    [field: SerializeField] public CharacterType LeftCharType { get; private set; }
    [field: SerializeField] public GunType LeftGunType { get; private set; }
    [field: SerializeField] public CharacterType RightCharType { get; private set; }
    [field: SerializeField] public GunType RightGunType { get; private set; }

    private List<SelectItem> curItemList;
    private Transform _parent;

    [SerializeField] private SelectItem selectItemObj;
    [SerializeField] private int spawnCount = 5;
    [SerializeField] private Vector2 startSpawnPos;

    private void OnEnable()
    {
        curItemList = new List<SelectItem>();
        
        LeftCharType = CharacterType.Default;
        LeftGunType = GunType.Default;

        RightCharType = CharacterType.Default;
        RightGunType = GunType.Default;

#if UNITY_EDITOR
        if (!isDebug) return;
        LeftCharType = testCharType;
        LeftGunType = testGunType;

        RightCharType = testCharType;
        RightGunType = testGunType;
#endif
    }

    public void SelectCharacter(bool isRight, CharacterType type)
    {
        if (isRight)
            RightCharType = type;
        else
        {
            LeftCharType = type;
        }

        if (IsNotCharDefault())
        {
            SpawnSelectGunItem(_parent);
            OnSelect?.Invoke();
            
        }
    }

    public void SelectGun(bool isRight, GunType type)
    {
        if (isRight)
            LeftGunType = type;
        else
        {
            RightGunType = type;
        }

        if (IsNotGunDefault() && IsNotCharDefault())
        {
            NextStep();
        }
    }

    public void SpawnSelectCharItem(Transform parent)
    {
        _parent = parent;

        for (int i = 0; i < spawnCount; i++)
        {
            SelectItem item;
            item = Instantiate(selectItemObj, startSpawnPos + Vector2.up * i, Quaternion.identity, parent);
            curItemList.Add(item);

            item.Initialize((CharacterType)CheckDataValue<GunType>(Random.Range(1, 13)));
        }
    }

    public void SpawnSelectGunItem(Transform parent)
    {
        _parent = parent;

        for (int i = 0; i < spawnCount; i++)
        {
            SelectItem item;
            
            if (curItemList[i] == null)
            {
                item = Instantiate(selectItemObj, startSpawnPos + Vector2.up * i, Quaternion.identity, parent);
                curItemList.Add(item);
            }
            else
            {
                item = curItemList[i];
            }
            
            item.Initialize((GunType)CheckDataValue<GunType>(Random.Range(1, 16)));
        }
    }

    private int CheckDataValue<T>(int typeNum) where T : Enum
    {
        foreach (var item in curItemList)
        {
            if(item.IsChar)
            {
                if ((int)item.CharType == typeNum)
                {
                    return CheckDataValue<T>(Random.Range(1, 13));
                }
            }
            else
            {
                if ((int)item.GunType == typeNum)
                {
                    return CheckDataValue<T>(Random.Range(1, 16));
                }
            }
        }
        
        return typeNum;
    }

    public void NextStep()
    {
        GameManager.Instance.OnFadeIn?.Invoke(3);
    }

    private bool IsNotCharDefault()
    {
        bool isLeftChar = LeftCharType != CharacterType.Default;
        bool isRightChar = RightCharType != CharacterType.Default;

        return isLeftChar && isRightChar;
    }

    private bool IsNotGunDefault()
    {
        bool isLeftGun = LeftGunType != GunType.Default;
        bool isRightGun = RightGunType != GunType.Default;

        return isRightGun && isLeftGun;
    }
    
    
#if UNITY_EDITOR
    [SerializeField] private CharacterType testCharType;
    [SerializeField] private GunType testGunType;
    [SerializeField] private bool isDebug;
#endif
}