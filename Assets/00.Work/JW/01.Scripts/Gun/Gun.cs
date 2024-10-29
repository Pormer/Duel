using System;
using UnityEngine;

public class Gun : MonoBehaviour, IPlayerComponents
{
    public GunSkill SkillCompo { get; private set; }
    public DamageCaster DamageCastCompo {get; private set;}
    private GunDataSO _gunData;
    protected Player agent;


    public void Initialize(Player player)
    {
        agent = player;
        _gunData = player.GunData;

        DamageCastCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        DamageCastCompo.Initialize(_gunData.range);
        
        //리플렉션
        string skillStr = $"{_gunData.gunType.ToString()}Skill";

        var type = Type.GetType(skillStr);

        print(type);
        SkillCompo = gameObject.AddComponent(type) as GunSkill;
        SkillCompo.Initialize(agent);
        
        if (player.IsRight) player.GetCompo<InputReaderSO>().OnRightShootEvent += SkillCompo.EnterSkill;
        else player.GetCompo<InputReaderSO>().OnLeftShootEvent += SkillCompo.EnterSkill;
    }
}
