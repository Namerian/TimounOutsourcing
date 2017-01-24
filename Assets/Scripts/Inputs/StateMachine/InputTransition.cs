using UnityEngine;
using System.Collections;

namespace StateMachine
{
    public class InputTransition : MonoBehaviour
    {
        public delegate bool check();
        check _myDelegate;


        public InputState _nextState;

        public InputTransition(check parDelegate, InputState parState)
        {
            _myDelegate += parDelegate;
            _nextState = parState;
        }

        public InputTransition SetInputTransition(check parDelegate, InputState parState)
        {
            _myDelegate += parDelegate;
            _nextState = parState;
            return this;
        }
        public bool Check()
        {
            return _myDelegate();
        }

    }
}

