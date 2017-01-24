using UnityEngine;
using System.Collections;
using Exploration;
using Events;
using GameInput;
using System;
using StateMachine;
public class ExplorationInputStateHandler : MonoBehaviour, 
    InputEvents.IActionHandler,
    ExplorationEvents.IDialogEndHandler,
    ExplorationEvents.IDialogEnterHandler,
    ExplorationEvents.IExplorationEndHandler,
    ExplorationEvents.IExplorationEnterHandler
{

    ExplorationInputStateMachine inputStateMachine;
    ExplorationDefaultState _defaultState;
    ExplorationDialogState _dialogState;

    InputTransition _defaultToDialog;
    InputTransition _dialogtoDefault;

    InputActionList action;
    GameInput.InputState actionState;

    public static StateMachine.InputState currentState;
    public static bool _goToDefault;

    public bool isDialog;
    public bool isDefault;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Start()
    {
        inputStateMachine = this.gameObject.AddComponent<ExplorationInputStateMachine>();

        _defaultState = this.gameObject.AddComponent<ExplorationDefaultState>();
        _dialogState = this.gameObject.AddComponent<ExplorationDialogState>();

        inputStateMachine._currentState = _defaultState;

        _defaultToDialog = this.gameObject.AddComponent<InputTransition>().SetInputTransition(IsDialog, _dialogState);
        _defaultState._listOfTransitions.Add(_defaultToDialog);


        _dialogtoDefault = this.gameObject.AddComponent<InputTransition>().SetInputTransition(IsDefault, _defaultState);
        _dialogState._listOfTransitions.Add(_dialogtoDefault);
    }

    void Update()
    {
        currentState = inputStateMachine._currentState;
        if(ContextManager.instance.CompareContext(InputContextList.Exploration) || ContextManager.instance.CompareContext(InputContextList.Dialogue))
        {
            inputStateMachine.Execute();
        }
            
    }

    bool IsDefault()
    {
        return isDefault;
    }

    bool IsDialog()
    {
        return isDialog;
    }

    public void OnAction(InputActionList action, GameInput.InputState state)
    {
        if (!ContextManager.instance.CompareContext(InputContextList.Exploration))
        {
            return;
        }
    }

    public void OnDialogEnd()
    {
        isDialog = false;
    }

    public void OnDialogEnter()
    {
        isDialog = true;
    }

    public void OnExplorationEnd()
    {
        isDefault = false;
    }

    public void OnExplorationEnter()
    {
        isDefault = true;
    }


}
