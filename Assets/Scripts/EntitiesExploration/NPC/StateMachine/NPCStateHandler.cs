using UnityEngine;
using System.Collections;
using Events;
using System;
using StateMachine;

public class NPCStateHandler : MonoBehaviour
{

    
	public NPC myNPC;
	public NPCMovement myNPCMovement;

	NPCStateMachine _stateMachine;

	NPCIdleState _idleState;
	public NPCMoveState _moveState;

	NPCTransition _idleToMove;
	NPCTransition _moveToIdle;

	//public static StateMachine.NPCState currentState;

	public bool hasReachedDest;
	public bool hasFinishedIdle;
	public bool isInteracting;

	void Start ()
	{
		myNPC = GetComponent<NPC> ();
		myNPCMovement = GetComponent<NPCMovement> ();

		_stateMachine = this.gameObject.AddComponent<NPCStateMachine> ();

		_idleState = this.gameObject.AddComponent<NPCIdleState> ();
		_moveState = this.gameObject.AddComponent<NPCMoveState> ();

		_stateMachine._currentState = _idleState;

		_idleToMove = this.gameObject.AddComponent<NPCTransition> ().SetNPCTransition (HasFinishedIdle, _moveState);
		_idleState._listOfTransitions.Add (_idleToMove);

		_moveToIdle = this.gameObject.AddComponent<NPCTransition> ().SetNPCTransition (CheckReachedDest, _idleState);
		_moveState._listOfTransitions.Add (_moveToIdle);
	}

	void Update ()
	{
		_stateMachine.Execute ();
	}

	bool HasFinishedIdle ()
	{
		return hasFinishedIdle;
	}

	bool CheckReachedDest ()
	{
		return hasReachedDest;
	}

}
