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
    public Action OnSelect;

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
            
            Debug.Log("In");
            item = Instantiate(selectItemObj, startSpawnPos + Vector2.up * i, Quaternion.identity, parent);
            curItemList.Add(item);

            item.Initialize((CharacterType)CheckDataValue<GunType>(Random.Range(0, 12)));

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

            item.Initialize((GunType)CheckDataValue<GunType>(Random.Range(0, 15)));

        }
    }

    private int CheckDataValue<T>(int typeNum) where T : Enum
    {
        foreach (var item in curItemList)
        {
            Debug.Log(item == null);

            if(item.IsChar)
            {
                if ((int)item.CharType == typeNum)
                {
                    return CheckDataValue<T>(Random.Range(0, 12));
                }
            }
            else
            {
                if ((int)item.GunType == typeNum)
                {
                    return CheckDataValue<T>(Random.Range(0, 15));
                }
            }
        }

        return typeNum;
    }

    public void NextStep()
    {
        SceneManager.LoadScene(2);
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
}