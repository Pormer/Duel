using System;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class OnlinePlayerSelect : MonoBehaviour
{
    [SerializeField] private Player leftPlayerObj;
    [SerializeField] private Player rightPlayerObj;

    private void OnEnable()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            Player item = Instantiate(leftPlayerObj, transform);
            
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            Player item = Instantiate(rightPlayerObj, transform);
        }
    }
}
