using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Events;
using Combat;
using Player;
using GameInput;
public class PlayerInput : MonoBehaviour,
    CombatEvents.IInputPressedHandler,
    CombatEvents.IInputUnPressedHandler,
    CombatEvents.INewTurnHandler,
    CombatEvents.ITurnTransitionHandler
{

    public static PlayerInput instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        EventCenter.AddSubscriber(this);
    }

    List<Player.Player> playerList = new List<Player.Player>();

    public bool inputCoolDownIsReady;
    public bool inputGuard;
    public TurnManager.TurnState turnState;
    bool _isHoldingRightTrigger = false;

    // Use this for initialization
    void Start () {
        playerList = CombatManager.instance.listOfPlayers;
        inputCoolDownIsReady = true;
        inputGuard = false;
    }

    public void OnInputPressed(KeyCode keyCode)
    {
        /*if(player.staminaScript.staminaState != Stamina.StaminaState.OutOfStamina)
        {
            if (inputCoolDownIsReady && turnState == TurnManager.TurnState.PlayerTurn)
            {
                if (keyCode == simpleAttack)
                {
                    EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(player.listOfActions[0], player, CombatManager.instance.listOfMonsters[0]));
                }

                if(keyCode == secondAttack)
                {
                    EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(player.listOfActions[1], player, CombatManager.instance.listOfMonsters[1]));
                }
            }
            else if (turnState == TurnManager.TurnState.Enemyturn)
            {
                if (keyCode == guard)
                {
                    EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(player.listOfActions[1], player, null));
                }
            }
        }*/
    }

    public void OnInputUnPressed(KeyCode keyCode)
    {
        if (turnState == TurnManager.TurnState.Enemyturn)
        {
            /*if (keyCode == guard)
            {
                EventCenter.FireEvent<CombatEvents.IEndGuardHandler>((handler) => handler.OnEndGuard(player));
            }*/
        }
    }

    public void OnAction(InputActionList action, InputState state)
    {
        if (state == InputState.Pressed)
        {
            switch (action)
            {
                
                case InputActionList.UseCharacter01:
                    if (_isHoldingRightTrigger)
                    {
                        Debug.Log("mega attack");
                    }
                    else
                    {
                        Debug.Log("noob attack");
                    }
                    break;
                case InputActionList.UseCharacter02:
                    break;
                case InputActionList.UseCharacter03:
                    break;
                case InputActionList.UseCharacter04:
                    break;
                case InputActionList.AttackModifier:
                    _isHoldingRightTrigger = true;
                    break;
                default:

                    break;
            }
        }

        

        if (state == InputState.Released)
        {
            switch (action)
            {/*
                case InputActionList.UseCharacter01:
                    if (turnState == TurnManager.TurnState.Enemyturn)
                        EventCenter.FireEvent<CombatEvents.IEndGuardHandler>((handler) => handler.OnEndGuard(playerList[0]));

                    break;
                case InputActionList.UseCharacter02:
                    if (turnState == TurnManager.TurnState.Enemyturn)
                        EventCenter.FireEvent<CombatEvents.IEndGuardHandler>((handler) => handler.OnEndGuard(playerList[1]));
                    break;
                case InputActionList.UseCharacter03:
                    if (turnState == TurnManager.TurnState.Enemyturn)
                        EventCenter.FireEvent<CombatEvents.IEndGuardHandler>((handler) => handler.OnEndGuard(playerList[2]));
                    break;
                case InputActionList.UseCharacter04:
                    if (turnState == TurnManager.TurnState.Enemyturn)
                        //EventCenter.FireEvent<CombatEvents.IEndGuardHandler>((handler) => handler.OnEndGuard(playerList[3]));
                    break;*/
                case InputActionList.AttackModifier:
                    _isHoldingRightTrigger = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        inputCoolDownIsReady = true;
        turnState = state;
    }

    public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
    {
        turnState = currentState;
    }
}
