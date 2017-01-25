using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPC_AI
{
	public interface IStateMachine
	{
		NPC_AI.IState IdleState{ get; }

		NPC_AI.IState MovementState{ get; }

		NPC_AI.IState InteractionState{ get; }

		NPC_AI.IState FollowObjectState{ get; }

		NavMeshAgent NavMeshAgent{ get; }

		void SwitchState (NPC_AI.IState state);

		List<IState> GetAllStates ();
	}
}