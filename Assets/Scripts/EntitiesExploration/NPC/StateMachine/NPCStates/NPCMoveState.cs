using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace StateMachine
{
    public class NPCMoveState : NPCState
    {
        NPCStateHandler NPCStateHandler;

        public override void Execute()
        {
            Debug.Log("MoveState");
            
            if (NPCStateHandler.hasFinishedIdle && NPCStateHandler.myNPCMovement.canMove)
            {
                
                if (NPCStateHandler.myNPC.isRandom)
                {
                    NPCStateHandler.myNPCMovement.MoveRandom();
                }
                else
                {
                    NPCStateHandler.myNPCMovement.MoveLinear();
                }
                NPCStateHandler.hasFinishedIdle = false;
            }
            NPCStateHandler.myNPCMovement.hasReachedDestination = NPCStateHandler.myNPCMovement.HasReachedDestination();

            if (!NPCStateHandler.myNPCMovement.canMove && _agent.velocity != Vector3.zero)
            {
                _agent.Stop();
            }
            if (NPCStateHandler.myNPCMovement.canMove && _agent.velocity == Vector3.zero)
            {
                _agent.Resume();
            }
        }

        // Use this for initialization
        void Start()
        {
            NPCStateHandler = this.GetComponent<NPCStateHandler>();
            _agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        public void DoMove()
        {
            NPCStateHandler.myNPCMovement.canMove = true;
        }
    }
}

