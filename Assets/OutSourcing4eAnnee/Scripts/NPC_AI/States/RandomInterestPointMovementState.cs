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

		private NpcController _npcController;

		private bool _isActive;
		private InterestPoint _currentDestination;

		//===========================================================
		//
		//===========================================================

		void Start ()
		{
			_npcController = this.GetComponent<NpcController> ();
		}

		//===========================================================
		//
		//===========================================================

		public void OnEnter ()
		{
			_isActive = true;

			List<InterestPoint> possibleDestinations = GetInterestPoints ();

			if (_currentDestination != null) {
				possibleDestinations = possibleDestinations.Where (c => c != _currentDestination).ToList ();
			}

			if (possibleDestinations.Count == 0) {
				Debug.LogError ("NPC " + this.name + " :" + "RandomInterestPointMovementState: no possible destinations!");
				_npcController.SwitchState (_npcController.IdleState);
			} else {
				_currentDestination = possibleDestinations [Random.Range (0, possibleDestinations.Count)];
				_npcController.NavMeshAgent.SetDestination (_currentDestination.transform.position);
				_npcController.NavMeshAgent.Resume ();
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
			if (!_npcController.NavMeshAgent.pathPending && _npcController.NavMeshAgent.remainingDistance <= _npcController.NavMeshAgent.stoppingDistance) {
				_npcController.NavMeshAgent.Stop ();
				_npcController.SwitchState (_npcController.IdleState);
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