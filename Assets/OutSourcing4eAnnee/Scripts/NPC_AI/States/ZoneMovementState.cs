using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class ZoneMovementState : MonoBehaviour, IState
	{
		public float _ZoneRadius = 5f;
		public GameObject _ZoneObject;

		private IStateMachine _stateMachine;

		private bool _isActive;
		private Vector3 _targetPosition;

		//===============================================
		//
		//===============================================

		void Start ()
		{
			_stateMachine = this.GetComponent<IStateMachine> ();
		}

		//===============================================
		//
		//===============================================

		public int GetActivationValue ()
		{
			return 20;
		}

		public void OnEnter ()
		{
			_isActive = true;

			Roam ();
		}

		public void OnExit ()
		{
			_isActive = false;

			_stateMachine.NavMeshAgent.Stop ();
		}

		public void OnUpdate ()
		{
			if (!_isActive) {
				return;
			}

			//check if destination reached
			if (!_stateMachine.NavMeshAgent.pathPending && _stateMachine.NavMeshAgent.remainingDistance <= _stateMachine.NavMeshAgent.stoppingDistance) {
				Roam ();
			}
		}

		//===============================================
		//
		//===============================================

		private void Roam ()
		{
			if (_ZoneObject == null) {
				Debug.LogError ("ZoneMovementState: ZoneObject not set!");
				return;
			}

			Vector3 targetPos = Random.insideUnitSphere * _ZoneRadius + _ZoneObject.transform.position;

			UnityEngine.AI.NavMeshHit hit;
			UnityEngine.AI.NavMesh.SamplePosition (targetPos, out hit, _ZoneRadius, 1);

			_targetPosition = hit.position;
			_stateMachine.NavMeshAgent.SetDestination (_targetPosition);
			_stateMachine.NavMeshAgent.Resume ();
		}
	}
}