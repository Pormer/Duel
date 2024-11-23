using System;
using DataType;
using UnityEngine;
using UnityEngine.Events;

public class ItemCaster : MonoBehaviour
{
    [SerializeField] DataManagerSO dataM;
    [SerializeField] ContactFilter2D targetFilter;
    [SerializeField] private Vector2 castSize;
    private Collider2D[] cols;
    private Player _player;

    public UnityEvent<CharacterDataSO> OnTargetCharExp;
    public UnityEvent<GunDataSO> OnTargetGunExp;

    private void Awake()
    {
        cols = new Collider2D[1];
    }

    public void CastItem()
    {
        var col = Physics2D.OverlapBox(transform.position, castSize, 0, targetFilter, cols);

        if (col > 0)
        {
            if (cols[0].TryGetComponent(out SelectItem item))
            {
                item.Select(_player.InputReaderCompo.IsRight);
            }
        }
    }

    public void CastItmeData(Vector2Int dir)
    {
        var col = Physics2D.OverlapBox(transform.position, castSize, 0, targetFilter, cols);

        if (col > 0)
        {
            if (cols[0].TryGetComponent(out SelectItem item))
            {
                if (item.IsChar)
                    OnTargetCharExp?.Invoke(dataM.characterDatas[(int)item.CharType]);
                else
                    OnTargetGunExp?.Invoke(dataM.gunDatas[(int)item.GunType]);
            }
        }
    }

    public void Initialize(Player player)
    {
        _player = player;

        _player.InputReaderCompo.OnShootEvent += CastItem;
        _player.InputReaderCompo.OnMovementEvent += CastItmeData;
    }

    private void OnDestroy()
    {
        _player.InputReaderCompo.OnShootEvent -= CastItem;
        _player.InputReaderCompo.OnMovementEvent -= CastItmeData;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, castSize);
        Gizmos.color = Color.white;
    }
}