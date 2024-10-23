using UnityEngine;

[CreateAssetMenu(menuName = "SO/Character/Data")]
public class CharacterDataSO : ScriptableObject
{
    public CharacterType charType; //캐릭터의 스킬 이름
    public int hp; //체력
    public int barrierCount; //베리어의 수
    public Color baseColor; //캐릭터를 대표하는 색
    public Sprite charSprite; //캐릭터의 외형
    public string explanation; //설명
}

public enum CharacterType
{
    
}