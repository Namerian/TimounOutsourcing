using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace GameInput
{
    public static class InputEvents
    {

        public interface IActionHandler : IEventSystemHandler
        {
            void OnAction(InputActionList action, InputState state);
        }
    }

}

