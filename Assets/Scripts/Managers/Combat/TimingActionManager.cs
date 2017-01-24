using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using Combat;

public class TimingActionManager : MonoBehaviour,
    CombatEvents.IInitCombatHandler,
    CombatEvents.IResetTimingHandler,
    CombatEvents.IComboBrokenHandler,
    CombatEvents.ITurnTransitionHandler,
    CombatEvents.IResumeTimingHandler,
    CombatEvents.IPauseTimingHandler,
    CombatEvents.IStartTurnHandler,
    CombatEvents.IEndTurnHandler,
    CombatEvents.INewTurnHandler
{

    public static TimingActionManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        EventCenter.AddSubscriber(this);
    }

    public TimingState timingState;
    public enum TimingState
    {
        Bad,
        Good,
        Perfect,

    }

    TurnManager.TurnState currentTurn;


    public float currentTimeWithoutHit;
    public float TimeAllowedWithoutHit;
    public float currentTime = 0f;

    bool pause;
    bool startTurn;

    void Update()
    {
        if (currentTurn == TurnManager.TurnState.PlayerTurn && !pause && startTurn)
        {
            if (currentTimeWithoutHit < TimeAllowedWithoutHit)
            {
                currentTimeWithoutHit += Time.deltaTime;
            }
            else
            {
                // Turn monster
                EventCenter.FireEvent<CombatEvents.IComboBrokenHandler>((handler) => handler.OnComboBroken());
            }
        }
    }

    public void OnResetTiming(EntityAction parAction, Entity parTarget)
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimingState(parAction.maxTime, parAction.goodPercent, parAction.goodPercentStart, parAction.perfectPercent, parAction.perfectPercentStart));
    }

    IEnumerator UpdateTimingState(float maxTime, float goodPercent, float goodPercentStart, float perfectPercent, float perfectPercentStart)
    {
        currentTime = 0;
        while (currentTime < maxTime)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            ChangeState(maxTime, goodPercent, goodPercentStart, perfectPercent, perfectPercentStart);
        }
        timingState = TimingState.Bad;
    }

    void ChangeState(float maxTime, float goodPercent, float goodPercentStart, float perfectPercent, float perfectPercentStart)
    {
        if (currentTime >= (maxTime * perfectPercentStart / 100f) && currentTime <= (maxTime * perfectPercentStart / 100f)+ (maxTime * perfectPercent / 100f))
        {
            timingState = TimingState.Perfect;
        }
        else if (currentTime >= (maxTime * goodPercentStart / 100f) && currentTime <= (maxTime * goodPercentStart / 100f) + (maxTime * goodPercent / 100f))
        {
            timingState = TimingState.Good;
        }
        else
        {
            timingState = TimingState.Bad;
        }
    }

    public TimingState CheckTiming()
    {
        currentTimeWithoutHit = 0f;
        return timingState;
        
    }

    public void OnComboBroken()
    {
        currentTimeWithoutHit = 0f;
        timingState = TimingState.Bad;
        currentTime = 0;
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
        if (currentState == TurnManager.TurnState.PlayerTurn)
        {
            startTurn = true;
        }
    }

    public void OnEndTurn(TurnManager.TurnState currentState)
    {
        startTurn = false;
    }



}
