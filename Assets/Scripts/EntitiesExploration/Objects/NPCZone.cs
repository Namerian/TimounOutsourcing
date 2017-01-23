using UnityEngine;
using System.Collections;

public class NPCZone : MonoBehaviour {
    SphereCollider _sphereCollider;
    // Use this for initialization
    void Start () {
        _sphereCollider = GetComponent<SphereCollider>();
        NPCMoveInsideArea[] temp = GetComponentsInChildren<NPCMoveInsideArea>();
        if(temp.Length > 0)
        {
            foreach(NPCMoveInsideArea parNPC in temp)
            {
                parNPC.areaRadius = _sphereCollider.radius;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
