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
    
    private CharacterDataUiSet _charDataUiSet;
    private GunDataUiSet _gunDataUiSetUiSet;

    private void Awake()
    {
        cols = new Collider2D[1];
        _charDataUiSet = FindFirstObjectByType<CharacterDataUiSet>();
        _gunDataUiSetUiSet = FindFirstObjectByType<GunDataUiSet>();
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

    public void CastItmeData()
    {
        var col = Physics2D.OverlapBox(transform.position, castSize, 0, targetFilter, cols);

        if (col > 0)
        {
            if (cols[0].TryGetComponent(out SelectItem item))
            {
                if (item.IsChar)
                {
                    _charDataUiSet.UiSet(dataM.characterDatas[(int)item.CharType-1], _player.InputReaderCompo.IsRight);
                    //OnTargetCharExp?.Invoke(dataM.characterDatas[(int)item.CharType]);
                }
                else
                {
                    _gunDataUiSetUiSet.UiSet(dataM.gunDatas[(int)item.GunType-1], _player.InputReaderCompo.IsRight);
                    //OnTargetGunExp?.Invoke(dataM.gunDatas[(int)item.GunType]);
                }
            }
        }
    }

    public void Initialize(Player player)
    {
        _player = player;

        _player.InputReaderCompo.OnShootEvent += CastItem;
        _player.MovementCompo.OnEndMove += CastItmeData;
    }

    private void OnDestroy()
    {
        _player.InputReaderCompo.OnShootEvent -= CastItem;
        _player.MovementCompo.OnEndMove -= CastItmeData;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, castSize);
        Gizmos.color = Color.white;
    }
}