using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public interface IState
	{
		void OnEnter ();

		void OnExit ();

		void OnUpdate ();
	}
}