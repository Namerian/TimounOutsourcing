using UnityEngine;
using System.Collections;
using Combat;
using Events;
using Monster;
using System;
using GameInput;

public class UITextEntityDead : UIText, CombatEvents.IEntityIsOutOfLife
{
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
    }

    public void OnEntityIsOutOfLife(Entity entity)
    {
        if(entity.GetComponent<Monster.Monster>())
        {
            ContextManager.instance.ChangeContext(InputContextList.Exploration);
        }
        _text.text = entity.entityName + "has fainted !";
        UIManager.instance.Fade(_text.gameObject, 1, 0.5f);
        UIManager.instance.PopUpScale(this.transform, 0.5f, 0.5f, 1);
    }

}
