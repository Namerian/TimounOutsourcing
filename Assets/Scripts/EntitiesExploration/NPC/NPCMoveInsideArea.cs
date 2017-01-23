using UnityEngine;
using System.Collections;

public class NPCMoveInsideArea : MonoBehaviour {
    public float areaRadius;
    Vector3 startPosition;
    UnityEngine.AI.NavMeshAgent _agent;
    bool hasReachedDestination;

    void Awake()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        startPosition = this.transform.parent.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        hasReachedDestination = HasReachedDestination();
        if (hasReachedDestination)
        {
            FreeRoam();
        }
	}

    public bool HasReachedDestination()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }


    void FreeRoam()
    {
        startPosition = this.transform.parent.transform.position;
        Vector3 randomDirection = Random.insideUnitSphere * areaRadius;
        randomDirection += startPosition;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, areaRadius, 1);
        Vector3 finalPosition = hit.position;
        _agent.destination = finalPosition;
    }
}
