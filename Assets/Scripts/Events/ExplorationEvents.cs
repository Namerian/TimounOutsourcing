using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using Events;

namespace Exploration
{
    public class ExplorationEvents : MonoBehaviour
    {

        public interface IExplorationEnterHandler : IEventSystemHandler
        {
            void OnExplorationEnter();
        }

        public interface IExplorationEndHandler : IEventSystemHandler
        {
            void OnExplorationEnd();
        }

        public interface IDialogEnterHandler : IEventSystemHandler
        {
            void OnDialogEnter();
        }

        public interface IDialogEndHandler : IEventSystemHandler
        {
            void OnDialogEnd();
        }

        public interface IEndPrototye : IEventSystemHandler
        {
            void OnEndPrototype();
        }
    }
}

