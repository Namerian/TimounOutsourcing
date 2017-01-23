using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InterestPointManager : MonoBehaviour {
    public static InterestPointManager instance;

    public List<InterestPointHandler> listIPHandler = new List<InterestPointHandler>();
    public enum InterestType
    {
        Market,
        Church,
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public InterestPointHandler GetInterestType(InterestType parInterestType)
    {
        foreach(InterestPointHandler IPHandler in listIPHandler)
        {
            if(IPHandler.interestType == parInterestType)
            {
                return IPHandler;
            }
        }
        return null;
    }

}
