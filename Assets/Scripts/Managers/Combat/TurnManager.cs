using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Events;
using Combat;
using System;
using System.Linq;
using GameInput;

namespace Combat
{
    public class TurnManager : MonoBehaviour,
        InputEvents.IActionHandler,
        CombatEvents.IComboBrokenHandler,
        CombatEvents.IEndTurnHandler,
        CombatEvents.IInitCombatHandler,
        CombatEvents.IEntityIsOutOfStamina
    {
        public enum TurnState
        {
            Nobody,
            PlayerTurn,
            Enemyturn
        }

        public TurnState currentTurnState;

        public float enemyTurnDuration;
        public float playerTurnDuration;
        public float playerEndTurnFeedBack;
        public float timeBetweenTurns;

        private float _currentTimeTurn;
        private bool _isChangingTurn;
        public static bool hasStartedTurn;
        private TurnState _previousTurnState;

        private static TurnManager instance;

        public static TurnManager Instance()
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(TurnManager)) as TurnManager;
                if (!instance)
                {
                    Debug.LogError("There needs to be one active TurnManager script on a GameObject in your scene");
                }
            }
            return instance;
        }


        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        void Start()
        {
            //EventCenter.FireEvent<CombatEvents.ICombatEnterHandler>((handler) => handler.OnCombatEnter());
            
        }

        void Update()
        {
            
        }

        void ChangeTurn()
        {
            _isChangingTurn = false;
            if (_previousTurnState == TurnState.PlayerTurn)
            {
                NewTurn(TurnState.Enemyturn, enemyTurnDuration);
            }
            else if (_previousTurnState == TurnState.Enemyturn)
            {
                NewTurn(TurnState.PlayerTurn, playerTurnDuration);
            }
        }

        void NewTurn(TurnState state, float turnDuration)
        {
            ChangeTurnState(state);
            EventCenter.FireEvent<CombatEvents.INewTurnHandler>((handler) => handler.OnNewTurn(currentTurnState, turnDuration));
            hasStartedTurn = false;
            _previousTurnState = state;
        }

        IEnumerator WaitBetweenTurns(float duration)
        {
            EventCenter.FireEvent<CombatEvents.ITurnTransitionHandler>((handler) => handler.OnTurnTransition(currentTurnState, TurnState.Nobody, duration));
            ChangeTurnState(TurnState.Nobody);
            _isChangingTurn = true;
            yield return new WaitForSeconds(duration);
            ChangeTurn();
        }

        void ChangeTurnState(TurnState state)
        {
            currentTurnState = state;
            
        }

        void StartTurn()
        {
            EventCenter.FireEvent<CombatEvents.IStartTurnHandler>((handler) => handler.OnStartTurn(currentTurnState));
            hasStartedTurn = true;
            
        }


        
        public void OnAction(InputActionList action, InputState state)
        {
            if (state == InputState.Pressed && !hasStartedTurn)
            {
                switch (action)
                {
                    case InputActionList.UseCharacter01:
                        if (CombatManager.instance.listOfPlayers[0].lifeScript.lifeState == Life.LifeState.OutOfLife)
                            break;
                        StartTurn();
                        break;
                    case InputActionList.UseCharacter02:
                        if (CombatManager.instance.listOfPlayers[1].lifeScript.lifeState == Life.LifeState.OutOfLife)
                            break;
                        StartTurn();
                        break;
                    case InputActionList.UseCharacter03:
                        if (CombatManager.instance.listOfPlayers[2].lifeScript.lifeState == Life.LifeState.OutOfLife)
                            break;
                        StartTurn();
                        break;
                    case InputActionList.UseCharacter04:
                        if (CombatManager.instance.listOfPlayers[3].lifeScript.lifeState == Life.LifeState.OutOfLife)
                            break;
                        StartTurn();
                        break;
                }
            }
        }

        public void OnEndTurn(TurnManager.TurnState currentState)
        {
            if (hasStartedTurn)
            {
                StartCoroutine(WaitBetweenTurns(timeBetweenTurns));
            }
        }

        public void OnComboBroken()
        {
            if (TurnState.PlayerTurn == currentTurnState)
            {
                OnEndTurn(currentTurnState);
            }
        }

        public void OnInitCombat()
        {
            NewTurn(TurnState.PlayerTurn, playerTurnDuration);
        }

        public void OnEntityIsOutOfStamina(Entity parEntity)
        {
            
            if (TurnState.PlayerTurn == currentTurnState)
            {

                //Debug.Log("Checking stamina");

                List<bool> ArePlayersOutOfStamina = new List<bool>();

                foreach (Player.Player player in CombatManager.instance.listOfPlayers)
                {
                    if (player.GetComponent<PlayerStamina>().staminaState != Stamina.StaminaState.OutOfStamina)
                    {
                        //Debug.Log("Someone has some stamina");
                        return;
                    }
                }

                //Debug.Log("No one has stamina");
                OnEndTurn(currentTurnState);
            }
        }


    }
}

