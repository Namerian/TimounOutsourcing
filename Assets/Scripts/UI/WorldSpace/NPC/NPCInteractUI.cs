using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using QuestEvent;
using System;
using System.Collections.Generic;
using Unity.Linq;
using Events;

public class NPCInteractUI : MonoBehaviour,
    QuestEvents.IIHaveAquestToGive,
    QuestEvents.INewQuestAddedHandler,
    QuestEvents.IQuestCompletedHandler,
    QuestEvents.IQuestAllObjectivesCompleted
{

    public NPCSimpleBehavior NPC;
    public Image icon;
    public Text textInteraction;
    CanvasGroup canvasGroup;
    CanvasGroup questCanvasGroup;
    public bool isActive;

    public List<Image> questImageList = new List<Image>();
    Image newQuest;
    Image questNotDone;
    Image questDone;

    public GameObject NewQuestMinimap;
    public GameObject QuestNotDoneMinimap;
    public GameObject QuestDoneMinimap;
    SubscribeMapObject mapIcon;

    public GameObject questTitle;
    public GameObject questObjective;
    public UIPanelQuest panelQuest;

    GameObject _questSlot;


    void Awake()
    {
        EventCenter.AddSubscriber(this);
        NPC = this.transform.parent.GetComponent<NPCSimpleBehavior>();
    }

	// Use this for initialization
	void Start () {
        
        canvasGroup = this.GetComponent<CanvasGroup>();
        isActive = false;
        
        textInteraction = transform.GetChild(2).GetComponent<Text>();
        Mask();

        CanvasGroup[] tempCanvasGroup = GetComponentsInChildren<CanvasGroup>();
        foreach(CanvasGroup canvas in tempCanvasGroup)
        {
            if (canvas.gameObject.GetInstanceID() != GetInstanceID())
            {
                questCanvasGroup = canvas;
            }
        }
        Image[] tempQuestImage = questCanvasGroup.GetComponentsInChildren<Image>();
        foreach (Image image in tempQuestImage)
        {
            questImageList.Add(image);
        }
        newQuest = questImageList[0];
        questNotDone = questImageList[1];
        questDone = questImageList[2];


        NewQuestMinimap =  MinimapIconManager.instance.GetIcon("NewQuestMinimap");
        QuestNotDoneMinimap = MinimapIconManager.instance.GetIcon("QuestNotDoneMinimap");
        QuestDoneMinimap = MinimapIconManager.instance.GetIcon("QuestDoneMinimap");
        questTitle = (GameObject)Resources.Load("Quests/QuestTitle");
        questObjective = (GameObject)Resources.Load("Quests/QuestObjective");
        
        Invoke("Init", 0.3f);
    }
	

    void Init()
    {
        panelQuest = UIManager.instance.panelQuest.GetComponent<UIPanelQuest>();
    }

	// Update is called once per frame
	void Update () {
        if (isActive && NPC.player != null)
        {
            transform.LookAt(Camera.main.transform);
        }
	}

    public void Mask()
    {
        canvasGroup.DOFade(0, 0.2f);

    }

    public void MaskAllQuest()
    {
        newQuest.DOFade(0, 0);
        questNotDone.DOFade(0, 0);
        questDone.DOFade(0, 0);
    }

    public void Show()
    {
        canvasGroup.DOFade(1, 0.2f);
    }

    public void OnQuestGive(NPCSimpleBehavior parNPC)
    {
        if (parNPC == NPC)
        {
           
            MaskAllQuest();
            newQuest.DOFade(1, 0);
            Destroy(mapIcon);
            
            GameObject tempNewQuest = Instantiate(NewQuestMinimap, this.transform) as GameObject;
            tempNewQuest.transform.position = NPC.transform.position;
            mapIcon = tempNewQuest.GetComponent<SubscribeMapObject>();
            Debug.Log(newQuest);
        }
    }

    public void OnNewQuestAdded(QuestClass parQuest)
    {
        if (NPC.questHandlerNPC && parQuest.owner == NPC && parQuest.getter != NPC)
        {
            MaskAllQuest();
            Destroy(mapIcon);
        }
        else if (NPC.questHandlerNPC && parQuest.getter == NPC)
        {
            /*for (int i = 0; i < NPC.questHandlerNPC.receivableQuestIDs.Count; i++)
            {
                if (NPC.questHandlerNPC.receivableQuestIDs[i] == parQuest.id)
                {*/
                    MaskAllQuest();
                    Destroy(mapIcon);
                    GetComponentInChildren<NPCInteractUI>().MaskAllQuest();
                    GetComponentInChildren<NPCInteractUI>().questNotDone.DOFade(1, 0);
                    

                    _questSlot = Instantiate(panelQuest.slot, panelQuest.questContainer.transform, false) as GameObject;
                    panelQuest.AddSlot(_questSlot);
                    panelQuest.ShowSlot(panelQuest.questSlot.Count - 1);
                    GameObject tempNewQuest = Instantiate(QuestNotDoneMinimap, this.transform) as GameObject;
                    tempNewQuest.transform.position = NPC.transform.position;
                    mapIcon = tempNewQuest.GetComponent<SubscribeMapObject>();

                    if (parQuest.questObjectives.Count >= 1)
                    {
                        GameObject tempTitle = Instantiate(questTitle, _questSlot.transform, false) as GameObject;
                        tempTitle.GetComponent<Text>().text = parQuest.title;
                        tempTitle.GetComponent<UITextQuestObjective>().quest = parQuest;
                        foreach (Objective objective in parQuest.questObjectives)
                        {
                            GameObject tempObjective = Instantiate(questObjective, _questSlot.transform, false) as GameObject;
                            tempObjective.GetComponent<UITextQuestObjective>().objective = objective;
                            tempObjective.GetComponent<Text>().text = objective.questObjective;
                        }
                    }
                /*}
            }*/
        }
    }

    public void OnQuestCompleted(QuestClass parQuest)
    {
        if (parQuest.id == NPC.currentQuestID)
        {
            questCanvasGroup.DOFade(0, 0);
            Destroy(mapIcon);
            panelQuest.DeleteSlot(_questSlot);
        }
    }

    public void OnAllObjectivesCompleted(QuestClass parQuest)
    {

        if (NPC.questHandlerNPC)
        {
            for (int i = 0; i < NPC.questHandlerNPC.receivableQuestIDs.Count; i++)
            {
                if (NPC.questHandlerNPC.receivableQuestIDs[i] == parQuest.id)
                {
                    MaskAllQuest();
                    questDone.DOFade(1, 0);
                    Destroy(mapIcon);
                    GameObject tempNewQuest = Instantiate(QuestDoneMinimap, this.transform) as GameObject;
                    tempNewQuest.transform.position = NPC.transform.position;
                    mapIcon = tempNewQuest.GetComponent<SubscribeMapObject>();
                }
            }
        }
        
    }
}
