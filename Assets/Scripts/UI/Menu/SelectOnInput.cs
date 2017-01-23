using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Combat;
using Events;
using System;
using UnityEngine.SceneManagement;
public class SelectOnInput : MonoBehaviour, CombatEvents.iPlayerLost
{

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

    private bool sceneExplo;
    Scene scene;
    void Awake()
    {
        EventCenter.AddSubscriber(this);
        Scene scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }

    void OnEnable()
    {
        if(SceneManager.GetSceneAt(0) == SceneManager.GetActiveScene())
        {
            Invoke("Enable", 0.1f);
        }
    }

    void Enable()
    {
        eventSystem  = FindObjectOfType(typeof(EventSystem)) as EventSystem;
        eventSystem.SetSelectedGameObject(selectedObject);
        buttonSelected = true;
    }

    public void OnPlayerLost()
    {
        Invoke("Enable", 0.1f);
    }
}
