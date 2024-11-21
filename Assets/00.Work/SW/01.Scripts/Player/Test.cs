using UnityEngine;

public class Test : MonoBehaviour
{
    private GunDataUiSet dataUiSet;
    [SerializeField] private  GunDataSO sO;
    [SerializeField] private GunDataSO gun;
    private void Start()
    {
        dataUiSet = GetComponent<GunDataUiSet>();
        dataUiSet.UiSet(sO,true);
        dataUiSet.UiSet(gun, false);
    }
}
