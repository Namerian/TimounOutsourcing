using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;

public class SoundsArmor : MonoBehaviour, CombatEvents.IEntityBrokenArmor, CombatEvents.IEntitySubstractArmor, CombatEvents.IEntityAddArmor {
    private SFXManager _SFXManager;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Start()
    {
        _SFXManager = SFXManager.instance;
    }

    public void OnEntityBrokenArmor(Entity entity)
    {
        _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Armor_Break), false);
    }

    public void OnEntitySubstractArmor(Entity entity, float amount)
    {
        switch (entity.GetComponent<Armor>().armorState)
        {
            case Armor.ArmorState.FullArmor:
                _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Armor_Crack), true, false,0.25f);
                break;
            case Armor.ArmorState.HighArmor:
                _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Armor_Crack), true, false, 0.5f);
                break;
            case Armor.ArmorState.MediumArmor:
                _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Armor_Crack), true, false, 0.75f);
                break;
            case Armor.ArmorState.LowArmor:
                _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Armor_Crack), true, false, 1f);
                break;
        }
    }

    public void OnEntityAddArmor(Entity parEntity, float amount)
    {
        if(parEntity.GetComponent<Armor>().currentArmor == 0)
        {
            _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Armor_Regenerate), false);
        }
    }
}
