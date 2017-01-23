using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NPCMovement : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent _agent;
    NPC _myNPC;
    NPCStateHandler _NPCstateHandler;
    public bool canMove;
    public bool hasReachedDestination;

    //List<InterestPointHandler> listHandler = new List<InterestPointHandler>();
    public List<InterestPoint> listIP = new List<InterestPoint>();
    public InterestPoint IPDestination;
    InterestPointHandler IPHandler;

    void Start()
    {
        _agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        _myNPC = GetComponent<NPC>();
        _NPCstateHandler = GetComponent<NPCStateHandler>();
        canMove = true;

    }

    public void MoveRandom()
    {
        //listHandler = InterestPointManager.instance.listIPHandler;
        IPHandler = InterestPointManager.instance.GetInterestType(_myNPC.interestType);
        listIP = IPHandler.listIP;
        if (IPDestination != null)
        {

            listIP = listIP.Where(c => c != IPDestination).ToList();
        }

        IPDestination = listIP[Random.Range(0, listIP.Count)];

        AssignDestination(IPDestination.gameObject);
    }

    public void MoveLinear()
    {
        if (!_NPCstateHandler.hasFinishedIdle)
        {
            return;
        }
        //listHandler = InterestPointManager.instance.listIPHandler;
        IPHandler = InterestPointManager.instance.GetInterestType(_myNPC.interestType);
        listIP = IPHandler.listIP;

        if (IPDestination == null)
        {
            IPDestination = listIP[0];
            AssignDestination(IPDestination.gameObject);
        }
        else
        {
            int index = listIP.FindIndex(c => c == IPDestination);
            if (index + 1 == listIP.Count)
            {
                IPDestination = listIP[0];
            }
            else
            {
                IPDestination = listIP[index + 1];
            }
            AssignDestination(IPDestination.gameObject);
        }
    }

    public void AssignDestination(GameObject destObject)
    {
        if (canMove)
        {
            _agent.SetDestination(destObject.transform.position);
        }
    }

    public bool HasReachedDestination()
    {
        if (!_agent.pathPending && IPDestination != null)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f && Vector3.Distance(this.transform.position, IPDestination.transform.position) <= _agent.stoppingDistance)
                {
                    _NPCstateHandler.hasReachedDest = true;
                    return true;
                }
                else
                {
                    _NPCstateHandler.hasReachedDest = false;
                    return false;
                }
            }
        }
        _NPCstateHandler.hasReachedDest = false;
        return false;
    }
}
