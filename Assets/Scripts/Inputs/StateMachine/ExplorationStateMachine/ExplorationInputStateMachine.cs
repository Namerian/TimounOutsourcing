using UnityEngine;
using System.Collections;

namespace StateMachine
{
    public class ExplorationInputStateMachine : InputState
    {
        public InputState _currentState;

        public override void Execute()
        {
            _currentState = _currentState.step();
        }

        void OnEnable()
        {
            ContextManager.instance.explorationStateMachine = this.gameObject;
        }
    }
}

