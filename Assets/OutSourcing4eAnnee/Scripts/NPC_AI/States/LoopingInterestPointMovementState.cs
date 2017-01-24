using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class LoopingInterestPointMovementState : MonoBehaviour, IState
	{
		public InterestPointManager.InterestType _InterestType;

		private NpcController _npcController;

		private bool _isActive;

		void Start ()
		{
			_npcController = this.GetComponent<NpcController> ();
		}

		public void OnEnter ()
		{
			_isActive = true;


		}

		public void OnExit ()
		{
			_isActive = false;
		}

		public void OnUpdate ()
		{
		}

		private List<InterestPoint> GetInterestPoints ()
		{
			return InterestPointManager.instance.GetInterestType (_InterestType).listIP;
		}
	}
}