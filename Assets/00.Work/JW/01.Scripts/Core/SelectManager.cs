using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private Player[] playerGroup;
    [SerializeField] private List<CharacterDataSO> selectPlayerData;
    [SerializeField] private List<GunDataSO> selectGunData;

    private void Awake()
    {
        
    }

    private void Start()
    {
        for (int i = 0; i < playerGroup.Length; i++)
        {
            playerGroup[i].Initialize(selectPlayerData[i], selectGunData[i]);
        }
    }
}