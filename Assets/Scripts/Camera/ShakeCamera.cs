using UnityEngine;
using System.Collections;
using DG.Tweening;
using Events;
using Combat;
using System;

public class ShakeCamera : MonoBehaviour, CombatEvents.IEntitySubstractLife {

    public float shakeDuration;
    public float shakeStrength;
    public int shakeNbVibrato;
    public float shakeRandomness;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    public void Shake(float duration, float strength, int vibrato, float randomness)
    {
        this.transform.DOShakePosition(duration, strength, vibrato, randomness);
    }

    public void OnEntitySubstractLife(Entity entity, float damage)
    {
        if (entity.GetComponent<Player.Player>())
        {
            Shake(shakeDuration, shakeStrength, shakeNbVibrato, shakeRandomness);
        }
    }
}
