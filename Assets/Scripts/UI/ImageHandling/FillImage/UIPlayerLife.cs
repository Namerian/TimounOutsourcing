using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Combat;
using System;
using Player;
using DG.Tweening;
using Events;
public class UIPlayerLife : UILife{
    protected override void Awake()
    {
        base.Awake();

    }

    public override void OnEntitySubstractLife(Entity parEntity, float damage)
    {
        if (parEntity.GetComponent<Player.Player>() == entity)
        {
            base.OnEntitySubstractLife(entity, damage);
            entity.GetComponentInChildren<PlayerCombatUI>().Mask();
        }
    }

    public override void OnSendEntityInfo(Entity parEntity)
    {
        if (parEntity.GetComponent<Player.Player>() == entity)
        {
            _textImage.text = parEntity.GetComponent<PlayerLife>().currentLife.ToString();
        }
    }


}
