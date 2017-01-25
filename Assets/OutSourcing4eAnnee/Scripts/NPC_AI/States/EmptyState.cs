using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class EmptyState : IState
	{
		public int GetActivationValue ()
		{
			return 0;
		}

		public void OnEnter ()
		{
		}

		public void OnExit ()
		{
		}

		public void OnUpdate ()
		{
		}
	}
}