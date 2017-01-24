using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using UnityEngine.UI;

public class UIStamina : UIFillImage, CombatEvents.IEntityAddStamina, CombatEvents.IEntitySubstractStamina
{
    public Entity entity;
    public Image[] images;
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
        _imageFill = transform.GetChild(0).GetComponent<Image>();
        images = GetComponentsInChildren<Image>();
        //_textImage = _imageFill.transform.GetChild(0).GetComponent<Text>();
    }

    public virtual void OnEntityAddStamina(Entity entity, float amount)
    {
        if(entity == null)
        {
            return;
        }
        float currentStamina = entity.GetComponent<Stamina>().entityStaminaCurrent;
        float maxStamina = entity.GetComponent<Stamina>().entityStaminaMax;
        _imageFill.fillAmount = currentStamina / maxStamina;
        foreach(Image image in images)
        {
            image.fillAmount = currentStamina / maxStamina;
        }
        //_textImage.text = Mathf.Round(currentStamina).ToString();
        ColorText(entity);
    }

    public virtual void OnEntitySubstractStamina(Entity entity, float amount)
    {
        if(entity == null)
        {
            return;
        }

        float currentStamina = entity.GetComponent<Stamina>().entityStaminaCurrent;
        float maxStamina = entity.GetComponent<Stamina>().entityStaminaMax;
        _imageFill.fillAmount = currentStamina / maxStamina;
        foreach (Image image in images)
        {
            image.fillAmount = currentStamina / maxStamina;
        }
        //_textImage.text = Mathf.Round(currentStamina).ToString();
        ColorText(entity);
        //UIManager.instance.ShakeScaleUI(_imageFill.transform.parent, shakeDuration, shakeStrength, shakeNbOfVibration, shakeRandomness);
    }

    void ColorText(Entity entity)
    {
        if(entity.staminaScript.isOutOfStamina)
        {
            //_textImage.color = Color.red;
        }else if(entity.staminaScript.staminaState == Stamina.StaminaState.LowStamina)
        {
            //_textImage.color = Color.yellow;
        }
        else
        {
           //_textImage.color = Color.white;
        }
    }
}
