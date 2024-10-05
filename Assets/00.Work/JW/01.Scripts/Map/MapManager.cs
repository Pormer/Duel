using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private MapInfoSO mapInfo;
    [SerializeField] Tilemap floorTile;

    private void Awake()
    {
        mapInfo.Initialize(floorTile);
    }
}
