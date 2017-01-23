using UnityEngine;
using Events;
using GameInput;
using System;
using DG.Tweening;

[RequireComponent(typeof(CharacterControllerLogic))]
public class CarryController : MonoBehaviour, 
    InputEvents.IActionHandler
    {

    #region variables (private)

    [SerializeField]
    private LayerMask carriableMask;
    [SerializeField]
    private Vector3 carryPostionOffset = new Vector3(0,2,0);
    [SerializeField]
    private float carryDelay = 0.5f;

    private float distanceToCarryDetection = 0.4f;

    [SerializeField]
    private Transform carriedObject;

    private CharacterControllerLogic _CharacterController;
    #endregion

    #region Properties (public)

    #endregion

    // Use this for initialization
    void Awake () 
	{
        _CharacterController = GetComponent<CharacterControllerLogic>();
        EventCenter.AddSubscriber(this);
    }
	
	// Update is called once per frame
	void Update () 
	{
        if (IsCarrying() && _CharacterController.CanMove)
        {
            carriedObject.transform.position = transform.position + carryPostionOffset;//* transform.forward ;

            carriedObject.transform.rotation = transform.rotation;


        }
	
	}
	
    #region  Methods

    public bool IsCarrying()
    {
        return carriedObject != null;
    }

    private bool CheckForCarriableObject(ref Transform carriableObject)
    {
        Ray frontRay = new Ray(transform.position + new Vector3(0,0.2f,0), transform.forward);
        RaycastHit potentialObject;

        if (Physics.Raycast(frontRay,out potentialObject, distanceToCarryDetection, carriableMask))
        {
            carriableObject = potentialObject.transform;
            return true;
        }

        return false;
    }

    private void CarryInit(Transform carriableObject)
    {
        _CharacterController.CanMove = false;

        carriableObject.GetComponent<BasePhysics>().isCarried = true;

        carriableObject.transform.DOJump(transform.position + carryPostionOffset, 0, 1, carryDelay).OnComplete(() => Carry());
        carriableObject.GetComponent<Rigidbody>().isKinematic = true;

        //Debug.Log("Carrying the object");
    }

    private void Carry()
    {
        _CharacterController.CanMove = true;
    }

    private void Drop(Transform carriableObject)
    {
        //Debug.Log("Should drop your object");
        carriedObject = null;
        carriableObject.GetComponent<Rigidbody>().isKinematic = false;
        carriableObject.GetComponent<BasePhysics>().isCarried = false;

        //carriableObject.GetComponent<BasePhysics>().Bump(carriableObject.transform.position,_CharacterController.Speed);
    }
    #endregion

    #region Input Handling
    public void OnAction(InputActionList action, InputState state)
    {
        if (action == InputActionList.Interact && state == InputState.Pressed)
        {
            if (carriedObject != null)
            {
                Drop(carriedObject);
            }
            else
            {
                if (CheckForCarriableObject(ref carriedObject))
                    CarryInit(carriedObject);
            }
        }

    }
    
    #endregion
}
