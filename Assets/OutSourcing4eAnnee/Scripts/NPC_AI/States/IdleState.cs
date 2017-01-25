using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class IdleState : MonoBehaviour, IState
	{
		private IStateMachine _stateMachine;

		private bool _isActive;
		private bool _switchToMovement;

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
			_switchToMovement = false;

			Invoke ("SwitchState", 1.5f);
		}

		public void OnExit ()
		{
			_isActive = false;
			_switchToMovement = false;
		}

		public void OnUpdate ()
		{
			if (!_isActive) {
				return;
			}

			if (_switchToMovement) {
				_stateMachine.SwitchState (_stateMachine.MovementState);
			}
		}

		//===============================================
		//
		//===============================================

		private void SwitchState ()
		{
			if (!_isActive) {
				return;
			}

			_switchToMovement = true;
		}
	}
}