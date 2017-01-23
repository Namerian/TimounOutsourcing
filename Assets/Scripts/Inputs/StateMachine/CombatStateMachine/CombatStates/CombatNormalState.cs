using UnityEngine;
using System.Collections;
using Combat;
using Events;
using GameInput;
using System;

namespace StateMachine
{
    public class CombatNormalState : InputState,
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
            Debug.Log("normal");
        }

        public void OnAction(InputActionList action, GameInput.InputState state)
        {
            if (!ContextManager.instance.CompareContext(InputContextList.Combat))
            {
                return;
            }
            if (state == GameInput.InputState.Pressed)
                {
                        switch (action)
                        {
                            case InputActionList.UseCharacter01:
                                if (turnState == TurnManager.TurnState.PlayerTurn)
                                {
                                    //EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(CombatManager.instance.listOfPlayers[0].listOfActions[0], CombatManager.instance.listOfPlayers[0], CombatManager.instance.listOfMonsters[0]));
                                }
                                else if (turnState == TurnManager.TurnState.Enemyturn)
                                {

                                }
                                //InputStateHandler._goToStanding = true;
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
                    CombatInputStateHandler._goToStanding = true;
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

