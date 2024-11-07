using UnityEngine;

public abstract class CharacterSkill : MonoBehaviour, IPlayerComponents
{
    protected bool isSkillStart;
    protected Player _player;
    protected StatSO _stat;
    protected Health _health;
    public void Initialize(Player player)
    {
        _player = player;
        _stat = _player.GetCompo<StatSO>();
        _health = _player.GetCompo<Health>();
        AwakePlayer();
    }

    public virtual void ActiveSkill()
    {
        if (isSkillStart) return;
        isSkillStart = true;
    }

    protected virtual void UpdateCharacterSkill()
    {

    }

    protected virtual void AwakePlayer()
    {
        
    }
    private void Update()
    {
        UpdateCharacterSkill();
    }
}
