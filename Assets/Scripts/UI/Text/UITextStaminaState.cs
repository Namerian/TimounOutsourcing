using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using UnityEngine.UI;
using DG.Tweening;
public class UITextStaminaState : UIText, 
    CombatEvents.IEntityIsLowOnStamina, 
    CombatEvents.IEntityIsFullOfStamina, 
    CombatEvents.IEntityIsNormalOnStamina, 
    CombatEvents.IEntityIsOutOfStamina,
    CombatEvents.ISendEntityInfo
{
    bool isOutOfStamina;
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
        isOutOfStamina = false;
    }

    public void OnEntityIsFullOfStamina(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Full Stamina";
            isOutOfStamina = false;
            Up();
        }
    }

    public void OnEntityIsLowOnStamina(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Low Stamina";
            isOutOfStamina = false;
            Up();
        }
    }

    public void OnEntityIsOutOfStamina(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Out of Stamina";
            isOutOfStamina = true;
            Up();
        }
    }

    public void OnIEntityIsNormalOnStamina(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Normal Stamina";
            isOutOfStamina = false;
            Up();
        }
    }

    public void OnSendEntityInfo(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Full Stamina";
            isOutOfStamina = false;
            Up();
        }
    }

    void Up()
    {
        if (isOutOfStamina)
        {
            GetComponent<Text>().DOFade(1, 0.5f).OnComplete(() => Down());
            transform.DOScale(1f, 0.5f);
        }
        else
        {
            GetComponent<Text>().DOFade(1, 0.5f);
            transform.DOScale(1f, 0.5f);
        }
    }
    void Down()
    {
        if (isOutOfStamina)
        {
            gameObject.GetComponent<Text>().DOFade(0.3f, 0.5f).OnComplete(() => Up());
            gameObject.transform.DOScale(0.8f, 0.5f);
        }
        else
        {
            GetComponent<Text>().DOFade(1, 0.5f);
            transform.DOScale(1f, 0.5f);
        }
    }
}
