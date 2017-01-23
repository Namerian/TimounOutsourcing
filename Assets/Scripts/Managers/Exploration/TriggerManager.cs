using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TriggerManager : MonoBehaviour {
    public static TriggerManager instance;
    public List<Trigger> triggerList = new List<Trigger>();

    void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void RemoveFromList(Trigger triggerToRemove)
    {
        Trigger itemToRemove = triggerList.SingleOrDefault(r => r == triggerToRemove);
        if (itemToRemove != null)
            triggerList.Remove(itemToRemove);
    }
}
