using DataType;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Character/Data")]
public class CharacterDataSO : ItemDataSO
{
    public CharacterType charType; //캐릭터의 스킬 이름
    public int hp; //체력
    public int barrierCount; //베리어의 수
    public Color baseColor; //캐릭터를 대표하는 색
    public string skillName; //캐릭터 능력 이름
}