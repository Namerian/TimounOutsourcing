using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

namespace Combat
{
    public class RhythmManager : MonoBehaviour,
        //CombatEvents.ICheckTimerRhythmHandler,
        //CombatEvents.INewTurnHandler,
        //CombatEvents.IComboBrokenHandler,
        CombatEvents.ITurnTransitionHandler,
        CombatEvents.IInitCombatHandler,
        //CombatEvents.IUpdateRhythmHandler,
        //CombatEvents.IPauseRhythmHandler,
        //CombatEvents.IResumeRhythmHandler,
        CombatEvents.IStartTurnHandler,
        CombatEvents.IEndTurnHandler
    {

        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        public float currentTimeRhythm;
        TurnManager.TurnState currentTurn;

        public float currentTimeWithoutHit;
        public float TimeAllowedWithoutHit;

        bool pause;
        bool startTurn;

        public RhythmState rhythmState;
        public enum RhythmState
        {
            Bad,
            Perfect,
            
        }

        void Update()
        {
            /****** Time Without hit ******/
            
            if (currentTurn == TurnManager.TurnState.PlayerTurn && !pause && startTurn)
            {
                if (currentTimeWithoutHit < TimeAllowedWithoutHit)
                {
                    currentTimeWithoutHit += Time.deltaTime;
                }
                else
                {
                    // Turn monster
                    //EventCenter.FireEvent<CombatEvents.IComboBrokenHandler>((handler) => handler.OnComboBroken());
                }
            }
            /******************************/
        }

        IEnumerator UpdateRhythmState(float maxTime, float perfectPercent)
        {
            currentTimeRhythm = 0;
            while (currentTimeRhythm < maxTime)
            {
                yield return new WaitForEndOfFrame();
                currentTimeRhythm += Time.deltaTime;
                ChangeState(maxTime, perfectPercent);
            }
            rhythmState = RhythmState.Bad;
        }

        void ChangeState(float maxTime, float percent)
        {
            if(currentTimeRhythm >= maxTime - (maxTime * percent /100f))
            {
                rhythmState = RhythmState.Perfect;
            }else
            {
                rhythmState = RhythmState.Bad;
            }
        }


        public void OnUpdateRhythm(EntityAction parAction, Entity parTarget)
        {
            StopAllCoroutines();
            StartCoroutine(UpdateRhythmState(parAction.maxTime, parAction.perfectPercent));
        }

        public void OnCheckTimerRhythm(EntityAction action, Entity parOwner = null, Entity parTarget = null)
        {
            currentTimeWithoutHit = 0f;

            //EventCenter.FireEvent<CombatEvents.ICurrentRhythmHandler>((handler) => handler.OnCurrentRhythm(rhythmState, action, parOwner));
            
        }

        public void OnComboBroken()
        {
            currentTimeWithoutHit = 0f;
            rhythmState = RhythmState.Bad;
            currentTimeRhythm = 0;
        }

        public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
        {
            currentTurn = state;
        }

        public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
        {
            currentTurn = currentState;
        }

        public void OnPauseRhythm()
        {
            pause = true;
        }

        public void OnResumeRhythm()
        {
            pause = false;
            currentTimeWithoutHit = 0f;
        }

        public void OnInitCombat()
        {
            pause = false;
            currentTimeWithoutHit = 0f;
            startTurn = false;
        }

        public void OnStartTurn(TurnManager.TurnState currentState)
        {
            if(currentState == TurnManager.TurnState.PlayerTurn)
            {
                startTurn = true;
            }
        }

        public void OnEndTurn(TurnManager.TurnState currentState)
        {
            startTurn = false;
        }

        
    }
}

