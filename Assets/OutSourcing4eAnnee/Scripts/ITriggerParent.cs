using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerParent
{
	void OnTriggerEnter (Collider other);

	void OnTriggerExit (Collider other);
}
