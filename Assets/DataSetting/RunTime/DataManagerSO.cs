using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Manager")]
public class DataManagerSO : ScriptableObject
{
    public List<CharacterDataSO> characterDatas;
    public List<GunDataSO> gunDatas;
}
