using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;
using Events;
using GameInput;
using System;
using Exploration;
using QuestEvent;

public class DialogString
{
    public string dialogString;
}

public class NPCSimpleBehavior : MonoBehaviour, 
    InputEvents.IActionHandler,
    QuestEvents.IQuestCompletedHandler,
    QuestEvents.IIHaveAquestToGive,
    QuestEvents.INewQuestAddedHandler
    {


    public int ID;
    public bool isPlayerNear;
    public Quaternion initialRotation;
    public CharacterControllerLogic player;
    public string npcName;

    public List<DialogString> dialogList = new List<DialogString>();
    public List<string> dialogStringList = new List<string>();

    DialogString currentDialogString;
    public Text dialogTextObject;

    public bool isSpeaking;
    public NPCInteractUI NPCInteractUI;
    bool isWriting;
    public bool isLastNPC;

    [Header("Quest dialog : ")]
    public int currentQuestID = -1;
    public int currentQuestTextID = -1;
    [HideInInspector]
    public QuestHandlerNPC questHandlerNPC;
    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    // Use this for initialization
    void Start () {
        NPCManager.instance.NPCList.Add(this);
        isPlayerNear = false;
        initialRotation = this.transform.rotation;
        NPCInteractUI = GetComponentInChildren<NPCInteractUI>();
        
        if (this.GetComponent<QuestHandlerNPC>())
        {
            questHandlerNPC = this.GetComponent<QuestHandlerNPC>();
        }
        Invoke("IsAnyQuestLeft", 0.1f);
        //IsAnyQuestLeft();
    }

    public void LookAtPlayer(Vector3 playerPos)
    {
        this.transform.DOLookAt(playerPos, 0.5f, AxisConstraint.Y);
    }

    public void IsAnyQuestLeft()
    {
        if (questHandlerNPC && questHandlerNPC.availableQuestIDs.Count > 0)
        {
            for(int i = 0; i < questHandlerNPC.availableQuestIDs.Count; i++)
            {
                if(QuestManager.instance.GetQuest(questHandlerNPC.availableQuestIDs[i]).progress == QuestClass.QuestProgress.AVAILABLE)
                {
                    EventCenter.FireEvent<QuestEvents.IIHaveAquestToGive>((handler) => handler.OnQuestGive(this));
                }
            }
            
        }
    }

    public void RotateTo(Quaternion quaternion)
    {
        this.transform.DORotateQuaternion(quaternion, 0.5f);
    }

    public void NextDialog()
    {
        int index = dialogList.FindIndex(a => a == currentDialogString);
        if (index >= dialogList.Count - 1)
        {
            EndDialog();
        }
        else
        {
            currentDialogString = dialogList[index + 1];
            dialogTextObject.text = "";
            isWriting = true;
            dialogTextObject.DOText(npcName + " : " + currentDialogString.dialogString, 1f).OnComplete(() => dialogTextObject.text = npcName + " : " + currentDialogString.dialogString).OnComplete(() => isWriting = false);
        }
    }

    public void LaunchDialog()
    {

        //Debug.Log(questHandlerNPC.listOfQuest[0].GetComponent<Quest>()._quest.QuestID);
        if (questHandlerNPC && questHandlerNPC.availableQuestIDs.Count > 0)
        {
            for (int i = 0; i < questHandlerNPC.availableQuestIDs.Count; i++)
            {
                Debug.Log(QuestManager.instance.GetQuest(questHandlerNPC.availableQuestIDs[i]).title);
                if (QuestManager.instance.GetQuest(questHandlerNPC.availableQuestIDs[i]).progress == QuestClass.QuestProgress.AVAILABLE)
                {
                    currentQuestID = QuestManager.instance.GetQuest(questHandlerNPC.availableQuestIDs[i]).id;
                    
                }
            }
            questHandlerNPC.QuestText(this);

        }

        if (GetComponent<InteractableItem>() && GetComponent<InteractableItem>().listOfObjectives.Count > 0)
        {
            GetComponent<InteractableItem>().InteractWith();
        }

        /*if (questHandlerNPC!=null && questHandlerNPC.listOfQuest.Count > 0)
        {
            currentQuestID = questHandlerNPC.listOfQuest[0].GetComponent<Quest>()._quest.QuestID;
            questHandlerNPC.QuestText(this);
        }*/
        
        dialogStringList.RemoveAll(str => String.IsNullOrEmpty(str));

        dialogList.Clear();
        foreach (string dialogString in dialogStringList)
        {
            
            DialogString dialogStringObject = new DialogString();
            dialogStringObject.dialogString = dialogString;
            dialogList.Add(dialogStringObject);
        }

        dialogTextObject = UIManager.instance.panelDialog.GetComponentInChildren<Text>();
        if (dialogList.Count <= 0 || isSpeaking || ContextManager.instance.currentContext == InputContextList.Dialogue)
        {
            return;
        }

        ContextManager.instance.ChangeContext(InputContextList.Dialogue);

        

        currentDialogString = dialogList[0];
        dialogTextObject.text = "";
        isWriting = true;
        dialogTextObject.DOText(npcName + " : " + currentDialogString.dialogString, 1f).OnComplete(() => dialogTextObject.text = npcName + " : " + currentDialogString.dialogString).OnComplete(() => isWriting = false);
        dialogTextObject.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        UIManager.instance.panelDialog.transform.GetChild(0).GetComponent<Image>().DOFade(0.63f, 0.2f);
        Invoke("Speak", 0.3f);
        NPCInteractUI.Mask();

        if (questHandlerNPC != null)
        {
            if(questHandlerNPC.availableQuestIDs.Count > 0)
            {
                QuestManager.instance.QuestRequest(questHandlerNPC);
                //questHandlerNPC.CheckPlayerQuest(player.GetComponent<QuestHandlerPlayer>());
            }
            //player.GetComponent<QuestHandlerPlayer>().ReturnQuest(questHandlerNPC);
            //questHandlerNPC.RemoveQuest(questHandlerNPC.FinishQuest());
        }

    }

    void Speak()
    {
        isSpeaking = true;
    }

    public void EndDialog()
    {
        if (dialogTextObject != null)
        {
            dialogTextObject.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
            UIManager.instance.panelDialog.transform.GetChild(0).GetComponent<Image>().DOFade(0, 0.2f);
        }

        ContextManager.instance.ChangeContext(InputContextList.Exploration);
        Invoke("StopDialog", 0.5f);
        if (player != null)
        {
            NPCInteractUI.Show();
            /*if (questHandlerNPC != null)
            {
                player.GetComponent<QuestHandlerPlayer>().ReceiveQuest(questHandlerNPC);
            }*/
        }

        
    }

    public void OnAction(InputActionList action, InputState state)
    {
        if (!ContextManager.instance.CompareContext(InputContextList.Dialogue))
        {
            return;
        }

        if (action == InputActionList.Interact && state == InputState.Pressed && isSpeaking && !isWriting)
        {
            NextDialog();
        }
    }

    void StopDialog()
    {
        if (isLastNPC && isSpeaking)
        {
            EventCenter.FireEvent<ExplorationEvents.IEndPrototye>((handler) => handler.OnEndPrototype());
        }

        if (this.GetComponent<NPCStateHandler>())
        {
            this.GetComponent<NPCStateHandler>()._moveState.DoMove();
        }
        isSpeaking = false;
    }

    public void OnQuestCompleted(QuestClass parQuest)
    {
        IsAnyQuestLeft();
        Debug.Log(parQuest.title);
    }

    public void OnQuestGive(NPCSimpleBehavior NPC)
    {
        if(NPC.GetInstanceID() == this.GetInstanceID())
        {
            //Debug.Log(NPC.npcName);
        }
    }

    public void OnNewQuestAdded(QuestClass parQuest)
    {
        
    }
}
