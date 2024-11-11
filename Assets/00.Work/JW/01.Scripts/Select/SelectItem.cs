using DataType;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    [SerializeField] DataManagerSO dataM;
    [SerializeField] private SelectDataManagerSO selectDataM;
    [SerializeField] private CharacterType charType;
    [SerializeField] private GunType gunType;

    private SpriteRenderer _spriter;
    private bool isChar;

    public void Initialize(CharacterType cType)
    {
        _spriter = transform.Find("Visual").GetComponent<SpriteRenderer>();
        
        charType = cType;
        isChar = true;
        _spriter.sprite = dataM.characterDatas[(int)charType].itemSprite;
    }
    public void Initialize(GunType gType)
    {
        _spriter = transform.Find("Visual").GetComponent<SpriteRenderer>();
        
        gunType = gType;
        isChar = false;
        
        _spriter.sprite = dataM.gunDatas[(int)gunType].itemSprite;
    }

    public void Select(bool isRight)
    {
        if (isRight)
        {
            if (isChar)
                selectDataM.SelectCharacter(true, charType);
            else
            {
                selectDataM.SelectGun(true, gunType);
            }
        }
        else
        {
            if (isChar)
                selectDataM.SelectCharacter(false, charType);
            else
            {
                selectDataM.SelectGun(false, gunType);
            }
        }
    }
}