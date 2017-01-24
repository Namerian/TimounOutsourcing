using UnityEngine;
using System.Collections;

public abstract class Trigger : MonoBehaviour {

	public enum TriggerType
    {
        Image,
        Combat,
        Enable,
        Disable
    }

    protected TriggerType triggerType;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Execute();
        }
    }

    protected abstract void Execute();
    protected abstract void OnDestroy();
}
