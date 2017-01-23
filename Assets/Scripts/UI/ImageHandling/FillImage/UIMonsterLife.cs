using UnityEngine;
using System.Collections;
using Combat;
using System;
using Monster;
using DG.Tweening;
using Events;
public class UIMonsterLife : UILife, CombatEvents.IEntitySubstractLife, CombatEvents.ISendEntityInfo
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnEntitySubstractLife(Entity entity, float damage)
    {
        if (entity.GetComponent<Monster.Monster>())
        {
            base.OnEntitySubstractLife(entity, damage);
        }
    }

    public override void OnSendEntityInfo(Entity entity)
    {
        if (entity.GetComponent<Monster.Monster>())
        {
            _textImage.text = entity.GetComponent<MonsterLife>().currentLife.ToString();
        }
    }
}
