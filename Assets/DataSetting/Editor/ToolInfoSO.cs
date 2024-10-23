using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/ToolInfo")]
public class ToolInfoSO : ScriptableObject
{
    [Header("Data")] 
    public string dataSettingFolder = "Assets/00.Work/JW/02.SO/Data";
    public string managerAssetName = "DataManager.Asset";
    public string charFolder = "Character";
    public string gunFolder = "Gun";
}