using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InterestPointHandler : MonoBehaviour {
    public List<InterestPoint> listIP = new List<InterestPoint>();
    public InterestPointManager.InterestType interestType;

    void Start () {
        InterestPoint[] allChildren = GetComponentsInChildren<InterestPoint>();
        foreach (InterestPoint child in allChildren)
        {
            listIP.Add(child);
        }

        InterestPointManager.instance.listIPHandler.Add(this);
    }
}
