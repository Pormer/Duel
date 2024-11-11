using System;
using UnityEngine;

public class SelectSetting : MonoBehaviour
{
    [SerializeField] private SelectDataManagerSO selectDataM;
    
    private void Start()
    {
        selectDataM.SpawnSelectCharItem(transform);
    }

    private void HandleSpawnGun()
    {
        
    }
}
