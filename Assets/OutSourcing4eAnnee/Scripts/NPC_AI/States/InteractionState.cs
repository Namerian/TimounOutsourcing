using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_AI
{
	public class InteractionState : MonoBehaviour, IState, ITriggerParent
	{
		public float _DetectionRange = 2.5f;
		public float _GreetingTime = 3f;
		public float _InteractionCoolDown = 6f;

		private IStateMachine _stateMachine;

		private bool _isActive;
		private TriggerSphereController _triggerController;
		private List<InteractionState> _interactableNPCs = new List<InteractionState> ();
		private InteractionState _currentTarget;
		private float _greetingTimer;
		private List<Cooldown> _interactionCooldowns = new List<Cooldown> ();

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

		void FixedUpdate ()
		{
			if (_interactionCooldowns.Count == 0) {
				return;
			}

			List<Cooldown> finishedCooldowns = new List<Cooldown> ();

			foreach (Cooldown cd in _interactionCooldowns) {
				cd.CooldownTimer += Time.fixedDeltaTime;

				if (cd.CooldownTimer >= _InteractionCoolDown) {
					finishedCooldowns.Add (cd);
				}
			}

			foreach (Cooldown cd in finishedCooldowns) {
				_interactionCooldowns.Remove (cd);
			}
		}

		//===============================================
		// IState implementation
		//===============================================

		public int GetActivationValue ()
		{
			if (_interactableNPCs.Count == 0) {
				return 0;
			} else if (_interactableNPCs.Count > 0 || _currentTarget != null) {
				return 80;
			}

			return 0;
		}

		public void OnEnter ()
		{
			//Debug.Log ("NPC " + this.name + ": entered Interaction State!");

			_isActive = true;
			_greetingTimer = 0f;

			_stateMachine.NavMeshAgent.Stop ();

			if (_currentTarget == null) {
				InteractionState nearestNPC = null;
				float shortestDistance = float.MaxValue;

				foreach (InteractionState npc in _interactableNPCs) {
					if (!IsNpcInCooldown (npc)) {
						float distance = (npc.transform.position - this.transform.position).magnitude;

						if (distance < shortestDistance) {
							nearestNPC = npc;
							shortestDistance = distance;
						}
					}
				}

				bool greetingSuccessful = true;

				if (nearestNPC != null) {
					_currentTarget = nearestNPC;
					greetingSuccessful = _currentTarget.Greet (this);

					if (!greetingSuccessful) {
						_stateMachine.SwitchState (_stateMachine.IdleState);
					} else {
						Debug.Log ("NPC " + this.name + " greets NPC " + _currentTarget.name);
					}
				} else {
					_stateMachine.SwitchState (_stateMachine.IdleState);
				}
			}
		}

		public void OnExit ()
		{
			_interactionCooldowns.Add (new Cooldown (_currentTarget));
			_interactableNPCs.Remove (_currentTarget);

			_isActive = false;
			_currentTarget = null;
		}

		public void OnUpdate ()
		{
			if (!_isActive) {
				return;
			}

			//
			_greetingTimer += Time.deltaTime;

			if (_greetingTimer >= _GreetingTime) {
				//Debug.Log ("NPC " + this.name + " greeting timer done!");
				_stateMachine.SwitchState (_stateMachine.IdleState);
				return;
			}

			// move towards other npc
			if (_currentTarget != null) {
				Vector3 direction = _currentTarget.transform.position - this.transform.position;

				if (direction.magnitude > _stateMachine.NavMeshAgent.stoppingDistance) {
					float magnitude = direction.magnitude - _stateMachine.NavMeshAgent.stoppingDistance;
					direction = direction.normalized * magnitude;

					_stateMachine.NavMeshAgent.SetDestination (this.transform.position + direction);
					_stateMachine.NavMeshAgent.Resume ();
				} else {
					_stateMachine.NavMeshAgent.Stop ();
				}
			} else {
				_stateMachine.NavMeshAgent.Stop ();
			}
		}

		//===============================================
		// ITriggerParent implementation
		//===============================================

		public void OnTriggerEnter (Collider other)
		{
			InteractionState otherInteractionState = other.GetComponent<InteractionState> ();

			if (otherInteractionState != null && otherInteractionState != this) {
				if (!_interactableNPCs.Contains (otherInteractionState)) {
					_interactableNPCs.Add (otherInteractionState);
				}
			}
		}

		public void OnTriggerExit (Collider other)
		{
			InteractionState otherInteractionState = other.GetComponent<InteractionState> ();

			if (otherInteractionState != null) {
				_interactableNPCs.Remove (otherInteractionState);
			}
		}

		//===============================================
		//
		//===============================================

		public bool Greet (InteractionState greeter)
		{
			if (IsNpcInCooldown (greeter)) {
				return false;
			} else if (_currentTarget == null) {
				_currentTarget = greeter;
				return true;
			}

			return false;
		}

		//===============================================
		//
		//===============================================

		private bool IsNpcInCooldown (InteractionState npc)
		{
			foreach (Cooldown cd in _interactionCooldowns) {
				if (cd.NPC == npc) {
					return true;
				}
			}

			return false;
		}

		private class Cooldown
		{
			public InteractionState NPC{ get; private set; }

			public float CooldownTimer{ get; set; }

			public Cooldown (InteractionState npc)
			{
				NPC = npc;
				CooldownTimer = 0f;
			}
		}
	}
}