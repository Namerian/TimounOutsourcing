using UnityEngine;
using System.Collections;

namespace StateMachine
{
    public class NPCTransition : MonoBehaviour
    {
        public delegate bool check();
        check _myDelegate;

        public NPCState _nextState;

        public NPCTransition(check parDelegate, NPCState parState)
        {
            _myDelegate += parDelegate;
            _nextState = parState;
        }

        public NPCTransition SetNPCTransition(check parDelegate, NPCState parState)
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
