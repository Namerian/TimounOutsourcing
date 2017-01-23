using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using System.Linq;
using Player;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Monster
{
    public enum targetModes
    {
        Character01 = 0,
        Character02 = 1,
        Character03 = 4,
        Character04 = 3,
        Random = 10
    }

    public class MonsterInput : MonoBehaviour,
    CombatEvents.INewTurnHandler,
    CombatEvents.IEndCoolDownAttackHandler,
    CombatEvents.ITurnTransitionHandler
    {
        TurnManager.TurnState _currentTurn;
        Monster _monster;
        float _currentTime;
        float _turnDuration;
        public bool _canAttack;
        int nbOfattacks = 0;

        [SerializeField]
        private float endOfTurnDelay = 2.5f;

        [SerializeField]
        private int minAttacks = 2;
        [SerializeField]
        private int maxAttacks = 4;

        [HideInInspector]
        public Player.Player target; 

        [SerializeField]
        private targetModes targetMode = targetModes.Random;

        public List<CustomActionList.Action> actionsList = new List<CustomActionList.Action>();

        private int currentAttackIndex = 0;

        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        void Start()
        {
            _monster = GetComponent<Monster>();
        }

        public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
        {
            _currentTurn = state;
            _turnDuration = turnDuration;
            if (_currentTurn == TurnManager.TurnState.Enemyturn)
            {
                _canAttack = true;
                if(_monster.staminaScript.staminaState != Stamina.StaminaState.OutOfStamina)
                {
                    nbOfattacks = UnityEngine.Random.Range(minAttacks, maxAttacks);

                    Invoke("SelectNextAttack", 1.0f);
                }
                else
                {
                    nbOfattacks = 0;
                    EventCenter.FireEvent<CombatEvents.IEndTurnHandler>((handler) => handler.OnEndTurn(TurnManager.Instance().currentTurnState));
                }
            }
        }

        public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
        {
            _currentTurn = currentState;
        }

        void SelectNextAttack()
        {
            if (_canAttack && _monster.IsInCombatZone())
            {
                TurnManager.hasStartedTurn = true;

                if (actionsList.Count <= 0)
                {
                    /**********************************
                        *  Should choose a attack sequence in sequences list, depending of certain conditions. --> should be done from inspector?
                        * 
                        * Conditions like armor, life, stamina state
                        * 
                        * Player Health / Stances
                        * 
                        * minor random --> max between 2 sequences, if same twice in a row, will automatically switch sequence
                        * 
                        *  Returns currentAttackSequence
                        * ******************************/

                    if (GetComponent<Monster>().lifeScript.lifeState == Life.LifeState.LowLife)
                    {
                        //Debug.Log("low life combo");
                        SetActionList("M_Tornado");
                        ExecuteCurrentAction(currentAttackIndex);
                    }
                    else
                    {
                        //Debug.Log("normal combo");
                        SetActionList("M_Tornado");
                        ExecuteCurrentAction(currentAttackIndex);

                    }
                }else
                {
                    if (currentAttackIndex < actionsList.Count)
                    {
                        ExecuteCurrentAction(currentAttackIndex);
                    }
                    else
                    {
                        //if other condition
                        //SetActionList("M_Tornado");
                        //else
                        currentAttackIndex = 0;
                        actionsList.Clear();
                        Invoke("EndTurnEvent", endOfTurnDelay);
                    }


                    //Target might also need some rework to reflect some kind of behavior
                    target = SelectTarget(CombatManager.instance.listOfPlayers);


                    target.GetComponentInChildren<PlayerCombatUI>().Show();
                }
                
            }
            


            /*if (nbOfattacks <= 0  || GetComponent<Monster>().staminaScript.isOutOfStamina)
            {
                Invoke("EndTurnEvent", endOfTurnDelay);
            }*/
        }

        void EndTurnEvent()
        {
            EventCenter.FireEvent<CombatEvents.IEndTurnHandler>((handler) => handler.OnEndTurn(TurnManager.Instance().currentTurnState));
        }

        private Player.Player SelectTarget(List<Player.Player> _listOfPlayers)
        {
            List<Player.Player> tempList = new List<Player.Player>();

            if (_listOfPlayers.Count == 1)
            {
                return _listOfPlayers[0];
            }
            else
            {

                switch (targetMode)
                {
                    //Debug solution to choose target to attack.
#if UNITY_EDITOR
                    case targetModes.Character01:
                        return _listOfPlayers[0];
                    case targetModes.Character02:
                        return _listOfPlayers[1];
                    case targetModes.Character03:
                        return _listOfPlayers[2];
                    case targetModes.Character04:
                        return _listOfPlayers[3];

#endif
                    default:
                        //Debug.Log("Randomly Selecting");
                        for (var i = 0; i < _listOfPlayers.Count; i++)
                        {
                            if (_listOfPlayers[i].lifeScript.lifeState != Life.LifeState.OutOfLife)
                            {
                                tempList.Add(_listOfPlayers[i]);
                                //Debug.Log("Adding Player" + i);
                            }
                        }
                        return tempList[UnityEngine.Random.Range(0, tempList.Count)];
                }   
            }
        }

        public void OnEndCoolDownAttack(EntityAction parAction)
        {
            if(_currentTurn == TurnManager.TurnState.Enemyturn)
            {
                if (_monster.staminaScript.staminaState != Stamina.StaminaState.OutOfStamina)
                {
                    //StartCoroutine("MonsterAttack");
                    //_monster.listOfActions[0].GetComponent<AttackAction>().isReady = true; //quick fix pas beau dégueux baaah DIRTY
                    SelectNextAttack();
                }
                else
                {

                    Debug.LogWarning("Prog should check this.");
                    nbOfattacks = 0;
                    EventCenter.FireEvent<CombatEvents.IEndTurnHandler>((handler) => handler.OnEndTurn(TurnManager.Instance().currentTurnState));
                }
            }
        }

        void SetActionList(string sequenceName)
        {
            actionsList.Clear();
            currentAttackIndex = 0;

            foreach (CustomSequenceList.ListSequences sequence in CustomSequenceList.instance.listOfSequences)
            {
                if(sequence.name == sequenceName)
                {
//#if UNITY_EDITOR
                    CustomActionList tempActionList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Actions/Monster.asset", typeof(CustomActionList)) as CustomActionList;
//#endif
                    for(int i = 0; i < sequence.sequences.Count; i++)
                    {
                        foreach(CustomActionList.Action action in tempActionList.listOfActions)
                        {
                            if(action.name == sequence.sequences[i].currentActionName)
                            {
                                actionsList.Add(action);
                                break;
                            }
                        }
                    }
                    
                }
            }
        }

        void ExecuteCurrentAction(int index)
        {
            EventCenter.FireEvent<CombatEvents.IExecuteAction>((handler) => handler.OnExecuteAction(actionsList[index], _monster, target));
            currentAttackIndex++;
        }
    }
}

