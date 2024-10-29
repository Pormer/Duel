using UnityEngine;

public abstract class CharacterSkill : MonoBehaviour, IPlayerComponents
{
    protected Player _player;
    public void Initialize(Player player)
    {
        _player = player;
    }

    public virtual void ActiveSkill()
    {

    }

    protected virtual void UpdateCharacterSkill()
    {

    }
}
