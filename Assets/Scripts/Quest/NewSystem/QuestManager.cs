using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using QuestEvent;

public class QuestManager : MonoBehaviour {

    public static QuestManager instance;

    public List<QuestClass> questList = new List<QuestClass>();
    public List<QuestClass> currentQuestList = new List<QuestClass>();



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public QuestClass GetQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID)
            {
                return questList[i];
            }
        }
        return null;
    }

    public bool RequestAvailableQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == QuestClass.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == QuestClass.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == QuestClass.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckAvailableQuests(QuestHandlerNPC NPCQuestHandler)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestHandler.availableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestHandler.availableQuestIDs[j] && questList[i].progress == QuestClass.QuestProgress.AVAILABLE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuests(QuestHandlerNPC NPCQuestHandler)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestHandler.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestHandler.receivableQuestIDs[j] && questList[i].progress == QuestClass.QuestProgress.ACCEPTED)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompleteQuests(QuestHandlerNPC NPCQuestHandler)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestHandler.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestHandler.receivableQuestIDs[j] && questList[i].progress == QuestClass.QuestProgress.COMPLETE)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool CompleteAllObjectives(QuestClass quest)
    {
        for (int j = 0; j < quest.questObjectives.Count; j++)
        {
            if (!(quest.questObjectives[j].questObjectiveCount >= quest.questObjectives[j].questObjectiveRequirement))
            {
                return false;
            }
        }
        return true;
    }

    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for(int i = 0; i < currentQuestList.Count; i++)
        {
            for(int j = 0; j < currentQuestList[i].questObjectives.Count; j++)
            {
                if (currentQuestList[i].questObjectives[j].questObjective == questObjective && currentQuestList[i].progress == QuestClass.QuestProgress.ACCEPTED)
                {
                    currentQuestList[i].questObjectives[j].questObjectiveCount += itemAmount;
                    if(currentQuestList[i].questObjectives[j].questObjectiveCount == currentQuestList[i].questObjectives[j].questObjectiveRequirement)
                    {
                        EventCenter.FireEvent<QuestEvents.IObjectiveCompleted>((handler) => handler.OnObjectiveCompleted(currentQuestList[i].questObjectives[j]));
                    }
                }

                if (CompleteAllObjectives(currentQuestList[i]) && currentQuestList[i].progress == QuestClass.QuestProgress.ACCEPTED)
                {
                    currentQuestList[i].progress = QuestClass.QuestProgress.COMPLETE;
                    EventCenter.FireEvent<QuestEvents.IQuestAllObjectivesCompleted>((handler) => handler.OnAllObjectivesCompleted(GetQuest(currentQuestList[i].id)));
                }
            }
        }
    }

    public void AcceptQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == QuestClass.QuestProgress.AVAILABLE)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = QuestClass.QuestProgress.ACCEPTED;
                EventCenter.FireEvent<QuestEvents.INewQuestAddedHandler>((handler) => handler.OnNewQuestAdded(GetQuest(questList[i].id)));
            }
        }
    }

    public void GiveUpQuest(int questID)
    {
        for(int i = 0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].id == questID && currentQuestList[i].progress == QuestClass.QuestProgress.ACCEPTED)
            {
                for(int j = 0; j < currentQuestList[i].questObjectives.Count; j++)
                {
                    currentQuestList[i].questObjectives[j].questObjectiveCount = 0;
                }
                currentQuestList[i].progress = QuestClass.QuestProgress.AVAILABLE;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }

    public void CompleteQuest(int questID)
    {
        for(int i =0; i < currentQuestList.Count; i++)
        {
            if(currentQuestList[i].id == questID && currentQuestList[i].progress == QuestClass.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = QuestClass.QuestProgress.DONE;
                EventCenter.FireEvent<QuestEvents.IQuestCompletedHandler>((handler) => handler.OnQuestCompleted(GetQuest(currentQuestList[i].id)));
                currentQuestList.Remove(currentQuestList[i]);
                //reward
            }
        }
        //check for chain quests
        CheckChainQuest(questID);
    }

    public void QuestRequest(QuestHandlerNPC NPCQuestHandler)
    {
        if(NPCQuestHandler.availableQuestIDs.Count > 0)
        {
            //available quest
            for(int i = 0; i < questList.Count; i++)
            {
                for(int j = 0; j < NPCQuestHandler.availableQuestIDs.Count; j++)
                {
                    if (questList[i].id == NPCQuestHandler.availableQuestIDs[j] && questList[i].progress == QuestClass.QuestProgress.AVAILABLE)
                    {
                        Debug.Log("quest ID : "+ NPCQuestHandler.availableQuestIDs[j]+" "+questList[i].progress);

                        //TESTING
                        AcceptQuest(NPCQuestHandler.availableQuestIDs[j]);
                        //quest ui manager
                    }
                }
            }

            //active quest
            if(currentQuestList.Count > 0)
            {
                for (int i = 0; i < currentQuestList.Count; i++)
                {
                    for (int j = 0; j < NPCQuestHandler.receivableQuestIDs.Count; j++)
                    {
                        if (currentQuestList[i].id == NPCQuestHandler.receivableQuestIDs[j] && currentQuestList[i].progress == QuestClass.QuestProgress.ACCEPTED || currentQuestList[i].progress == QuestClass.QuestProgress.COMPLETE)
                        {
                            Debug.Log("quest ID : " + NPCQuestHandler.receivableQuestIDs[j] + " " + currentQuestList[i].progress);

                            CompleteQuest(NPCQuestHandler.receivableQuestIDs[j]);
                        }
                    }
                }
            }
        }
    }

    void CheckChainQuest(int questID)
    {
        int tempID = 0;
        
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].nextQuestID > 0)
            {
                tempID = questList[i].nextQuestID;
            }
        }

        if(tempID > 0)
        {
            for(int i = 0; i < questList.Count; i++)
            {
                if(questList[i].id == tempID && questList[i].progress == QuestClass.QuestProgress.NOT_AVAILABLE)
                {
                    questList[i].progress = QuestClass.QuestProgress.AVAILABLE;
                }
            }
        }
    }
}
