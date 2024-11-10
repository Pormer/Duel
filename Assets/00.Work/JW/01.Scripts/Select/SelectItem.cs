using DataType;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    [SerializeField] private SelectDataManagerSO selectDataM;
    [SerializeField] private CharacterType charType;
    [SerializeField] private GunType gunType;
    private bool isChar;

    public void Initialize(CharacterType cType)
    {
        charType = cType;
        isChar = true;
    }
    public void Initialize(GunType gType)
    {
        gunType = gType;
        isChar = false;
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