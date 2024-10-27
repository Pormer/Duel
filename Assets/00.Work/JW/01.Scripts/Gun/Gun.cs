using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunSkill SkillCompo { get; private set; }
    public DamageCaster DamageCastCompo {get; private set;}
    public GunDataSO gunData {get; private set;}
    protected Player agent;
    
    public void Initialize(Player owner, GunDataSO data)
    {
        agent = owner;
        gunData = data;
        if(owner.IsRight) owner.GetCompo<InputReaderSO>().OnRightSkillEvent += SkillCompo.EnterSkill;
        else owner.GetCompo<InputReaderSO>().OnLeftSkillEvent += SkillCompo.EnterSkill;
        
        DamageCastCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        DamageCastCompo.Initialize(data.range);
        
        if(owner.IsRight) DamageCastCompo.transform.position = Vector2.right * -6;
        else DamageCastCompo.transform.position = Vector2.right * 6;

        string skillStr = $"{data.gunType.ToString()}Skill";

        var type = skillStr.GetType();
        
        Component te = gameObject.AddComponent(type);
    }
}
