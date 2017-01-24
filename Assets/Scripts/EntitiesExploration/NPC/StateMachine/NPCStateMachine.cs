using UnityEngine;
using System.Collections;
namespace StateMachine
{
    public class NPCStateMachine : NPCState
    {

        public NPCState _currentState;

        public override void Execute()
        {
            _currentState = _currentState.step();
        }
    }
}

