using UnityEngine;
using System.Collections;

namespace StateMachine
{
    public class NPCIdleState : NPCState
    {
        bool isExecuting;
        NPCStateHandler NPCStateHandler;
        void Start()
        {
            _agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
            NPCStateHandler = this.GetComponent<NPCStateHandler>();
        }

        public override void Execute()
        {
            if(_agent.velocity != Vector3.zero)
            {
                _agent.Stop();
            }
            
            if (!isExecuting)
            {
                
                isExecuting = true;
                StartCoroutine(WaitForCoroutine());
            }
            
        }

        IEnumerator WaitForCoroutine()
        {
            NPCStateHandler.hasReachedDest = false;
            NPCStateHandler.hasFinishedIdle = false;
            yield return new WaitForSeconds(1f);
            NPCStateHandler.hasFinishedIdle = true;
            isExecuting = false;
        }
    }
}
