using UnityEngine;
using System.Collections;
using Combat;
using Events;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UITextCombo : UIText/*, CombatEvents.IUpdateComboHandler, CombatEvents.IEndTimingBarHandler */{


    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
        
    }

    void Start()
    {
        _text.DOFade(0, 0);
    }

    void PopCombo()
    {
        _text.DOFade(1, 0);
        Vector3 initialScale = _text.transform.localScale;
        _text.transform.DOScale(1.1f, 0.1f).OnComplete(()=> _text.transform.DOScale(1f, 0.1f));
    }

    public void OnUpdateCombo(int currentCombo, RhythmManager.RhythmState currentState)
    {
        if (currentCombo == 0)
        {
            _text.DOFade(0, 0.2f);
        }else
        {
            _text.text = "X " + currentCombo.ToString();
            PopCombo();
        }
    }

    public void OnEndTimingBar()
    {
        _text.DOFade(0, 0.2f);
    }
}
