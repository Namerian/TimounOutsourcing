using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using UnityEngine.UI;
public class UIPlayerStamina : UIStamina, CombatEvents.ISendEntityInfo, CombatEvents.IEntityAddStamina ,CombatEvents.IEntitySubstractStamina{
    protected override void Awake()
    {
        base.Awake();
    }

    public void OnSendEntityInfo(Entity parEntity)
    {
        if (parEntity.GetComponent<Player.Player>() == entity)
        {
            //_textImage.text = entity.GetComponent<Stamina>().entityStaminaCurrent.ToString();
        } 
    }

    public override void OnEntityAddStamina(Entity parEntity, float amount)
    {
        if (parEntity.GetComponent<Player.Player>() == entity)
        {
            base.OnEntityAddStamina(entity, amount);
        }
    }

    public override void OnEntitySubstractStamina(Entity parEntity, float damage)
    {
        if (parEntity.GetComponent<Player.Player>() == entity)
        {
            base.OnEntitySubstractStamina(entity, damage);
        }

    }
}

