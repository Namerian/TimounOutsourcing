using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Events;
using Combat;
using System;
using Exploration;
using GameInput;
using UnityEngine.SceneManagement;
using ThirdPersonCamera;

public class TransitionContextManager : MonoBehaviour,
        CombatEvents.ICombatEnterHandler,
        CombatEvents.ICombatEndHandler,
        ExplorationEvents.IExplorationEnterHandler,
        ExplorationEvents.IExplorationEndHandler,
        ExplorationEvents.IDialogEndHandler,
        ExplorationEvents.IDialogEnterHandler

{

    private static TransitionContextManager transitionContextManager;

    public static TransitionContextManager Instance()
    {
        if (!transitionContextManager)
        {
            transitionContextManager = FindObjectOfType(typeof(TransitionContextManager)) as TransitionContextManager;
            if (!transitionContextManager)
                Debug.LogError("There needs to be one active TransitionContextManager script on a GameObject in your scene.");
        }

        return transitionContextManager;
    }

    void Awake()
    {
        EventCenter.AddSubscriber(this);

        gameCam = Camera.main.gameObject;
    }

    public GameObject gameCam;
    [Header("Combat")]
    public List<GameObject> listOfGameObjectCombat;
    [Header("Exploration")]
    public List<GameObject> listOfGameObjectExplo;

    void Start()
    {

        


        for (int i = 0; i < listOfGameObjectCombat.Count; i++)
        {
            listOfGameObjectCombat[i].SetActive(false);
        }
    }

    void LaunchInitCombat()
    {
        EventCenter.FireEvent<CombatEvents.IInitCombatHandler>((handler) => handler.OnInitCombat());
    }

    public void OnCombatEnter()
    {
        listOfGameObjectCombat = SortList(listOfGameObjectCombat);

        gameCam.GetComponent<CameraController>().enabled = false;
        gameCam.GetComponent<FreeForm>().enabled = false;
        gameCam.GetComponent<Follow>().enabled = false;
        gameCam.GetComponent<DisableFollow>().enabled = false;

        for (int i = 0; i < listOfGameObjectCombat.Count; i++)
        {
            listOfGameObjectCombat[i].SetActive(true);
        }
        gameCam.GetComponent<MoveCombatCamera>().enabled = true;

        Invoke("LaunchInitCombat", 0.1f);
    }

    public void OnCombatEnd()
    {
        gameCam.GetComponent<MoveCombatCamera>().enabled = false;

        for (int i = 0; i < listOfGameObjectCombat.Count; i++)
        {
            listOfGameObjectCombat[i].SetActive(false);
        }
        //Dirty Camera
        gameCam.GetComponent<CameraController>().enabled = true;
        gameCam.GetComponent<FreeForm>().enabled = true;
        gameCam.GetComponent<Follow>().enabled = true;
        gameCam.GetComponent<DisableFollow>().enabled = true;
    }

    public void OnExplorationEnter()
    {
        OnCombatEnd();
        listOfGameObjectExplo = SortList(listOfGameObjectExplo);

        gameCam.GetComponent<MoveCombatCamera>().enabled = false;
        for (int i = 0; i < listOfGameObjectExplo.Count; i++)
        {
            listOfGameObjectExplo[i].SetActive(true);
        }

        gameCam.GetComponent<CameraController>().enabled = true;
        gameCam.GetComponent<FreeForm>().enabled = true;
        gameCam.GetComponent<Follow>().enabled = true;
        gameCam.GetComponent<DisableFollow>().enabled = true;
    }

    public void OnExplorationEnd()
    {
        if(ContextManager.instance.currentContext == InputContextList.Combat)
        {
            gameCam.GetComponent<CameraController>().enabled = false;
            gameCam.GetComponent<FreeForm>().enabled = false;
            gameCam.GetComponent<Follow>().enabled = false;
            gameCam.GetComponent<DisableFollow>().enabled = false;

            for (int i = 0; i < listOfGameObjectExplo.Count; i++)
            {
                listOfGameObjectExplo[i].SetActive(false);
            }
            gameCam.GetComponent<MoveCombatCamera>().enabled = true;
        }
    }

    public void OnDialogEnd()
    {
        //Dialog ended
    }

    public void OnDialogEnter()
    {
        OnCombatEnd();
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
        //Dirty
        if(scene.name == "ExploRodrigue")
        {
            gameCam = Camera.main.gameObject;
        }
    }

    List<GameObject> SortList(List<GameObject> unsortedList)
    {
        unsortedList.Sort((s1, s2) => s1.GetComponent<ObjectContext>().priorityLevel.CompareTo(s2.GetComponent<ObjectContext>().priorityLevel));
        return unsortedList;
    }

    
}
