using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameInput;
using System;
using Combat;
using Events;

namespace StateMachine
{
    public class CombatDefaultState : InputState,
        InputEvents.IActionHandler,
        CombatEvents.INewTurnHandler,
        CombatEvents.ITurnTransitionHandler
    {
        TurnManager.TurnState turnState;

        public List<CustomActionList.Action>  currentAttackSequence = new List<CustomActionList.Action>();

        private CustomActionList.Action currentAction;

        private Entity currentOwner;

        private Entity currentTarget;


        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        public override void Execute()
        {
            CombatInputStateHandler._goToStanding = false;
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
                    if ( turnState == TurnManager.TurnState.Enemyturn)
                    {
                        switch (action)
                        {
                            case InputActionList.UseCharacter01:
                                //EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(CombatManager.instance.listOfPlayers[0].listOfActions[1], CombatManager.instance.listOfPlayers[0], CombatManager.instance.listOfMonsters[0]));
                                break;
                            case InputActionList.UseCharacter02:
                                //EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(CombatManager.instance.listOfPlayers[1].listOfActions[1], CombatManager.instance.listOfPlayers[1], CombatManager.instance.listOfMonsters[0]));
                                break;
                                /*
                            case InputActionList.UseCharacter03:
                                Debug.LogWarning("Character03 ain't configured");
                                break;
                            case InputActionList.UseCharacter04:
                                Debug.LogWarning("Character03 ain't configured");
                                break;*/
                        }
                    }

                    else if (turnState == TurnManager.TurnState.PlayerTurn)
                    {
                        currentOwner = null;

                        switch (action)
                        {
                            // Character Selection for base attacks
                            case InputActionList.UseCharacter01:
                                currentOwner = CombatManager.instance.listOfPlayers[0];// Dirty ? should maybe replaced my some kind of mapping system
                                break;
                            case InputActionList.UseCharacter02:
                                currentOwner = CombatManager.instance.listOfPlayers[1];
                                break;
                        }


                        if (currentOwner != null)
                        {
                            // Target Selection, Dirty, should be replaced by proper Monster targeting system
                            currentTarget = CombatManager.instance.listOfMonsters[0];
                            Debug.Log(currentOwner);
                            // Action Selection
                            currentAction = null;

                            //currentAttackSequence needs to be cleared when a timing isn't held, should work fine here then. Maybe also push if it's a critical hit or not.
                            /*if (TimingActionManager.instance.CheckTiming() == TimingActionManager.TimingState.Bad)
                            {
                                currentAttackSequence.Clear();
                            }*/

                            currentAction = selectAttackFromSequence(currentOwner, currentAttackSequence);

                            if (currentAction == null)
                                Debug.LogError("no Action selected");
                            else
                                EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(currentAction, currentOwner, currentTarget));
                        }
                        
                    }

                    
                }
                else if (state == GameInput.InputState.Hold)
                {
                    if (turnState == TurnManager.TurnState.Enemyturn)
                    {
                        switch (action)
                        {
                            case InputActionList.UseCharacter01:
                                EventCenter.FireEvent<CombatEvents.IKeepGuardHandler>((handler) => handler.OnKeepGuard(CombatManager.instance.listOfPlayers[0]));
                                break;
                            case InputActionList.UseCharacter02:
                                EventCenter.FireEvent<CombatEvents.IKeepGuardHandler>((handler) => handler.OnKeepGuard(CombatManager.instance.listOfPlayers[1]));
                                break;
                                /*
                            case InputActionList.UseCharacter03:
                                Debug.LogWarning("Character03 ain't configured");
                                break;
                            case InputActionList.UseCharacter04:
                                Debug.LogWarning("Character03 ain't configured");
                                break;
                                */
                        }
                    }
                }
                else if (state == GameInput.InputState.Released)
                {
                    if (turnState == TurnManager.TurnState.PlayerTurn && currentAction != null)
                    {
                        if(currentAction.isCasting)
                        {
                            switch (action)
                            {
                                // Character Selection for base attacks
                                case InputActionList.UseCharacter01:
                                    if (currentOwner == CombatManager.instance.listOfPlayers[0])
                                        currentOwner = CombatManager.instance.listOfPlayers[0];// Dirty ? should maybe replaced my some kind of mapping system
                                    break;
                                case InputActionList.UseCharacter02:
                                    if (currentOwner == CombatManager.instance.listOfPlayers[1])
                                        currentOwner = CombatManager.instance.listOfPlayers[1];
                                    break;
                            }

                            if (currentOwner != null)
                            {
                                EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(currentAction, currentOwner, currentTarget));
                            }
                        }
                        
                        
                    }

                    currentAction = null;
                    currentOwner = null;
                    currentTarget = null;
                }
            }
        }

        private CustomActionList.Action selectAttackFromSequence(Entity _owner, List<CustomActionList.Action> attackSequence)
        {
            CustomActionList.Action result = null;
            
            //Choose action TBD
            // Compare to ChainAttackList script to see if Sequence exists
            result = CompareSequences(_owner, attackSequence);
            currentAttackSequence.Add(result);

            Debug.Log(result.name);
            return result;
        }

        CustomActionList.Action CompareSequences(Entity _owner, List<CustomActionList.Action> attackSequence)
        {
            List<CustomSequenceList.ListSequences> tempListOfsequences = CustomSequenceList.instance.listOfSequences;
            
            for (int i = 0; i < tempListOfsequences.Count; i++)
            {
                if(tempListOfsequences[i].sequences.Count >= attackSequence.Count)
                {
                    for (int j = attackSequence.Count; j < tempListOfsequences[i].sequences.Count; j++)
                    {
                        if (tempListOfsequences[i].sequences[j].owner == _owner.owner && CheckWithCurrentSequence(tempListOfsequences[i], attackSequence))
                        {
                            return CustomSequenceList.instance.SelectAction(_owner.owner, tempListOfsequences[i].sequences[j].currentActionName);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
            }
            attackSequence.Clear();
            return CompareSequences(_owner, attackSequence);
        }

        bool CheckWithCurrentSequence(CustomSequenceList.ListSequences currentSequence, List<CustomActionList.Action> attackSequence)
        {
            for(int i = 0; i < attackSequence.Count; i++)
            {
                if(currentSequence.sequences[i].currentActionName != attackSequence[i].name)
                {
                    return false;
                }
            }
            return true;
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

