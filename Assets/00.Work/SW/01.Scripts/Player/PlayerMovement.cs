using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour, IPlayerComponents
{
    private Player _player;
    private MapInfo _mapInfo;
    [SerializeField] private Tilemap moveTile;
    bool IsMove { get; set; }
    public void Initialize(Player player)
    {
        _player = player;
        _mapInfo = new MapInfo(moveTile);
    }

    public void SetMovement(Vector2 moveDir)
    {
        if (IsMove) return;

        Vector2Int v = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        Vector2Int moveDirInt = new Vector2Int((int)moveDir.x, (int)moveDir.y);
        if (!_mapInfo.CanMove((Vector3Int)v + (Vector3Int)moveDirInt)) return;
        IsMove = true;
        transform.DOMove((Vector2)v + moveDir, 0.3f).SetEase(Ease.OutExpo).
            OnComplete(() => { IsMove = false; });
    }
}
