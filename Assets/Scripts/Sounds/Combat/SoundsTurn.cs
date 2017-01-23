using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;

public class SoundsTurn : MonoBehaviour, CombatEvents.INewTurnHandler, CombatEvents.ITurnTransitionHandler {
    private SFXManager _SFXManager;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Start()
    {
        _SFXManager = SFXManager.instance;
    }

    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        if (state == TurnManager.TurnState.PlayerTurn)
        {
            _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Turn_Start), false);
        }
    }

    public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
    {
        if (prevState == TurnManager.TurnState.PlayerTurn)
        {
            _SFXManager.PlaySingle(Camera.main.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Turn_End), false);
        }
    }
}
