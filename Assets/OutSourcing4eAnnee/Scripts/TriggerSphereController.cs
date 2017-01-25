using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSphereController : MonoBehaviour
{

	private ITriggerParent _parent;
	private float _sphereRadius;

	// Use this for initialization
	void Start ()
	{
		SphereCollider collider = this.gameObject.AddComponent<SphereCollider> ();
		collider.isTrigger = true;
		collider.radius = _sphereRadius;

		Rigidbody rigidbody = this.gameObject.AddComponent<Rigidbody> ();
		rigidbody.useGravity = false;
		rigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	/*void Update ()
	{
		
	}*/

	/*void OnCollisionEnter (Collision collision)
	{
		Debug.Log ("test2");
	}*/

	void OnTriggerEnter (Collider other)
	{
		//Debug.Log ("test");
		_parent.OnTriggerEnter (other);
	}

	void OnTriggerExit (Collider other)
	{
		_parent.OnTriggerExit (other);
	}

	public void Initialize (ITriggerParent parent, float radius)
	{
		_parent = parent;
		_sphereRadius = radius;
	}
}
