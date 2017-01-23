using UnityEngine;
using System.Collections;
using DG.Tweening;
using Combat;
using Events;
using System;

public class MonsterCombatUI : MonoBehaviour, CombatEvents.ICombatEnterHandler, CombatEvents.ICombatEndHandler {
    CanvasGroup canvasGroup;
    
    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    // Use this for initialization
    void Start () {
        canvasGroup = this.GetComponent<CanvasGroup>();
        Mask();
    }

    // Update is called once per frame
    void Update()
    {
        if (ContextManager.instance.currentContext == GameInput.InputContextList.Combat)
        {
            transform.LookAt(Camera.main.transform);
        }
    }

    public void Show()
    {
        canvasGroup.DOFade(1, 0.1f);
    }

    public void Mask()
    {
        canvasGroup.DOFade(0, 0.1f);
    }

    public void OnCombatEnter()
    {
        Show();
    }

    public void OnCombatEnd()
    {
        Mask();
    }
}
