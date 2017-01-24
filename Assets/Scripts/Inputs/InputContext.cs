using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace GameInput
{
    public class InputContext : MonoBehaviour
    {
        [SerializeField]
        public List<IInputContext> ContextList;

        [Serializable]
        public struct IInputContext
        {
            public InputContextList IContext;
            public List<InToAction> InputMap;
        }

        [Serializable]
        public struct InToAction
        {
            public GamePadButttons Inputs;
            public InputActionList IAction;
        }
    }
}

