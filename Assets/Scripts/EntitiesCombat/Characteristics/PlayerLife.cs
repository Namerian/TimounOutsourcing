using UnityEngine;
using System.Collections;
using Combat;
using Events;
using Player;
using System;

[RequireComponent(typeof(Player.Player))]

public class PlayerLife : Life  
{
    
    // Use this for initialization
    protected override void Awake () {
        base.Awake();
        lifeEntity = this.GetComponent<Player.Player>();
    }

    
}
