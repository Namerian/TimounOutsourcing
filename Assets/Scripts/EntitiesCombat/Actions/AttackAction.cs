using UnityEngine;


public abstract class AttackAction : EntityAction
{
    [Header("Attack settings")]
    public float damage;
    [HideInInspector]
    public float baseDamageMultiplier = 1f;
    public float damageMultiplierBonus;
    public bool isReady;
    public float armorPiercingBonus;

    

    
    
}

