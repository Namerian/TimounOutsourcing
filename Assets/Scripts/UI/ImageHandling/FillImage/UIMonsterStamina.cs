using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using UnityEngine.UI;
public class UIMonsterStamina : UIStamina, CombatEvents.ISendEntityInfo, CombatEvents.IEntityAddStamina, CombatEvents.IEntitySubstractStamina
{

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnSendEntityInfo(Entity entity)
    {
        if (entity.GetComponent<Monster.Monster>())
        {
            _textImage.text = entity.GetComponent<Stamina>().entityStaminaCurrent.ToString();
        }
    }

    public override void OnEntityAddStamina(Entity entity, float amount)
    {
        if (entity.GetComponent<Monster.Monster>())
        {
            base.OnEntityAddStamina(entity, amount);
        }
    }

    public override void OnEntitySubstractStamina(Entity entity, float damage)
    {
        if (entity.GetComponent<Monster.Monster>())
        {
            base.OnEntitySubstractStamina(entity, damage);
        }

    }
}
