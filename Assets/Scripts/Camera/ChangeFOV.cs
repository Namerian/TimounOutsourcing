using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;
using DG.Tweening;

public class ChangeFOV : MonoBehaviour,
    CombatEvents.ICombatEnterHandler,
    CombatEvents.ICombatEndHandler
    {

    public float FOVCombat;
    public float FOVExplo;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    public void OnCombatEnd()
    {
        Debug.Log("test");
        this.GetComponent<Camera>().DOFieldOfView(FOVExplo, 0.5f);
    }

    public void OnCombatEnter()
    {
        Debug.Log("test");

        this.GetComponent<Camera>().DOFieldOfView(FOVCombat, 0.5f);
    }
}
