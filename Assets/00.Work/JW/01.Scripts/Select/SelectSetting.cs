using System;
using UnityEngine;

public class SelectSetting : MonoBehaviour
{
    [SerializeField] private SelectDataManagerSO selectDataM;
    public GunDataUiSet GunUiSet { get; private set; }
    public CharacterDataUiSet CharUiSet { get; private set; }

    private void OnEnable()
    {
        CharUiSet = FindFirstObjectByType<CharacterDataUiSet>();
        GunUiSet = FindFirstObjectByType<GunDataUiSet>();

        selectDataM.OnSelect += NextDataSelect;
    }

    private void Awake()
    {
        GameManager.Instance.OnGameStart += () => CharUiSet.gameObject.SetActive(true);
    }

    private void Start()
    {
        GunUiSet.gameObject.SetActive(false);
        CharUiSet.gameObject.SetActive(true);
        
        selectDataM.SpawnSelectCharItem(transform);
    }

    private void NextDataSelect()
    {
        CharUiSet.gameObject.SetActive(false);
        GunUiSet.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        selectDataM.OnSelect -= NextDataSelect;
    }
}