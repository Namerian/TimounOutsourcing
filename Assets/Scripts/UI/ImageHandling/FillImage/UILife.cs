using UnityEngine;
using System.Collections;
using Combat;
using System;
using DG.Tweening;
using Events;
using UnityEngine.UI;
public class UILife : UIFillImage, CombatEvents.IEntityAddLife, CombatEvents.IEntitySubstractLife, CombatEvents.ISendEntityInfo
{

    public GameObject textPrefab;
    Text _damageText;
    public Entity entity;
    protected override void Awake()
    {
        base.Awake();
        
        _imageFill = this.transform.GetChild(0).GetComponent<Image>();
        
        _textImage = _imageFill.transform.GetChild(0).GetComponent<Text>();
       
        EventCenter.AddSubscriber(this);
    }

    public virtual void OnEntitySubstractLife(Entity parEntity, float damage)
    {
        float currentLife = parEntity.GetComponent<Life>().currentLife;
        float maxLife = parEntity.GetComponent<Life>().maxLife;
        _imageFill.fillAmount = currentLife / maxLife;
        _textImage.text = Mathf.Round(currentLife).ToString();

        GameObject damageObject = new GameObject("damageText");
        damageObject.transform.SetParent(this.transform);
        damageObject.transform.position = this.transform.position;

        Text myText = damageObject.AddComponent<Text>();
        myText.rectTransform.DOAnchorPos(new Vector2(80, -50), 0);
        myText.text = "-" + damage;
        myText.resizeTextForBestFit = true;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        myText.font = ArialFont;
        myText.material = ArialFont.material;
        UIManager.instance.ChangeColor(damageObject, Color.red, 0);

        UIManager.instance.PopText(damageObject.GetComponent<Text>(), 0.7f);
        UIManager.instance.ShakeScaleUI(_imageFill.transform.parent, shakeDuration, shakeStrength, shakeNbOfVibration, shakeRandomness);
    }

    public void OnEntityAddLife(Entity entity, float damage)
    {
        throw new NotImplementedException();
    }

    public virtual void OnSendEntityInfo(Entity entity)
    {
        throw new NotImplementedException();
    }
}
