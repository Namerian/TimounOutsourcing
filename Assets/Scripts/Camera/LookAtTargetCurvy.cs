using UnityEngine;
using System.Collections;
using FluffyUnderware.Curvy;
using FluffyUnderware.Curvy.Controllers;

public class LookAtTargetCurvy : MonoBehaviour {

    public Transform target;
    
	// Update is called once per frame
	void Update () {
        //Dirty à suppr
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SplineController>().Speed = 2f;
            target.GetComponent<SplineController>().Speed = 2f;
        }
        transform.LookAt(target);
	}
}
