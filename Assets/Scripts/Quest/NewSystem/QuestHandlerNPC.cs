using UnityEngine;
using System.Collections.Generic;
using System;
using Events;
using QuestEvent;

[Serializable]
public class QuestHandlerNPC : MonoBehaviour
{
    //public List<GameObject> listOfQuest;
    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();

    List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

    void Start()
    {
        foreach(QuestClass quest in QuestManager.instance.questList)
        {
            foreach(int questId in availableQuestIDs)
            {
                if(quest.id == questId)
                {
                    quest.owner = this.GetComponent<NPCSimpleBehavior>();
                }
            }
        }

        foreach (QuestClass quest in QuestManager.instance.questList)
        {
            foreach (int questId in receivableQuestIDs)
            {
                if (quest.id == questId)
                {
                    quest.getter = this.GetComponent<NPCSimpleBehavior>();
                }
            }
        }
    }

    public void QuestText(NPCSimpleBehavior npc)
    {
        Debug.Log("NPC :"+npc);
        if(npc.questHandlerNPC.availableQuestIDs.Count > 0)
        {
            for(int i = 0; i < npc.questHandlerNPC.availableQuestIDs.Count; i++)
            {
                
                if (QuestManager.instance.GetQuest(npc.questHandlerNPC.availableQuestIDs[i]).progress == QuestClass.QuestProgress.ACCEPTED)
                {
                    GetData(npc, npc.questHandlerNPC.availableQuestIDs[i], "Text Completing");
                }
                else if (QuestManager.instance.GetQuest(npc.questHandlerNPC.availableQuestIDs[i]).progress == QuestClass.QuestProgress.COMPLETE)
                {
                    GetData(npc, npc.questHandlerNPC.availableQuestIDs[i], "Text End");
                }
                else if (QuestManager.instance.GetQuest(npc.questHandlerNPC.availableQuestIDs[i]).progress == QuestClass.QuestProgress.AVAILABLE)
                {
                    GetData(npc, npc.questHandlerNPC.availableQuestIDs[i], "Text Start");
                }
            }
        }
    }

    public void GetData(NPCSimpleBehavior npc, int id, string text)
    {
        data = CSVReader.Read(npc.npcName);

        npc.dialogStringList.Clear();
        for (int i = 0; i < data.Count; i++)
        {
            int tempId = System.Int32.Parse(data[i]["ID"].ToString());
            //Debug.Log("tempId : "+ tempId +", "+ id);
            if (tempId == id)
            {
                
                if (npc.dialogStringList != null)
                {
                    
                    npc.dialogStringList.Add(data[i][text].ToString());
                    
                }
            }
        }
    }
}
