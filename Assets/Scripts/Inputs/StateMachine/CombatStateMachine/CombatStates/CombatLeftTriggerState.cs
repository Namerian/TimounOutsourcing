using UnityEngine;
using System.Collections;
using Events;
using Combat;
using GameInput;
using System;

namespace StateMachine
{
    public class CombatLeftTriggerState : InputState, 
        InputEvents.IActionHandler, 
        CombatEvents.INewTurnHandler, 
        CombatEvents.ITurnTransitionHandler
    {
        TurnManager.TurnState turnState;
        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        public override void Execute()
        {
            
            //Debug.Log("Left Trigger");

        }

        public void OnAction(InputActionList action, GameInput.InputState state)
        {
            if (!ContextManager.instance.CompareContext(InputContextList.Combat))
            {
                return;
            }
            if (CombatInputStateHandler.currentState == this)
            {
                if (state == GameInput.InputState.Pressed)
                {
                    switch (action)
                    {
                        case InputActionList.UseCharacter01:
                            if (turnState == TurnManager.TurnState.PlayerTurn)
                            {// DIRTY
                                //if(CombatManager.instance.listOfPlayers[0].listOfActions.Count >= 3)
                                //    EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(CombatManager.instance.listOfPlayers[0].listOfActions[2], CombatManager.instance.listOfPlayers[0], CombatManager.instance.listOfMonsters[0]));
                            }
                            else if (turnState == TurnManager.TurnState.Enemyturn)
                            {
                                Debug.Log("Monsterrr");
                            }
                            CombatInputStateHandler._goToStanding = true;
                            break;
                        case InputActionList.UseCharacter02:
                            if (turnState == TurnManager.TurnState.PlayerTurn)
                            {
                                //if (CombatManager.instance.listOfPlayers[1].listOfActions.Count >= 3)
                                //    EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(CombatManager.instance.listOfPlayers[1].listOfActions[2], CombatManager.instance.listOfPlayers[1], CombatManager.instance.listOfMonsters[0]));
                            }
                            else if (turnState == TurnManager.TurnState.Enemyturn)
                            {

                            }
                            CombatInputStateHandler._goToStanding = true;
                            break;
                        case InputActionList.UseCharacter03:
                            if (turnState == TurnManager.TurnState.PlayerTurn)
                            {

                            }
                            else if (turnState == TurnManager.TurnState.Enemyturn)
                            {

                            }
                            CombatInputStateHandler._goToStanding = true;
                            break;
                        case InputActionList.UseCharacter04:
                            if (turnState == TurnManager.TurnState.PlayerTurn)
                            {

                            }
                            else if (turnState == TurnManager.TurnState.Enemyturn)
                            {

                            }
                            CombatInputStateHandler._goToStanding = true;
                            break;
                    }
                }

                if (state == GameInput.InputState.Released)
                {
                    if (InputActionList.AbilityModifier == action)
                    {
                        CombatInputStateHandler._goToStanding = true;
                    }
                }

                if (state == GameInput.InputState.Hold)
                {
                    if (InputActionList.AbilityModifier == action)
                    {
                        CombatInputStateHandler._goToStanding = false;
                    }
                }
            }
            
        }

        public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
        {
            turnState = state;
        }

        public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
        {
            turnState = currentState;
        }
    }
}

