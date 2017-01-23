using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInput;
using Events;
using Exploration;
using System;



[System.Serializable]
public class InteractableItem : MonoBehaviour
{
    [System.Serializable]
    public struct ObjectiveToUpdate
    {
        public string objective;
        public int objectiveCount;
    }

    public bool Interact;
    public bool MoveTo;
    public bool Trigger;

    public Transform target;

    public List<ObjectiveToUpdate> listOfObjectives = new List<ObjectiveToUpdate>();

    void Update()
    {
        if (!MoveTo)
            return;

        if(Vector3.Distance(this.transform.position, target.position) > 2f)
        {
            for (int i = 0; i < listOfObjectives.Count; i++)
            {
                QuestManager.instance.AddQuestItem(listOfObjectives[i].objective, listOfObjectives[i].objectiveCount);
            }
            MoveTo = false;
        }
    }

    public void InteractWith()
    {
        for(int i = 0; i < listOfObjectives.Count; i++)
        {
            QuestManager.instance.AddQuestItem(listOfObjectives[i].objective, listOfObjectives[i].objectiveCount);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (Trigger)
        {
            for (int i = 0; i < listOfObjectives.Count; i++)
            {
                QuestManager.instance.AddQuestItem(listOfObjectives[i].objective, listOfObjectives[i].objectiveCount);
            }
        }
    }
}
