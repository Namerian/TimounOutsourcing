using UnityEngine;
using System.Collections;
using System;
using Events;
using Combat;
public class UITextChangeTurn : UIText, CombatEvents.ITurnTransitionHandler
{
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
    }

    public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentTurn, float duration)
    {
        _text.text = "Changement de tour !";
        UIManager.instance.Fade(_text.gameObject, 1, duration / 4);
        UIManager.instance.PopUpScale(this.transform, duration / 4, duration / 4, duration / 2);
    }

}
