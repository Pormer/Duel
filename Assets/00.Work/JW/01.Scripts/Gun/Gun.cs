using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Gun : MonoBehaviour, IPlayerComponents
{
    public GunSkill SkillCompo { get; private set; }
    public DamageCaster DamageCastCompo {get; private set;}
    public GunDataSO gunData {get; private set;}
    protected Player agent;


    public void Initialize(Player player)
    {
        agent = player;
        gunData = player.GunData;

        DamageCastCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        DamageCastCompo.Initialize(gunData.range);

        if (player.IsRight) DamageCastCompo.transform.position = Vector2.right * -6;
        else DamageCastCompo.transform.position = Vector2.right * 6;
        
        //리플렉션
        string skillStr = $"{gunData.gunType.ToString()}Skill";

        var type = Type.GetType(skillStr);

        print(type);
        SkillCompo = gameObject.AddComponent(type) as GunSkill;
        SkillCompo.Initialize(agent);
        
        if (player.IsRight) player.GetCompo<InputReaderSO>().OnRightSkillEvent += SkillCompo.EnterSkill;
        else player.GetCompo<InputReaderSO>().OnLeftSkillEvent += SkillCompo.EnterSkill;
    }
}
