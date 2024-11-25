using System;
using UnityEngine;

public class SelectSetting : MonoBehaviour
{
    [SerializeField] private SelectDataManagerSO selectDataM;
    public GunDataUiSet GunUiSet { get; private set; }
    public CharacterDataUiSet CharUiSet { get; private set; }

    private void Awake()
    {
        CharUiSet = FindFirstObjectByType<CharacterDataUiSet>();
        GunUiSet = FindFirstObjectByType<GunDataUiSet>();
        //GunUiSet.gameObject.SetActive(false);

        selectDataM.OnSelect += NextDataSelect;
    }

    private void Start()
    {
        selectDataM.SpawnSelectCharItem(transform);
    }

    private void NextDataSelect()
    {
        CharUiSet.gameObject.SetActive(false);
        GunUiSet.gameObject.SetActive(true);
    }
}
