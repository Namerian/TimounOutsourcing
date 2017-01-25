using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class InteractingState : MonoBehaviour, IState
	{
		private bool _isActive;

		private IStateMachine _stateMachine;

		void Start ()
		{
			_stateMachine = this.GetComponent<IStateMachine> ();
		}

		public int GetActivationValue ()
		{
			return 20;
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