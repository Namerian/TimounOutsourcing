using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Events;
using Combat;
using GameInput;
using System;
using System.Linq;

public class CombatManager : MonoBehaviour,
    CombatEvents.INewTurnHandler,
    CombatEvents.ITurnTransitionHandler,
    CombatEvents.IInitCombatHandler,
    CombatEvents.ICombatEndHandler,
    CombatEvents.IEntityIsOutOfStamina
{

    public static CombatManager instance;

    public List<Player.Player> listOfPlayers;
    public List<Monster.Monster> listOfMonsters;

    public CombatZone currentCombatZone = null;

    public TurnManager.TurnState currentTurn;

    public bool allPlayerOutOfStamina;

    bool _isHoldingRightTrigger = false;
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

    public void FillPlayers()
    {
        listOfPlayers.Clear();
        GameObject[] tempPlayers = GameObject.FindGameObjectsWithTag("PlayerCombat");

        for (int i = 0; i < tempPlayers.Length; i++)
        {
            if(tempPlayers[i].GetComponent<Player.Player>())
            {
                listOfPlayers.Add(tempPlayers[i].GetComponent<Player.Player>());
                listOfPlayers.OrderBy(player => player.entityName);
            }
        }
        for (int i = 0; i < listOfPlayers.Count; i++)
        {
            listOfPlayers[i].ID = i;
        }
    }

    public void FillMonsters()
    {
        listOfMonsters.Clear();
        listOfMonsters = currentCombatZone.monsterList;
    }

    public void RemovePlayerFromList(Player.Player player)
    {
        Player.Player playerToRemove = listOfPlayers.SingleOrDefault(r => r == player);
        if (playerToRemove != null)
            listOfPlayers.Remove(playerToRemove);
    }

    public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState turn, float transitionDuration)
    {
        currentTurn = turn;
    }

    public void OnNewTurn(TurnManager.TurnState turn, float turnDuration)
    {
        currentTurn = turn;
    }

    public void OnCombatEnd()
    {
        Destroy(currentCombatZone.gameObject);
        currentCombatZone = null;
    }

    public void OnInitCombat()
    {
        FillPlayers();
        FillMonsters();
        EventCenter.FireEvent<CombatEvents.IAfterInitCombatHandler>((handler) => handler.OnAfterInitCombat());
        //Fire Event ListReady
    }

    public void OnEntityIsOutOfStamina(Entity parEntity)
    {
        if(parEntity.GetType() == typeof(PlayerStamina))
        {
            allPlayerOutOfStamina = listOfPlayers.All(x => x.staminaScript.staminaState == Stamina.StaminaState.OutOfStamina);
        }
    }
}
