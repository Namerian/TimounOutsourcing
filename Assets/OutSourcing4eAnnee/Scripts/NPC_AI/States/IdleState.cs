using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class IdleState : MonoBehaviour, IState
	{
		private IStateMachine _stateMachine;

		private bool _isActive;

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

		//===============================================
		//
		//===============================================

		private void SwitchState ()
		{
			//Debug.Log ("NPC " + this.name + " :" + "IdleState.SwitchState: called");

			if (!_isActive) {
				return;
			}

			_stateMachine.SwitchState (_stateMachine.MovementState);
		}
	}
}