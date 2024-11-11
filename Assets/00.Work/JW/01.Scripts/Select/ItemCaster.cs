using System;
using UnityEngine;

public class ItemCaster : MonoBehaviour, IPlayerComponents
{
    [SerializeField] ContactFilter2D targetFilter;
    [SerializeField] private Vector2 castSize;
    private Collider2D[] cols;
    private Player _player;
    
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
                print("Select");
                item.Select(_player.GetCompo<InputReaderSO>().IsRight);
            }
        }
    }

    public void Initialize(Player player)
    {
        _player = player;
        
        _player.GetCompo<InputReaderSO>().OnShootEvent += CastItem;
    }

    private void OnDestroy()
    {
        _player.GetCompo<InputReaderSO>().OnShootEvent -= CastItem;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, castSize);
        Gizmos.color = Color.white;
    }
}
