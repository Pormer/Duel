using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataType;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private DataManagerSO dataM;
    [SerializeField] SelectDataManagerSO selectDataM;
    [field: SerializeField] public Player[] PlayerGroup { get; private set; }
    [SerializeField] private CharacterDataSO[] selectCharData;
    [SerializeField] private GunDataSO[] selectGunData;

    private void Start()
    {
        PlayerGroup = new Player[2];
        selectCharData = new CharacterDataSO[2];
        selectGunData = new GunDataSO[2];

        if (GameManager.Instance.IsOnlinePlay)
        {
            GameManager.Instance.OnGameStart.AddListener
            (
                () => PlayerGroup = FindObjectsByType<Player>(FindObjectsSortMode.None)
            );
            GameManager.Instance.OnGameStart.AddListener(StartOnlineGameClientRpc);
        }
        else
        {
            PlayerGroup = FindObjectsByType<Player>(FindObjectsSortMode.None);
            PlayerInitialize();
        }
    }

    public void StartOnlineGameClientRpc()
    {
        if (NetworkManager.Singleton.IsHost && PlayerGroup[1].GetComponent<NetworkObject>().IsOwner)
            PlayerGroup.Reverse();
        if (NetworkManager.Singleton.IsClient)
        {
            PlayerGroup[1].transform.position = new Vector3(4, 0);
            PlayerGroup[1].transform.eulerAngles = new Vector3(0, 180, 0);
        }

        PlayerInitialize();
    }

    private void PlayerInitialize()
    {
        try
        {
            selectCharData[0] = dataM.characterDatas[(int)selectDataM.LeftCharType];
            selectGunData[0] = dataM.gunDatas[(int)selectDataM.LeftGunType];

            selectCharData[1] = dataM.characterDatas[(int)selectDataM.RightCharType];
            selectGunData[1] = dataM.gunDatas[(int)selectDataM.RightGunType];
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log(e);
        }

        for (int i = 0; i < PlayerGroup.Length; i++)
        {
            PlayerGroup[i].Initialize(selectCharData[i], selectGunData[i]);
        }
    }
}