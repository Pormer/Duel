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

    public void SetMovement(Vector2Int moveDir)
    {
        if (IsMove) return;

        Vector2Int v = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        if (!_mapInfo.CanMove((Vector3Int)v + (Vector3Int)moveDir)) return;
        IsMove = true;
        transform.DOMove((Vector3Int)(v + moveDir), 0.23f).SetEase(Ease.OutExpo).
            OnComplete(() => { IsMove = false; });
    }
}
