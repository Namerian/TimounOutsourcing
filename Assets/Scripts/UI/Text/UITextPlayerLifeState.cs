using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using Combat;
using Events;
using System;

public class UITextPlayerLifeState : UIText,
    CombatEvents.IEntityIsFullOnLife,
    CombatEvents.IEntityIsNormalOnLife,
    CombatEvents.IEntityIsLowOnLife,
    CombatEvents.IEntityIsOutOfLife,
    CombatEvents.ISendEntityInfo
{

    bool isLowOnLife;

    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
        isLowOnLife = false;
    }

    public void OnEntityIsFullOnLife(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Full life";
            isLowOnLife = false;
            Up();
        }
    }

    public void OnEntityIsLowOnLife(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Low life";
            isLowOnLife = true;
            Up();
        }
    }

    public void OnEntityIsNormalOnLife(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Normal life";
            isLowOnLife = false;
            Up();
        }   
    }

    public void OnEntityIsOutOfLife(Entity entity)
    {
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Dead";
            isLowOnLife = false;
            Up();
        } 
    }

    public void OnSendEntityInfo(Entity entity)
    {
        
        if (entity.GetComponent<Player.Player>())
        {
            _text.text = "Full life";
            isLowOnLife = false;
            Up();
        }
    }

    void Up()
    {
        if (isLowOnLife)
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
        if (isLowOnLife)
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
