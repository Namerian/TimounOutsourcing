using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPC_AI
{
	public class NpcController : MonoBehaviour
	{
		//
		public EMovementState _movementType;

		//
		private IState _currentState = null;

		//===========================================================
		//
		//===========================================================

		public NPC_AI.IState IdleState{ get; private set; }

		public NPC_AI.IState MovementState{ get; private set; }

		public NPC_AI.IState InteractionState{ get; private set; }

		public NavMeshAgent NavMeshAgent{ get; private set; }

		//===========================================================
		//
		//===========================================================

		// Use this for initialization
		void Start ()
		{
			NavMeshAgent = this.GetComponent<NavMeshAgent> ();

			//**************************************************************************
			IdleState = this.GetComponent<NPC_AI.IdleState> ();

			switch (_movementType) {
			case EMovementState.LoopingInterestPoint:
				MovementState = this.GetComponent<LoopingInterestPointMovementState> ();
				break;
			case EMovementState.RandomInterestPoint:
				MovementState = this.GetComponent<RandomInterestPointMovementState> ();
				break;
			case EMovementState.Zone:
				MovementState = this.GetComponent<ZoneMovementState> ();
				break;
			}

			InteractionState = this.GetComponent<InteractingState> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (_currentState == null) {
				SwitchState (IdleState);
			}

			_currentState.OnUpdate ();
		}

		//===========================================================
		//
		//===========================================================

		public void SwitchState (NPC_AI.IState state)
		{
			//Debug.Log ("NPC " + this.name + " : SwitchState called : new state = " + state.GetType ());

			if (_currentState != null) {
				_currentState.OnExit ();
			}

			_currentState = state;
			_currentState.OnEnter ();
		}
	}
}