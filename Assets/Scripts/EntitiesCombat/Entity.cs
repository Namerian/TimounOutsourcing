using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Events;
using Combat;
using System;

public abstract class Entity : MonoBehaviour
{

    public enum EntityState
    {
        ALIVE,
        DEATH,
        COMA,
    }

    public enum EntityStance
    {
        NONE,
        STUN,
        GUARD,
        KNOCKBACK,
        EVADE
    }

    public enum EntityArchetype
    {
        NONE,
        HARASSER,
        TANK
    }

    
    public string entityName;
    public EntityState entityState;
    public EntityStance entityStance;
    public EntityArchetype entityArchetype;
    public CustomSequenceList.Owner owner;
    public List<EntityAction> listOfActions = new List<EntityAction>();
    [HideInInspector]
    public Life lifeScript;
    [HideInInspector]
    public Stamina staminaScript;
    [HideInInspector]
    public Armor armorScript;
    public int ID;

    public virtual void Awake()
    {
        EventCenter.AddSubscriber(this);
    }
    public abstract void Start();
    public abstract void Death();
    
}
