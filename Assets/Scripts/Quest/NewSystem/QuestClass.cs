using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Objective
{
    [Header("Quest objective settings :")]
    public string questObjective;
    public int questObjectiveCount;
    public int questObjectiveRequirement;
}


[System.Serializable]
public class QuestClass{

	public enum QuestProgress
    {
        NOT_AVAILABLE,
        AVAILABLE,
        ACCEPTED,
        COMPLETE,
        DONE,
    }

    public NPCSimpleBehavior owner;
    public NPCSimpleBehavior getter;

    [Header("Quest Settings :")]
    public string title;
    public int id;
    public QuestProgress progress;
    public string description;
    public string hint;
    public string congratulation;
    public string summary;
    public int nextQuestID;
    
    [Header("Objectives :")]
    public List<Objective> questObjectives = new List<Objective>();
    
    [Header("Reward :")]
    public int expReward;
    public int goldReward;
    public string itemReward;

}
