using UnityEngine;
using System.Collections;
using QuestEvent;
using Events;
using System;
using DG.Tweening;
using UnityEngine.UI;
public class UITextQuestObjective : MonoBehaviour,
    QuestEvents.IQuestCompletedHandler,
    QuestEvents.IQuestAllObjectivesCompleted,
    QuestEvents.IObjectiveCompleted{
    public QuestClass quest;
    public Objective objective;

    void Start()
    {
        EventCenter.AddSubscriber(this);
    }

    public void OnAllObjectivesCompleted(QuestClass parQuest)
    {
        if(parQuest == quest)
        {
            this.GetComponent<Text>().text = quest.title + " est terminée ! Retournez voir " + parQuest.getter.npcName + ".";
        }
    }

    public void OnQuestCompleted(QuestClass parQuest)
    {
        /*if (parQuest == quest)
        {

                this.GetComponent<Text>().DOFade(0.5f, 0.3f);
        }*/
    }

    public void OnObjectiveCompleted(Objective parObjectif)
    {

        if (parObjectif == this.objective)
        {
            this.GetComponent<Text>().DOFade(0.5f, 0.3f);
        }
    }
}
