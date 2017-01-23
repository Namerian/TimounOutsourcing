using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;

public class SoundsSimpleAttack : MonoBehaviour, CombatEvents.IImpactAttackHandler {
    private SFXManager _SFXManager;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Start()
    {
        _SFXManager = SFXManager.instance;
    }

    public void OnImpactAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        if(parOwner != null && parOwner.GetType() == typeof(Player.Player))
        {
            if(parTarget.GetComponent<Armor>().armorState == Armor.ArmorState.BrokenArmor || parTarget.GetComponent<Armor>().armorState == Armor.ArmorState.NoArmor)
            {
                //no armor
                if (parOwner.entityArchetype == Entity.EntityArchetype.TANK)
                {
                    _SFXManager.PlaySingle(parOwner.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Hit_Brutal_Medium), true, true);
                }
                else if (parOwner.entityArchetype == Entity.EntityArchetype.HARASSER)
                {
                    _SFXManager.PlaySingle(parOwner.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Hit_Sharp_Medium), true, true);
                }
                
            }
            else
            {
                //armor
                _SFXManager.PlaySingle(parOwner.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Hit_ArmorBlock_Medium), true, true);
            }
        }
    }
}
