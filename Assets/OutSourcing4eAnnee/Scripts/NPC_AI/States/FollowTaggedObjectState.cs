using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class FollowTaggedObjectState : MonoBehaviour, IState, ITriggerParent
	{
		public string _TagToFollow = "";
		public float _DetectionRange = 3f;
		public int _BaseActivationValue = 40;

		private IStateMachine _stateMachine;

		private bool _isActive;
		private TriggerSphereController _triggerController;
		private List<GameObject> _taggedObjectsInRange = new List<GameObject> ();
		private GameObject _targetObject;

		//===============================================
		//
		//===============================================

		void Start ()
		{
			_stateMachine = this.GetComponent<IStateMachine> ();

			GameObject triggerObj = new GameObject ();
			triggerObj.transform.parent = this.transform;
			triggerObj.transform.localPosition = Vector3.zero;
			_triggerController = triggerObj.AddComponent<TriggerSphereController> ();
			_triggerController.Initialize (this, _DetectionRange);
		}

		/*void OnCollisionEnter (Collision other)
		{
			if (other.gameObject.Equals (_targetObject)) {
				Debug.Log ("NPC " + this.name + ": collided with target");
				_hasCollidedWithTarget = true;
			}
		}*/

		//===============================================
		// IState implementation
		//===============================================

		public int GetActivationValue ()
		{
			if (_taggedObjectsInRange.Count == 0) {
				//Debug.Log ("test");
				return 0;
			} else {
				//Debug.Log ("NPC " + this.name + ": should switch to FollowTaggedObject State soon!");
				return _BaseActivationValue;
			} 
		}

		public void OnEnter ()
		{
			Debug.Log ("NPC " + this.name + ": entered FollowTaggedObject State!");

			_isActive = true;

			GameObject nearestObject = null;
			float shortestDistance = float.MaxValue;

			foreach (GameObject taggedObject in _taggedObjectsInRange) {
				float distance = (taggedObject.transform.position - this.transform.position).magnitude;

				if (distance < shortestDistance) {
					nearestObject = taggedObject;
					shortestDistance = distance;
				}
			}

			if (nearestObject != null) {
				_targetObject = nearestObject;
				_stateMachine.NavMeshAgent.SetDestination (_targetObject.transform.position);
				_stateMachine.NavMeshAgent.Resume ();
			}
		}

		public void OnExit ()
		{
			_isActive = false;

			_stateMachine.NavMeshAgent.Stop ();
		}

		public void OnUpdate ()
		{
			if (!_isActive) {
				return;
			}

			if (_targetObject == null) {
				_stateMachine.SwitchState (_stateMachine.IdleState);
			} else {
				_stateMachine.NavMeshAgent.SetDestination (_targetObject.transform.position);
			}
		}

		//===============================================
		// ITriggerParent implementation
		//===============================================

		public void OnTriggerEnter (Collider other)
		{
			//Debug.Log ("NPC " + this.name + ": FollowTaggedObjectState:OnTriggerEnter called!");

			if (other.CompareTag (_TagToFollow)) {
				if (!_taggedObjectsInRange.Contains (other.gameObject)) {
					//Debug.Log ("NPC " + this.name + ": tagged object " + other.name + " in range!");
					_taggedObjectsInRange.Add (other.gameObject);
					//Debug.Log ("NPC " + this.name + ": objects in range count = " + _taggedObjectsInRange.Count);
				}
			}
		}

		public void OnTriggerExit (Collider other)
		{
			if (other.CompareTag (_TagToFollow)) {
				_taggedObjectsInRange.Remove (other.gameObject);

				if (other.gameObject.Equals (_targetObject)) {
					_targetObject = null;
				}
			}
		}
	}
}