using UnityEngine;
using System.Collections;
using StateMachine;
using Combat;
using Events;
using System;
using GameInput;

public class CombatInputStateHandler : MonoBehaviour,
    CombatEvents.INewTurnHandler,
    CombatEvents.ITurnTransitionHandler,
    InputEvents.IActionHandler
{

    CombatInputStateMachine inputStateMachine;

    CombatDefaultState _defaultState;
    CombatLeftTriggerState _leftTriggerState;
    CombatRightTriggerState _rightTriggerState;
    
    InputTransition _standingToTLeft;
    InputTransition _standingToTRight;
    
    InputTransition _tLeftToStanding;
    InputTransition _tRightToStanding;

    /**************/
    TurnManager.TurnState _currentTurnState;
    InputActionList action;
    GameInput.InputState actionState;
    public bool _isHoldingRightTrigger = false;
    public bool _isHoldingLeftTrigger = false;
    public bool _isNormal = false;

    public static StateMachine.InputState currentState;
    public static bool _goToStanding;
    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Start()
    {
        inputStateMachine = this.gameObject.AddComponent<CombatInputStateMachine>();
        _defaultState = this.gameObject.AddComponent<CombatDefaultState>();
        
        _leftTriggerState = this.gameObject.AddComponent<CombatLeftTriggerState>();
        _rightTriggerState = this.gameObject.AddComponent<CombatRightTriggerState>();

        inputStateMachine._currentState = _defaultState;
       

        _standingToTLeft = this.gameObject.AddComponent<InputTransition>().SetInputTransition(IsLeftTrigger, _leftTriggerState);
        _defaultState._listOfTransitions.Add(_standingToTLeft);

        _standingToTRight = this.gameObject.AddComponent<InputTransition>().SetInputTransition(IsRightTrigger, _rightTriggerState);
        _defaultState._listOfTransitions.Add(_standingToTRight);

        _tLeftToStanding = this.gameObject.AddComponent<InputTransition>().SetInputTransition(GoToStanding, _defaultState);
        _leftTriggerState._listOfTransitions.Add(_tLeftToStanding);

        _tRightToStanding = this.gameObject.AddComponent<InputTransition>().SetInputTransition(GoToStanding, _defaultState);
        _rightTriggerState._listOfTransitions.Add(_tRightToStanding);
    }

    void Update()
    {
        currentState = inputStateMachine._currentState;
        inputStateMachine.Execute();
    }

    bool IsNormalAttack()
    {
        return _isNormal && (!_isHoldingLeftTrigger && !_isHoldingRightTrigger);
    }

    bool IsRightTrigger()
    {
        return _isHoldingRightTrigger;
    }

    bool IsLeftTrigger()
    {
        return _isHoldingLeftTrigger;
    }

    bool GoToStanding()
    {
        return _goToStanding;
    }
    /******************************************/
    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        _currentTurnState = state;
    }

    public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
    {
        _currentTurnState = currentState;
    }

    public void OnAction(InputActionList action, GameInput.InputState state)
    {
        if (!ContextManager.instance.CompareContext(InputContextList.Combat))
        {
            return;
        }

        if (state == GameInput.InputState.Pressed)
        {
            if(action == InputActionList.AttackModifier)
            {
                _isHoldingRightTrigger = true;
            }
            else if(action == InputActionList.AbilityModifier)
            {
                _isHoldingLeftTrigger = true;
            }
            else
            {
                _isNormal = true;
            }
        }

        if (state == GameInput.InputState.Released)
        {
            if (action == InputActionList.AttackModifier)
            {
                _isHoldingRightTrigger = false;
            }
            else if (action == InputActionList.AbilityModifier)
            {
                _isHoldingLeftTrigger = false;
            }
            else
            {
                _isNormal = false;
            }
        }

        if (state == GameInput.InputState.Hold)
        {
            if (action == InputActionList.AttackModifier)
            {
                _isHoldingRightTrigger = true;
            }
            else if (action == InputActionList.AbilityModifier)
            {
                _isHoldingLeftTrigger = true;
            }
            else
            {
                _isNormal = true;
            }
        }
    }
}
