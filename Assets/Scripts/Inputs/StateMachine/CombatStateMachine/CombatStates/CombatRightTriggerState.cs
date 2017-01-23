using UnityEngine;
using System.Collections;
using GameInput;
using Events;
using System;
using Combat;
namespace StateMachine
{
    public class CombatRightTriggerState : InputState,
        InputEvents.IActionHandler, 
        CombatEvents.ITurnTransitionHandler,
        CombatEvents.INewTurnHandler
    {
        TurnManager.TurnState turnState;

        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        public override void Execute()
        {
            //Debug.Log("RightTrigger");
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
                            {
                                Debug.Log("playerrrr");
                            }
                            else if (turnState == TurnManager.TurnState.Enemyturn)
                            {

                            }
                            CombatInputStateHandler._goToStanding = true;
                            break;
                        case InputActionList.UseCharacter02:
                            if (turnState == TurnManager.TurnState.PlayerTurn)
                            {

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
                    if (InputActionList.AttackModifier == action)
                    {
                        CombatInputStateHandler._goToStanding = true;
                    }
                }

                if (state == GameInput.InputState.Hold)
                {
                    if (InputActionList.AttackModifier == action)
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

