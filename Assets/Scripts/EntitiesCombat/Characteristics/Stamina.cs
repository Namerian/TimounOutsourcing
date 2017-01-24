using UnityEngine;
using System.Collections;
using Events;
using Combat;
public class Stamina : MonoBehaviour {

    public enum StaminaState
    {
        OutOfStamina,
        LowStamina,
        Normal,
        Full
    }

    public StaminaState staminaState;

    public float entityStaminaMax;

    public float staminaRegenerationRate;
    public float staminaRegenerationDelay;

    public float entityStaminaCurrent;

    [Range(0,100)]
    public float lowStaminaThreshold;

    protected Entity _entityStamina;

    public bool isOutOfStamina;

    protected virtual void Awake()
    {
        entityStaminaCurrent = entityStaminaMax;
        staminaState = StaminaState.Full;
        isOutOfStamina = false;
    }

    public void AddStamina(float amount)
    {
        float lowStamina = entityStaminaMax * lowStaminaThreshold / 100;
        entityStaminaCurrent += amount;
        entityStaminaCurrent = Mathf.Min(entityStaminaCurrent, entityStaminaMax);
        EventCenter.FireEvent<CombatEvents.IEntityAddStamina>((handler) => handler.OnEntityAddStamina(_entityStamina, amount));

        if (entityStaminaCurrent >= entityStaminaMax)
        {
            staminaState = StaminaState.Full;
            isOutOfStamina = false;
            EventCenter.FireEvent<CombatEvents.IEntityIsFullOfStamina>((handler) => handler.OnEntityIsFullOfStamina(_entityStamina));

        }
        else if(entityStaminaCurrent > lowStamina && entityStaminaCurrent < entityStaminaMax)
        {
            staminaState = StaminaState.Normal;
            EventCenter.FireEvent<CombatEvents.IEntityIsNormalOnStamina>((handler) => handler.OnIEntityIsNormalOnStamina(_entityStamina));
        }
        else if (entityStaminaCurrent <= lowStamina && entityStaminaCurrent > 0)
        {
            staminaState = StaminaState.LowStamina;
            EventCenter.FireEvent<CombatEvents.IEntityIsLowOnStamina>((handler) => handler.OnEntityIsLowOnStamina(_entityStamina));
        }
    }

    public void SubstractStamina(float amount)
    {
        
        float lowStamina = entityStaminaMax * lowStaminaThreshold / 100;
        entityStaminaCurrent -= amount;
        entityStaminaCurrent = Mathf.Max(0, entityStaminaCurrent);

        EventCenter.FireEvent<CombatEvents.IEntitySubstractStamina>((handler) => handler.OnEntitySubstractStamina(_entityStamina, amount));
        if (entityStaminaCurrent <= 0)
        {
            staminaState = StaminaState.OutOfStamina;
            isOutOfStamina = true;
            EventCenter.FireEvent<CombatEvents.IEntityIsOutOfStamina>((handler) => handler.OnEntityIsOutOfStamina(_entityStamina));
            
        }

        if (entityStaminaCurrent <= lowStamina && entityStaminaCurrent > 0 && !isOutOfStamina)
        {
            staminaState = StaminaState.LowStamina;
            EventCenter.FireEvent<CombatEvents.IEntityIsLowOnStamina>((handler) => handler.OnEntityIsLowOnStamina(_entityStamina));
        }

        if (entityStaminaCurrent > lowStamina && entityStaminaCurrent < entityStaminaMax && !isOutOfStamina)
        {
            staminaState = StaminaState.Normal;
            EventCenter.FireEvent<CombatEvents.IEntityIsNormalOnStamina>((handler) => handler.OnIEntityIsNormalOnStamina(_entityStamina));
        }
    }
}
