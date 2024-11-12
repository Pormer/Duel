using DataType;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    [SerializeField] DataManagerSO dataM;
    [SerializeField] private SelectDataManagerSO selectDataM;
    public CharacterType CharType { get; private set; }
    public GunType GunType { get; private set; }

    private SpriteRenderer _spriter;
    private bool isChar;

    public void Initialize(CharacterType cType)
    {
        _spriter = transform.Find("Visual").GetComponent<SpriteRenderer>();
        
        CharType = cType;
        isChar = true;
        _spriter.sprite = dataM.characterDatas[(int)CharType].itemSprite;
    }
    public void Initialize(GunType gType)
    {
        _spriter = transform.Find("Visual").GetComponent<SpriteRenderer>();
        
        GunType = gType;
        isChar = false;
        
        _spriter.sprite = dataM.gunDatas[(int)GunType].itemSprite;
    }

    public void Select(bool isRight)
    {
        if (isRight)
        {
            if (isChar)
                selectDataM.SelectCharacter(true, CharType);
            else
            {
                selectDataM.SelectGun(true, GunType);
            }
        }
        else
        {
            if (isChar)
                selectDataM.SelectCharacter(false, CharType);
            else
            {
                selectDataM.SelectGun(false, GunType);
            }
        }
    }
}