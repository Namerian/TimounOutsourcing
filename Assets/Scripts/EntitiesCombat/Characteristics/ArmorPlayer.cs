using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;

[RequireComponent(typeof(Player.Player))]
public class ArmorPlayer : Armor{

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    protected override void Start()
    {
        base.Start();
        armorEntity = this.GetComponent<Player.Player>();
    }

}
