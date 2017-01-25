using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class LoopingInterestPointMovementState : MonoBehaviour, IState
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

			MoveToNextPoint ();
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
				MoveToNextPoint ();
			}
		}

		//===========================================================
		//
		//===========================================================

		private List<InterestPoint> GetInterestPoints ()
		{
			return InterestPointManager.instance.GetInterestType (_InterestType).listIP;
		}

		private void MoveToNextPoint ()
		{
			List<InterestPoint> points = GetInterestPoints ();

			if (points.Count == 0) {
				_stateMachine.SwitchState (_stateMachine.IdleState);
			} else if (_currentDestination == null) {
				_currentDestination = points [0];
				_stateMachine.NavMeshAgent.SetDestination (_currentDestination.transform.position);
				_stateMachine.NavMeshAgent.Resume ();
			} else {
				int currentIndex = points.IndexOf (_currentDestination);

				if (currentIndex >= points.Count - 1) {
					_currentDestination = points [0];
					_stateMachine.NavMeshAgent.SetDestination (_currentDestination.transform.position);
					_stateMachine.NavMeshAgent.Resume ();
				} else {
					_currentDestination = points [currentIndex + 1];
					_stateMachine.NavMeshAgent.SetDestination (_currentDestination.transform.position);
					_stateMachine.NavMeshAgent.Resume ();
				}
			}
		}
	}
}