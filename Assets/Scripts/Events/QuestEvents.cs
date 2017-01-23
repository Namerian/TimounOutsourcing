using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using Events;

namespace QuestEvent
{
    public class QuestEvents : MonoBehaviour
    {
        internal interface INewQuestAddedHandler : IEventSystemHandler
        {
            void OnNewQuestAdded(QuestClass parQuest);
        }

        internal interface IQuestCompletedHandler : IEventSystemHandler
        {
            void OnQuestCompleted(QuestClass parQuest);
        }

        internal interface IIHaveAquestToGive : IEventSystemHandler
        {
            void OnQuestGive(NPCSimpleBehavior NPC);
        }

        internal interface IQuestAllObjectivesCompleted : IEventSystemHandler
        {
            void OnAllObjectivesCompleted(QuestClass parQuest);
        }

        internal interface IObjectiveCompleted : IEventSystemHandler
        {
            void OnObjectiveCompleted(Objective parQuest);
        }
    }
}

