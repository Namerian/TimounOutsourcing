using UnityEngine;
using System.Collections;
using Events;
using Combat;
using Player;
using System;

[RequireComponent(typeof(Player.Player))]
public class PlayerStamina : Stamina,
    CombatEvents.IInitCombatHandler,
    CombatEvents.IEntityIsOutOfStamina,
    CombatEvents.INewTurnHandler,
    CombatEvents.IStartTurnHandler

    {

    public bool canRegen;

    [SerializeField]
    [Range(0, 100)]
    private float endOfTurnRegen = 30;

    protected override void Awake()
    {
        base.Awake();
        _entityStamina = this.GetComponent<Player.Player>();
        EventCenter.AddSubscriber(this);
    }
    

    IEnumerator RegenStamina()
    {
        while (canRegen)
        {
            yield return new WaitForSeconds(staminaRegenerationDelay);
            AddStamina(staminaRegenerationRate);
        }
    }

    public void OnInitCombat()
    {
        //canRegen = true;
        //StartCoroutine(RegenStamina());
    }

    public void OnEntityIsOutOfStamina(Entity parEntity)
    {
        if(parEntity == this._entityStamina)
        {
            //Debug.Log(_entityStamina.entityName);
            StopAllCoroutines();
            canRegen = false;
        }
    }

    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        if (state == TurnManager.TurnState.PlayerTurn)
        {
            canRegen = false;
            StopAllCoroutines();

        }
        else if (state == TurnManager.TurnState.Enemyturn)
        {
            AddStamina(entityStaminaMax);

            canRegen = true;

            StopAllCoroutines();

            StartCoroutine(RegenStamina());

        }

    }

    public void OnStartTurn(TurnManager.TurnState currentState)
    {
        
        if (currentState == TurnManager.TurnState.PlayerTurn)
        {
            if (this._entityStamina.staminaScript.isOutOfStamina)
                return;
            else
            {
                canRegen = true;
                StopAllCoroutines();
                StartCoroutine(RegenStamina());
            }

        }
        
    }
}
