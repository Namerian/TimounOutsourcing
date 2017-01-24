using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameInput;

namespace StateMachine
{
    public abstract class InputState : MonoBehaviour
    {
        public List<InputTransition> _listOfTransitions = new List<InputTransition>();
        
        public abstract void Execute();

        public virtual InputState step()
        {
            foreach (InputTransition _tempTransition in _listOfTransitions)
            {
                if (_tempTransition.Check())
                {
                    return _tempTransition._nextState;
                }
            }
            Execute();
            return this;
        }
    }

}

