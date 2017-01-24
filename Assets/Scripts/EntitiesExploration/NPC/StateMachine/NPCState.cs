using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine
{
	public abstract class NPCState : MonoBehaviour
	{
		public List<NPCTransition> _listOfTransitions = new List<NPCTransition> ();
		protected UnityEngine.AI.NavMeshAgent _agent;

		public abstract void Execute ();

		public virtual NPCState step ()
		{
			foreach (NPCTransition _tempTransition in _listOfTransitions) {
				if (_tempTransition.Check ()) {
					return _tempTransition._nextState;
				}
			}
			Execute ();
			return this;
		}
	}
}
