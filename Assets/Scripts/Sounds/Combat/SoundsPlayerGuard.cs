using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;

public class SoundsPlayerGuard : MonoBehaviour, CombatEvents.IEndGuardHandler, CombatEvents.IStartGuardHandler {
    private SFXManager _SFXManager;
    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Start()
    {
        _SFXManager = SFXManager.instance;
    }

    public void OnStartGuard(Entity parOwner)
    {
        if(parOwner.GetType() == typeof(Player.Player) && TurnManager.Instance().currentTurnState == TurnManager.TurnState.Enemyturn)
        {
            _SFXManager.PlaySingle(parOwner.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Guard_Up));
        }
    }

    public void OnEndGuard(Entity parOwner)
    {
        if (parOwner.GetType() == typeof(Player.Player) && TurnManager.Instance().currentTurnState == TurnManager.TurnState.Enemyturn)
        {
            _SFXManager.PlaySingle(parOwner.gameObject, _SFXManager.FindInCombatList(SFXManager.SFXNames.Guard_Down));
        }
    }
}
