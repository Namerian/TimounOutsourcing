using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;

[RequireComponent(typeof(Monster.Monster))]
public class ArmorMonster : Armor,
    CombatEvents.IInitCombatHandler
{

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    protected override void Start()
    {
        base.Start();
        armorEntity = this.GetComponent<Monster.Monster>();
    }

    public void OnInitCombat()
    {
        canRegen = true;
        StartCoroutine(RegenArmor());
    }
}