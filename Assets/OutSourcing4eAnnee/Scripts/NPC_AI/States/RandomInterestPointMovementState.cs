using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace NPC_AI
{
	public class RandomInterestPointMovementState : MonoBehaviour, IState
	{
		public InterestPointManager.InterestType _InterestType;

		private IStateMachine _stateMachine;

		private bool _isActive;
		private InterestPoint _currentDestination;

		//===========================================================
		//
		//===========================================================

		void Start ()
		{
			_stateMachine = this.GetComponent<IStateMachine> ();
		}

		//===========================================================
		//
		//===========================================================

		public int GetActivationValue ()
		{
			return 20;
		}

		public void OnEnter ()
		{
			_isActive = true;

			List<InterestPoint> possibleDestinations = GetInterestPoints ();

			if (_currentDestination != null) {
				possibleDestinations = possibleDestinations.Where (c => c != _currentDestination).ToList ();
			}

			if (possibleDestinations.Count == 0) {
				Debug.LogError ("NPC " + this.name + " :" + "RandomInterestPointMovementState: no possible destinations!");
				_stateMachine.SwitchState (_stateMachine.IdleState);
			} else {
				_currentDestination = possibleDestinations [Random.Range (0, possibleDestinations.Count)];
				_stateMachine.NavMeshAgent.SetDestination (_currentDestination.transform.position);
				_stateMachine.NavMeshAgent.Resume ();
			}
		}

		public void OnExit ()
		{
			_isActive = false;
		}

		public void OnUpdate ()
		{
			if (!_isActive) {
				return;
			}

			//check if destination reached
			if (!_stateMachine.NavMeshAgent.pathPending && _stateMachine.NavMeshAgent.remainingDistance <= _stateMachine.NavMeshAgent.stoppingDistance) {
				_stateMachine.NavMeshAgent.Stop ();
				_stateMachine.SwitchState (_stateMachine.IdleState);
			}
		}

		//===========================================================
		//
		//===========================================================

		private List<InterestPoint> GetInterestPoints ()
		{
			InterestPointHandler pointHandler = InterestPointManager.instance.GetInterestType (_InterestType);
			return pointHandler.listIP;
		}
	}
}