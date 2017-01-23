using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Events;
using Combat;
using Exploration;
using GameInput;
using UnityEngine.UI;
using DG.Tweening;
public class ContextManager : MonoBehaviour {

    public static ContextManager instance;

    public GameObject explorationStateMachine;
    public GameObject combatStateMachine;

    public List<ContextControlUI> panelContextList = new List<ContextControlUI>();


    /*public enum ContextState
    {
        Exploration,
        Combat,
        UI, //Map, inventory, pause...
        Dialog
    }*/

    public InputContextList currentContext;
    public InputContextList previousContext;

    void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        EventCenter.AddSubscriber(this);
    }

    

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        explorationStateMachine.SetActive(true);

        //Dirty Event 
//#if UNITY_EDITOR
        EventCenter.FireEvent<ExplorationEvents.IExplorationEnterHandler>((handler) => handler.OnExplorationEnter());
//#endif
        ChangeContext(InputContextList.Exploration);
    }

    //Disable combat State Machine On Start
    void Start()
    {
        Invoke("SortList", 0.1f);
        
        //combatStateMachine.SetActive(true);
        //ChangeContext(ContextState.Combat);
    }


    void SortList()
    {
        panelContextList.Sort((x, y) => string.Compare(x.name, y.name));
        MaskAllPanelContext();
        panelContextList[2].Show();
    }

    void MaskAllPanelContext()
    {
        foreach (ContextControlUI contextControlUI in panelContextList)
        {
            contextControlUI.Mask();
        }
    }

    public void ChangeContext(InputContextList contextWanted)
    {
        
        if(contextWanted == currentContext)
        {
            return;
        }

        previousContext = currentContext;
        currentContext = contextWanted;
        GameInputs.instance._currentContext = currentContext;

        //End combat, Start exploration
        if (contextWanted == InputContextList.Exploration && previousContext == InputContextList.Combat)
        {
            MaskAllPanelContext();

            EventCenter.FireEvent<CombatEvents.ICombatEndHandler>((handler) => handler.OnCombatEnd());
            EventCenter.FireEvent<ExplorationEvents.IExplorationEnterHandler>((handler) => handler.OnExplorationEnter());

            //DIRTY
            UIManager.instance.panelQuest.GetComponent<CanvasGroup>().DOFade(1, 0.2f);

            combatStateMachine.SetActive(false);
            explorationStateMachine.SetActive(true);
            panelContextList[2].Show();
        }

        //End exploration, Start Combat
        if (contextWanted == InputContextList.Combat && previousContext == InputContextList.Exploration)
        {

            MaskAllPanelContext();

            EventCenter.FireEvent<CombatEvents.ICombatEnterHandler>((handler) => handler.OnCombatEnter());
            EventCenter.FireEvent<ExplorationEvents.IExplorationEndHandler>((handler) => handler.OnExplorationEnd());

            //DIRTY
            UIManager.instance.panelQuest.GetComponent<CanvasGroup>().DOFade(0, 0.2f);

            explorationStateMachine.SetActive(false);
            combatStateMachine.SetActive(true);
            panelContextList[0].Show();
        }

        //End Exploration, Start Dialog
        if(contextWanted == InputContextList.Dialogue && previousContext == InputContextList.Exploration)
        {
            MaskAllPanelContext();

            EventCenter.FireEvent<ExplorationEvents.IDialogEnterHandler>((handler) => handler.OnDialogEnter());
            EventCenter.FireEvent<ExplorationEvents.IExplorationEndHandler>((handler) => handler.OnExplorationEnd());
            panelContextList[1].Show();

        }

        //End Dialog, Start Exploration
        if (contextWanted == InputContextList.Exploration && previousContext == InputContextList.Dialogue)
        {
            MaskAllPanelContext();

            EventCenter.FireEvent<ExplorationEvents.IDialogEndHandler>((handler) => handler.OnDialogEnd());
            EventCenter.FireEvent<ExplorationEvents.IExplorationEnterHandler>((handler) => handler.OnExplorationEnter());
            panelContextList[2].Show();
        }

        //End Dialog, Start Combat
        if (contextWanted == InputContextList.Combat && previousContext == InputContextList.Dialogue)
        {
            MaskAllPanelContext();

            ///Debug.Log("dialog");
            EventCenter.FireEvent<ExplorationEvents.IDialogEndHandler>((handler) => handler.OnDialogEnd());
            EventCenter.FireEvent<CombatEvents.ICombatEnterHandler>((handler) => handler.OnCombatEnter());
            explorationStateMachine.SetActive(false);
            combatStateMachine.SetActive(true);
            panelContextList[0].Show();

        }

        //End Combat, Start Dialog
        if (contextWanted == InputContextList.Dialogue && previousContext == InputContextList.Combat)
        {
            MaskAllPanelContext();

            EventCenter.FireEvent<CombatEvents.ICombatEndHandler>((handler) => handler.OnCombatEnd());
            EventCenter.FireEvent<ExplorationEvents.IDialogEnterHandler>((handler) => handler.OnDialogEnter());
            combatStateMachine.SetActive(false);
            explorationStateMachine.SetActive(true);
            panelContextList[1].Show();
        }
    }

    public bool CompareContext(InputContextList context)
    {
        if(currentContext == context)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
