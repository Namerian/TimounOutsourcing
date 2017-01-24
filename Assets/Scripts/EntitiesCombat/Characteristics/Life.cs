using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using System.Linq;

public class Life : MonoBehaviour,
    CombatEvents.IEntityIsOutOfLife
{

    public enum LifeState
    {
        OutOfLife,
        LowLife,
        Normal,
        Full,
    }

    public LifeState lifeState;

    public float maxLife;
    public float currentLife;
    public Entity lifeEntity;
    public float lowLifeThreshold;

    public float knockbackDuration = 0.2f;

    protected virtual void Awake()
    {
        EventCenter.AddSubscriber(this);
        currentLife = maxLife;
        lifeState = LifeState.Full;
    }

    public void AddLife(float amount)
    {
        float lowLife = maxLife * lowLifeThreshold / 100;
        currentLife += amount;
        currentLife = Mathf.Min(currentLife, maxLife);
        EventCenter.FireEvent<CombatEvents.IEntityAddLife>((handler) => handler.OnEntityAddLife(lifeEntity, amount));
        if (currentLife >= maxLife)
        {
            lifeState = LifeState.Full;
            EventCenter.FireEvent<CombatEvents.IEntityIsFullOnLife>((handler) => handler.OnEntityIsFullOnLife(lifeEntity));
        }

        if(currentLife < maxLife && currentLife > lowLife)
        {
            lifeState = LifeState.Normal;
            EventCenter.FireEvent<CombatEvents.IEntityIsNormalOnLife>((handler) => handler.OnEntityIsNormalOnLife(lifeEntity));
        }
    }

    public virtual void SubstractLife(float amount)
    {
        float lowLife = maxLife * lowLifeThreshold/100;
        currentLife -= amount;
        currentLife = Mathf.Max(0, currentLife);
        EventCenter.FireEvent<CombatEvents.IEntitySubstractLife>((handler) => handler.OnEntitySubstractLife(lifeEntity, amount));

        this.GetComponent<Entity>().entityStance = Entity.EntityStance.KNOCKBACK;

        StartCoroutine(WaitForKnockback(knockbackDuration));

        if (currentLife < maxLife && currentLife > lowLife)
        {
            lifeState = LifeState.Normal;
            EventCenter.FireEvent<CombatEvents.IEntityIsNormalOnLife>((handler) => handler.OnEntityIsNormalOnLife(lifeEntity));
        }

        if(currentLife <= lowLife && currentLife > 0)
        {
            lifeState = LifeState.LowLife;
            EventCenter.FireEvent<CombatEvents.IEntityIsLowOnLife>((handler) => handler.OnEntityIsLowOnLife(lifeEntity));
        }

        if (currentLife <= 0)
        {
            if(lifeState != LifeState.OutOfLife)
            {
                lifeState = LifeState.OutOfLife;
                EventCenter.FireEvent<CombatEvents.IEntityIsOutOfLife>((handler) => handler.OnEntityIsOutOfLife(lifeEntity));
                bool alltrue = CombatManager.instance.listOfPlayers.TrueForAll(b => b.GetComponent<Life>().currentLife <= 0);

                if (alltrue)
                {
                    ContextManager.instance.ChangeContext(GameInput.InputContextList.Exploration);
                    EventCenter.FireEvent<CombatEvents.iPlayerLost>((handler) => handler.OnPlayerLost());
                }
            }
        }
    }

    private IEnumerator WaitForKnockback(float knockbackDuration)
    {
        while (true)
        {
            yield return new WaitForSeconds(knockbackDuration);

            this.GetComponent<Entity>().entityStance = Entity.EntityStance.NONE;

            StopAllCoroutines();
           
        }
    }

    public void OnEntityIsOutOfLife(Entity entity)
    {
        //UnityEditor.EditorApplication.isPaused = true;
    }
}
