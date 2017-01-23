using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using DG.Tweening;

public class UISpecialHarasser :  UIFillImage,
    CombatEvents.IShowSpecialBarHarasserHandler,
    CombatEvents.IUpdateSpecialBarHarasserHandler,
    CombatEvents.IHideSpecialBarHarasserHandler
{

    void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
    }

    public void OnHideSpecialBarHarasser()
    {
        transform.parent.GetComponent<CanvasGroup>().DOFade(0f, 0.2f);
    }

    public void OnShowSpecialBarHarasser()
    {
        transform.parent.GetComponent<CanvasGroup>().DOFade(1f, 0.2f);
    }

    public void OnUpdateSpecialBarHarasser(float parCurrentAmount, float parMaxAmount)
    {
        this._imageFill.fillAmount = parCurrentAmount / parMaxAmount;
    }

}
