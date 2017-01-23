using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using UnityEngine.UI;
public class UITextTurnPlayerFeedBack : UIText, CombatEvents.IFeedbackTurnPlayer {


    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
    }

    public void FeedbackTurnPlayer(float animationDuration)
    {
        _text.text = "Tour bientôt fini !";
        UIManager.instance.Fade(_text.gameObject, 1, animationDuration / 4);
        UIManager.instance.PopUpScale(this.transform, animationDuration / 4, animationDuration / 4, animationDuration / 2);
    }
}
