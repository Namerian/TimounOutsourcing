using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;

public class UICoolDownActionPlayer : UICoolDownAction,
    CombatEvents.IStartUICoolDownHandler,
    CombatEvents.IEndUICoolDownHandler
{

    float _fillAmount = 0f;
    EntityAction _action;

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnSendEntityInfo(Entity parEntity)
    {
        if (parEntity.GetComponent<Player.Player>() == entity)
        {

            _action = entity.listOfActions[index];
            //_textImage.text = entity.GetComponent<Stamina>().entityStaminaCurrent.ToString();
        }
    }

    public void OnStartUICoolDown(EntityAction parAction)
    {
        if(parAction == entity.listOfActions[index])
        {
            StartCoroutine(CoolDown(_action.coolDown));
        }
    }

    public void OnEndUICoolDown(EntityAction parAction)
    {
        _imageFill.fillAmount = 1f;
    }

    void UpdateFillImage(float amount, float maxAmount)
    {
        _imageFill.fillAmount = amount / maxAmount;
    }

    IEnumerator CoolDown(float time)
    {
        float currentTime = 0f;

        while(currentTime < time)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            UpdateFillImage(currentTime, time);
        }
        
    }
}
