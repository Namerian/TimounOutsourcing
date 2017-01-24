using UnityEngine;
using System.Collections;
using Events;
using GameInput;
using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour, InputEvents.IActionHandler {

    [System.Serializable]

    public class MoveSettings
    {
        public float forwardVel = 12;
        public float rightVel = 12;
        public float rotateVel = 100;
        public float jumpVel = 25;
        public float distToGrounded = 0.5f;
        public LayerMask ground;
    }

    [System.Serializable]

    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable]

    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";

    }

    public MoveSettings moveSettings = new MoveSettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();

    Vector3 velocity = Vector3.zero;
    public Transform cam;
    public Transform mesh;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput;
    float turnInput;
    float jumpInput;

    public List<GameObject> listNPC = new List<GameObject>();

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSettings.distToGrounded, moveSettings.ground);
    }

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

	// Use this for initialization
	void Start () {
        targetRotation = transform.rotation;
        rBody = GetComponent<Rigidbody>();
        
        forwardInput = turnInput = jumpInput = 0;
	}

    void GetInput()
    {
        /*forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS); //interpolated
        turnInput = Input.GetAxis(inputSettings.TURN_AXIS); //interpolated
        jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS); //non-interpolated*/

        forwardInput = XInput.instance.GetStickVector(PlayerID.One, GamePadAxis.StickLeft).y;
        turnInput = XInput.instance.GetStickVector(PlayerID.One, GamePadAxis.StickLeft).x;
    }
	
	// Update is called once per frame
	void Update () {
        GetInput();
        //Turn();
	}

    void FixedUpdate()
    {
        Run();
        Jump();

        rBody.velocity = transform.TransformDirection(velocity);

    }

    void Run()
    {

        //transform.rotation = Quaternion.LookRotation(new Vector3(cam.forward.x, transform.forward.y, cam.forward.z));
        
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay || Mathf.Abs(turnInput) > inputSettings.inputDelay)
        {
            mesh.rotation = Quaternion.LookRotation(new Vector3(turnInput, transform.forward.y, forwardInput)) * Quaternion.LookRotation(new Vector3(cam.forward.x, transform.forward.y, cam.forward.z));
            transform.rotation = Quaternion.LookRotation(new Vector3(cam.forward.x, transform.forward.y, cam.forward.z));
            //move
            //rBody.velocity = transform.forward * forwardInput * moveSettings.forwardVel;
            velocity.z = moveSettings.forwardVel * forwardInput;
            velocity.x = moveSettings.rightVel * turnInput;
        }
        else
        {
            //rBody.velocity = Vector3.zero;
            velocity.x = 0;
            velocity.z = 0;
        }

        
    }

    void Turn()
    {
        if(Mathf.Abs(turnInput) > inputSettings.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(turnInput * moveSettings.rotateVel * Time.deltaTime, Vector3.up);
        }
       
        transform.rotation = targetRotation;
    }

    void Jump()
    {
        if(jumpInput > 0 && Grounded())
        {
            //jump
            velocity.y = moveSettings.jumpVel;
        }
        else if(jumpInput == 0 && Grounded())
        {
            //zero out our velocity.y
            velocity.y = 0;
        }
        else
        {
            //decreases velocity.y
            velocity.y -= physSettings.downAccel;
        }
    }

    public void OnAction(InputActionList action, InputState state)
    {
        if (action == InputActionList.Interact && state == InputState.Pressed)
        {
            
            if (listNPC.Count == 0)
            {
                return;
            }
            NPCSimpleBehavior NPC = GetNearestNPC().GetComponent<NPCSimpleBehavior>();
            if (!NPC.isSpeaking)
            {
                NPC.LookAtPlayer(this.transform.position);
                NPC.LaunchDialog();
            }
        }
    }

    public void AddNpcToList(GameObject NPC)
    {
        listNPC.Add(NPC);
    }

    public void RemoveNpcFromList(GameObject NPC)
    {
        GameObject NPCToRemove = listNPC.SingleOrDefault(r => r == NPC);
        if (NPCToRemove != null)
            listNPC.Remove(NPCToRemove);
    }

    GameObject GetNearestNPC()
    {
        GameObject nearest = listNPC[0];
        for(int i = 0; i<listNPC.Count; i++)
        {
            if (i!=0 && Vector3.Distance(listNPC[i].transform.position, this.transform.position) < Vector3.Distance(nearest.transform.position, this.transform.position))
            {
                nearest = listNPC[i];
            }
        }
        return nearest;
    }

}
