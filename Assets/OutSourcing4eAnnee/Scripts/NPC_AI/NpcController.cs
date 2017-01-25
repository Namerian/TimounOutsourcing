using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPC_AI
{
	public class NpcController : MonoBehaviour, IStateMachine
	{
		//
		public EMovementState _movementType;

		//
		private IState _currentState = null;

		private IState _idleState;
		private IState _movementState;
		private IState _interactionState;
		private IState _followObjectState;

		private NavMeshAgent _navMeshAgent;



		//===========================================================
		//
		//===========================================================

		// Use this for initialization
		void Start ()
		{
			_navMeshAgent = this.GetComponent<NavMeshAgent> ();

			//**************************************************************************
			_idleState = this.GetComponent<NPC_AI.IdleState> ();

			switch (_movementType) {
			case EMovementState.LoopingInterestPoint:
				_movementState = this.GetComponent<LoopingInterestPointMovementState> ();
				break;
			case EMovementState.RandomInterestPoint:
				_movementState = this.GetComponent<RandomInterestPointMovementState> ();
				break;
			case EMovementState.Zone:
				_movementState = this.GetComponent<ZoneMovementState> ();
				break;
			}

			_interactionState = this.GetComponent<InteractingState> ();

			if (_interactionState == null) {
				_interactionState = new EmptyState ();
			}

			_followObjectState = this.GetComponent<FollowTaggedObjectState> ();

			if (_followObjectState == null) {
				//Debug.Log ("NPC " + this.name + ": has no FollowTaggedObject State!");
				_followObjectState = new EmptyState ();
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (_currentState == null) {
				(this as IStateMachine).SwitchState (_idleState);
			}

			IState currentState = _currentState;

			_currentState.OnUpdate ();

			if (currentState.Equals (_currentState)) {
				//Debug.Log ("NPC " + this.name + ": started checking for states with higher value!");

				IState bestState = null;
				int bestActivationValue = _currentState.GetActivationValue ();

				List<IState> states = (this as IStateMachine).GetAllStates ();
				foreach (IState state in states) {
					if (state.GetActivationValue () > bestActivationValue) {
						bestState = state;
						bestActivationValue = state.GetActivationValue ();
					}
				}

				if (bestActivationValue > _currentState.GetActivationValue ()) {
					//Debug.Log ("NPC " + this.name + ": found state with higher value: " + bestState.GetType ());
					(this as IStateMachine).SwitchState (bestState);
				}
			}
		}

		//===========================================================
		// IStateMachine implementation
		//===========================================================

		NPC_AI.IState IStateMachine.IdleState{ get { return _idleState; } }

		NPC_AI.IState IStateMachine.MovementState{ get { return _movementState; } }

		NPC_AI.IState IStateMachine.InteractionState{ get { return _interactionState; } }

		NPC_AI.IState IStateMachine.FollowObjectState{ get { return _followObjectState; } }

		NavMeshAgent IStateMachine.NavMeshAgent{ get { return _navMeshAgent; } }

		void IStateMachine.SwitchState (NPC_AI.IState state)
		{
			//Debug.Log ("NPC " + this.name + " : SwitchState called : new state = " + state.GetType ());

			if (_currentState != null) {
				_currentState.OnExit ();
			}

			_currentState = state;
			_currentState.OnEnter ();
		}

		List<IState> IStateMachine.GetAllStates ()
		{
			List<IState> states = new List<IState> ();

			states.Add (_idleState);
			states.Add (_movementState);
			states.Add (_interactionState);
			states.Add (_followObjectState);

			return states;
		}
	}
}