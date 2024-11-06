using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [field: SerializeField] public List<Player> PlayerGroup { get; private set; }
    [SerializeField] private List<CharacterDataSO> selectPlayerData;
    [SerializeField] private List<GunDataSO> selectGunData;

    private void Awake()
    {
        if (GameManager.Instance.IsOnlinePlay)
        {
            GameManager.Instance.OnGameStart.AddListener
            (
                () => PlayerGroup = FindObjectsByType<Player>(FindObjectsSortMode.None).ToList()
            );
            GameManager.Instance.OnGameStart.AddListener(StartOnlineGameClientRpc);
        }
        else
        {
            PlayerInitialize();
        }
        
    }

    [ClientRpc]
    public void StartOnlineGameClientRpc()
    {
        if (NetworkManager.Singleton.IsHost && PlayerGroup[1].GetComponent<NetworkObject>().IsOwner) PlayerGroup.Reverse();
        if (NetworkManager.Singleton.IsClient)
        {
            PlayerGroup[1].transform.position = new Vector3(4, 0); 
            PlayerGroup[1].transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        PlayerInitialize();
    }

    private void PlayerInitialize()
    {
        for (int i = 0; i < PlayerGroup.Count; i++)
        {
            PlayerGroup[i].Initialize(selectPlayerData[i], selectGunData[i]);
        }
    }
}