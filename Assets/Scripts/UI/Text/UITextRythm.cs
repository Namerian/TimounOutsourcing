using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;
using DG.Tweening;
public class UITextRythm : UIText, CombatEvents.IShowCurrentTimingHandler {

    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
    }

    public void OnShowCurrentTiming(RhythmManager.RhythmState rythmState)
    {
        switch (rythmState)
        {
            case RhythmManager.RhythmState.Bad:
                _text.DOFade(1, 0.2f).OnComplete(() => _text.DOFade(0, 0.2f));
                _text.text = "BAD";
                break;
            /*case RhythmManager.RhythmState.Good:
                _text.DOFade(1, 0.2f).OnComplete(() => _text.DOFade(0, 0.2f));
                _text.text = "GOOD";
                break;*/
            case RhythmManager.RhythmState.Perfect:
                _text.DOFade(1, 0.2f).OnComplete(() => _text.DOFade(0, 0.2f));
                _text.text = "PERFECT";
                break;
            default:
                _text.text = "";
                break;
        }
    }
}
