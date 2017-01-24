using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class ZoneMovementState : MonoBehaviour, IState
	{
		private bool _isActive;

		private NpcController _npcController;

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
	}
}