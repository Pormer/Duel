using System;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    [SerializeField] ContactFilter2D targetFilter;
    [SerializeField] private Vector2 castSize;

    private Collider2D[] cols;
    private void Awake()
    {
        cols = new Collider2D[1];
    }

    public void Initialize(int range)
    {
        castSize = new Vector2(2 * range + 1, 0.6f);
    }

    public void CastDamage(int damage)
    {
        //Vector3 centerPos = new Vector3(5.5f, transform.position.y);
        var col = Physics2D.OverlapBox(transform.position, castSize, 0, targetFilter, cols);

        if (col > 0)
        {
            if (TryGetComponent(out Player player))
            {
                //베리어 확인하고 베리어가 없다면 데미지를 입고 베리어가 있다면 베리어를 1개 없엔다.
                print("Hit");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, castSize);
        Gizmos.color = Color.white;
    }
}
