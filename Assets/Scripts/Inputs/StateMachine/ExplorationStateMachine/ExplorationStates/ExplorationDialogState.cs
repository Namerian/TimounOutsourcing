using UnityEngine;
using System.Collections;
using GameInput;
using System;
using Events;
using Exploration;
namespace StateMachine
{
    public class ExplorationDialogState : InputState,
    InputEvents.IActionHandler
    {
        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        public override void Execute()
        {
            //CombatInputStateHandler._goToStanding = false;
        }

        public void OnAction(InputActionList action, GameInput.InputState state)
        {
            if (!ContextManager.instance.CompareContext(InputContextList.Exploration))
            {
                return;
            }
        }

        
    }
}
