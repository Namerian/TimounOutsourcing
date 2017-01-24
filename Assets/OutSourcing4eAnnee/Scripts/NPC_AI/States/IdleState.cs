using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class IdleState : MonoBehaviour, IState
	{
		private bool _isActive;

		private NpcController _npcController;

		void Start ()
		{
			_npcController = this.GetComponent<NpcController> ();
		}

		public void OnEnter ()
		{
			//Debug.Log ("NPC " + this.name + " :" + "IdleState.OnEnter: called");

			_isActive = true;

			Invoke ("SwitchState", 1f);
		}

		public void OnExit ()
		{
			_isActive = false;
		}

		public void OnUpdate ()
		{
		}

		private void SwitchState ()
		{
			//Debug.Log ("NPC " + this.name + " :" + "IdleState.SwitchState: called");

			if (!_isActive) {
				return;
			}

			_npcController.SwitchState (_npcController.MovementState);
		}
	}
}