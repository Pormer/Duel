using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapInfo
{
    private Tilemap _floor;

    public MapInfo(Tilemap floorTile)
    {
        _floor = floorTile;
    }

    public bool CanMove(Vector3Int nextPos)
    {
        //이동하고자 하는 타일이 존재하고 그리고 충돌 타일에는 타일 없고
        return _floor.GetTile(nextPos);
    }

    public Vector3Int GetTilePosFromWorldPos(Vector3 from) => _floor.WorldToCell(from);
    public Vector3 GetCellCenterToWorld(Vector3Int cellCenter) 
        => _floor.GetCellCenterWorld(cellCenter);
}
