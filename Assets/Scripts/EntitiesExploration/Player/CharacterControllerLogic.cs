using UnityEngine;
using System.Collections;
using GameInput;
using System.Collections.Generic;
using System.Linq;
using Events;
using DG.Tweening;
using Exploration;
using ThirdPersonCamera;


#region Animation Parameters
public class CharacterAnimationParam
{
    public const string direction = "direction";
    public const string speed = "Speed";
    public const string angle = "angle";

    public const string onClimb = "OnClimb";
    public const string onJump = "OnJump";
    public const string onFall = "OnFall";

    public const string isLedgeGrabbing = "IsLedgeGrabbing";
}
#endregion

public enum ColliderAxis
{
    XAxis = 0,
    YAxis = 1,
    ZAxis = 2
}

[System.Serializable]
public class JumpSettings
{
    public LayerMask jumpMask;

    public float jumpDetectionOffset = 0.2f;

    public float topJumpOffsetMultiplier = 0.4f;

    public float jumpLedgeGrabLimit = 2.6f;
    public float grabLimit = 1.9f;
    public float jumpLimit = 0.8f;

    public float dropHeightLimit = 2.5f;
    public float dropToLedgeLimit = 3f;


}

[System.Serializable]
public class MoveSettings
{
    public LayerMask groundMask;

    public float speedMultiplier = 5f;
    public float speedDeceleration = 0.8f;

    public float speedDampTime = 0.05f; 

    public float rotationDegreePerSecond = 120f;
    public float directionSpeed = 1.5f;

    public float crawlMultiplier = 1.5f;
    public float crawlHeightLimit = 1.8f;

    public float ledgeMultiplier = 1.1f;
}

[RequireComponent(typeof(Rigidbody))]
public class CharacterControllerLogic : MonoBehaviour,
    InputEvents.IActionHandler,
    ExplorationEvents.IExplorationEnterHandler,
    ExplorationEvents.IExplorationEndHandler
{
    public Transform shape;
    public Material mat;

    #region Variables (private)

    // Components
    //[SerializeField]
    private CameraController gamecam;
    //[SerializeField]
    private CapsuleCollider capCollider;
    //[SerializeField]
    private Animator animator;
    private Rigidbody rBody;

    //Readying up all settings
    [SerializeField]
    private JumpSettings jumpSetting = new JumpSettings();
    [SerializeField]
    private MoveSettings moveSetting = new MoveSettings();

    [SerializeField]
    private float characterHeight = 1.2f;

    // Private global only
    private float inputLeftX = 0f;
    private float inputLeftY = 0f;
    private float speed = 0f;
    private float direction = 0f;
    private float charAngle = 0f;
    private Vector3 vel = Vector3.zero;

    public bool isCrawling = false;
    public bool isForcedCrawling = false;
    private bool canClimb = false;
    private bool canMove = false;
    private bool canDrop = false;
    private bool isLedgeGrabbing = false;

    private Vector3 moveToPosition;

    //Debug box helpers
    private Vector3 debugBox_Center;
    private Vector3 debugCapsule_End;
    private Vector3 debugBox_Size;
    private Color debugBox_Color;

    // Sprint stuff (to be deleted ?)
    /*private const float SPRINT_SPEED = 2.0f;
    private const float SPRINT_FOV = 75.0f;
    private const float NORMAL_FOV = 60.0f;
    [SerializeField]
    private float fovDampTime = 3f;*/
    #endregion


    #region Properties (public)

    public List<GameObject> listNPC = new List<GameObject>();

    public Animator Animator
    {
        get
        {
            return this.animator;
        }
    }

    public float Speed
    {
        get
        {
            return this.speed;
        }
    }

    public bool CanMove
    {
        get
        {
            return canMove;
        }
        set
        {
            canMove = value;
        }
    }

    public float LocomotionThreshold { get { return 0.2f; } }

    #endregion


    #region Unity event functions


    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }


    /// <summary>
    /// Use this for initialization.
    /// </summary>
    void Start()
    {

        rBody = GetComponent<Rigidbody>();
        capCollider = GetComponent<CapsuleCollider>();

        if (Camera.main.GetComponent<CameraController>())
        {
            gamecam = Camera.main.GetComponent<CameraController>();
        }
        else
        {
            Debug.LogError("The " + Camera.main.name + " must have a Third Person Camera Component attached");
        }
        

        
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {

        if (animator /*&& gamecam.CamState != ThirdPersonCamera.CamStates.FirstPerson*/ && ContextManager.instance.currentContext == InputContextList.Exploration)
        {
            // Pull values from controller/keyboard
            inputLeftX = XInput.instance.GetStickVector(PlayerID.One, GamePadAxis.StickLeft).x;
            inputLeftY = XInput.instance.GetStickVector(PlayerID.One, GamePadAxis.StickLeft).y;
            charAngle = 0f;
            direction = 0f;
            float charSpeed = 0f;

            // Translate controls stick coordinates into world/cam/character space
            StickToWorldspace(this.transform, gamecam.transform, ref direction, ref charSpeed, ref charAngle, false);
            speed = charSpeed;

            if (!canMove && GetComponent<CarryController>().IsCarrying())
                speed = 0;

            /* Sprint stuff
            if (IsSprinting)
            {
                speed = Mathf.Lerp(speed, SPRINT_SPEED, Time.deltaTime);
                gamecam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(gamecam.GetComponent<Camera>().fieldOfView, SPRINT_FOV, fovDampTime * Time.deltaTime);
            }
            else
            {
                speed = charSpeed;
                gamecam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(gamecam.GetComponent<Camera>().fieldOfView, NORMAL_FOV, fovDampTime * Time.deltaTime);
            }*/

                /* Speed stuff
                if (speed > LocomotionThreshold)    // Dead zone
                {
                    if (!IsInPivot())
                    {
                        Animator.SetFloat(CharacterAnimationParam.angle, charAngle);
                    }
                }
                if (speed < LocomotionThreshold && Mathf.Abs(inputLeftX) < 0.05f)    // Dead zone
                {
                    animator.SetFloat(CharacterAnimationParam.direction, 0f);
                    animator.SetFloat(CharacterAnimationParam.angle, 0f);
                }*/
        }
        else
        {
            isCrawling = false;
            canClimb = false;
            speed = 0f;
        }

        animator.SetBool(CharacterAnimationParam.isLedgeGrabbing, isLedgeGrabbing);
        animator.SetFloat(CharacterAnimationParam.speed, speed, moveSetting.speedDampTime, Time.deltaTime);

        //Not used with current animator
        //animator.SetFloat(CharacterAnimationParam.direction, direction, directionDampTime, Time.deltaTime);

    }

    /// <summary>
    /// Any code that moves the character needs to be checked against physics
    /// </summary>
    void FixedUpdate()
    {
        // Speed Handling
        float _SpeedMultiplier;

        if(!GetComponent<CarryController>().IsCarrying())
            CheckForHeights();

        //canDrop = false;

        if (isLedgeGrabbing && canMove)
        {

            //CheckSideObstacles and available surface
            CheckForLedgeDrop();

            float heightOffset = 0.1f;
            float sideOffset = 0.2f;

            Ray rightRay = new Ray(transform.position + new Vector3(0, characterHeight - heightOffset, 0) + transform.right * sideOffset, transform.forward + transform.right);
            Ray leftRay = new Ray(transform.position + new Vector3(0, characterHeight - heightOffset, 0) + transform.right * -sideOffset, transform.forward + -transform.right);


            Debug.DrawRay(transform.position + new Vector3(0, characterHeight - heightOffset, 0) + transform.right * sideOffset, transform.forward + transform.right, Color.white);
            Debug.DrawRay(transform.position + new Vector3(0, characterHeight - heightOffset, 0) + transform.right * -sideOffset, transform.forward + -transform.right, Color.white);

            
            if (!Physics.Raycast(rightRay, 0.5f, jumpSetting.jumpMask) && inputLeftX > 0.2f)
            {
                vel *= moveSetting.speedDeceleration;
                //Debug.Log("Nothing right");
            }
            else if (!Physics.Raycast(leftRay, 0.5f, jumpSetting.jumpMask) && inputLeftX < -0.2f)
            {
                vel *= moveSetting.speedDeceleration;
                //Debug.Log("Nothing left");
            }
            else if (IsInLocomotion())
            {
                vel = Vector3.right * moveSetting.ledgeMultiplier * inputLeftX;
            }

            vel.y = 0;

        }
        else if(canMove)
        {
            if (!GetComponent<CarryController>().IsCarrying())
                CheckForLedge();

            // Rotate character into right direction if not moving
            if (speed != 0 /*&& gamecam.CamState == ThirdPersonCamera.CamStates.Free*/ )
            {
                this.transform.rotation = Quaternion.LookRotation(new Vector3(inputLeftX, transform.forward.y, inputLeftY)) * Quaternion.LookRotation(new Vector3(gamecam.transform.forward.x, transform.forward.y, gamecam.transform.forward.z));
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            }
            if (!GetComponent<CarryController>().IsCarrying())
                CheckForCrawl();

            //Setting up crawling if required
            if (isCrawling)
            {
                _SpeedMultiplier = moveSetting.crawlMultiplier;
                capCollider.direction = (int)ColliderAxis.ZAxis;
            }
            else
            {
                _SpeedMultiplier = moveSetting.speedMultiplier;
                capCollider.direction = (int)ColliderAxis.YAxis;
            }

            if(IsInLocomotion())
            {
                vel = Vector3.forward * _SpeedMultiplier * speed;
            }

            vel.y = rBody.velocity.y;

        }

        //Making sure deceleration is real if not using sticks.
        if (!IsInLocomotion() || !canMove)
        {
            vel *= moveSetting.speedDeceleration;
            vel.y = rBody.velocity.y;
        }

        


        rBody.velocity = transform.TransformDirection(vel);

        // If not in free camera mode, Rotate character model if stick is tilted right or left, but only if character is moving in that direction
        /*
        if (IsInLocomotion() && gamecam.CamState != ThirdPersonCamera.CamStates.Free && ((direction >= 0 && inputLeftX >= 0) || (direction < 0 && inputLeftX < 0)))
        {
            Debug.Log("fsa");
            Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (inputLeftX < 0f ? -1f : 1f), 0f), Mathf.Abs(inputLeftX));
            Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
            this.transform.rotation = (this.transform.rotation * deltaRotation);
        }
        */
        /*
        if (IsInLocomotion() && gamecam.CamState != ThirdPersonCamera.CamStates.Free && !IsInPivot() && ((direction >= 0 && inputLeftX >= 0) || (direction < 0 && inputLeftX < 0)))
        {
            Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (inputLeftX < 0f ? -1f : 1f), 0f), Mathf.Abs(inputLeftX));
            Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
            this.transform.rotation = (this.transform.rotation * deltaRotation);
        }*/

    }

    

    /// <summary>
    /// Debugging information should be put here.
    /// </summary>
    void OnDrawGizmos()
    {
        //if (debugCapsule) DebugExtension.DrawCapsule(debugCapsule_Start, debugCapsule_End, debugCapsule_Color, debugCapsule_Radius);
    }

    #endregion


    #region Methods
    /// <summary>
    /// Returns true if currently on the ground
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        animator.ResetTrigger(CharacterAnimationParam.onFall);
        Debug.DrawRay(transform.position, new Vector3(0,0.1f,0), Color.black);
        return Physics.Raycast(transform.position + new Vector3( 0,0.02f,0) , Vector3.down, 0.1f, moveSetting.groundMask.value);
    }

    /// <summary>
    /// Returns true if 'moving'
    /// </summary>
    /// <returns></returns>
    public bool IsInLocomotion()
    {
        return speed >= LocomotionThreshold;
    }

    /// <summary>
    /// Translates the stick Vector to inGame world space, relative to a camera orbiting around a root. 
    /// </summary>
    /// <param name="root"> Root of the object to reference to</param>
    /// <param name="camera">Said Camera</param>
    /// <param name="directionOut"> direction offset you should move by</param>
    /// <param name="speedOut"> Magnitude of sticks </param>
    /// <param name="angleOut"> Angle difference to current angle</param>
    /// <param name="isPivoting">  Won't update angle value if true </param>
    public void StickToWorldspace(Transform root, Transform camera, ref float directionOut, ref float speedOut, ref float angleOut, bool isPivoting)
    {
        Vector3 rootDirection = root.forward;

        Vector3 stickDirection = new Vector3(inputLeftX, 0, inputLeftY);

        speedOut = stickDirection.sqrMagnitude;

        // Get camera rotation
        Vector3 CameraDirection = camera.forward;
        CameraDirection.y = 0.0f; // kill Y
        Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, Vector3.Normalize(CameraDirection));

        // Convert joystick input in Worldspace coordinates
        Vector3 moveDirection = referentialShift * stickDirection;
        Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);
        
        /* Green is for direction to move to calculated from camera angle
         * Magenta for forward root of mesh
         * Blue is the stick direction in reference to the forward root.
         */
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), moveDirection, Color.green);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), rootDirection, Color.magenta);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), stickDirection, Color.blue);
        Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2.5f, root.position.z), axisSign, Color.red);

        float angleRootToMove = Vector3.Angle(rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);

        if (!isPivoting)
        {
            angleOut = angleRootToMove;
        }
        angleRootToMove /= 180f;

        directionOut = angleRootToMove * moveSetting.directionSpeed;
    }

    /// <summary>
    /// Checks for Objects on top of player, forcing him into crawling if required
    /// </summary>
    private void CheckForCrawl()
    {
        if (!isCrawling && capCollider.direction == (int)ColliderAxis.ZAxis && Physics.Raycast(transform.position, Vector3.up, moveSetting.crawlHeightLimit, moveSetting.groundMask.value))
        {
            isForcedCrawling = true;
            isCrawling = true;
        }
        else if (isForcedCrawling && !Physics.Raycast(transform.position, Vector3.up, moveSetting.crawlHeightLimit, moveSetting.groundMask.value))
        {
            isCrawling = false;
            isForcedCrawling = false;
        }
    }

    /// <summary>
    /// Checks for heights in front of the player, if detected, checks their height and if there is enough space on top for the player. If so switches canJump to True
    /// </summary>
    private void CheckForHeights()
    {
        Ray frontRay = new Ray(transform.position + new Vector3(0, jumpSetting.jumpDetectionOffset, 0), transform.forward);
        RaycastHit frontObject;
         
        //Debug for front object detection
        Debug.DrawRay(transform.position + new Vector3(0, jumpSetting.jumpDetectionOffset, 0), transform.forward, Color.yellow);

        // Debug for nothing on top of player
        Debug.DrawRay(transform.position, new Vector3(0, 2, 0), Color.black);

        //Checks for front object and nothing on top
        if (Physics.Raycast(frontRay, out frontObject, 1f, jumpSetting.jumpMask.value) && !Physics.Raycast(transform.position, Vector3.up, 2f, jumpSetting.jumpMask.value))
        {
            //Debug and Check if not at side of a wall
            Debug.DrawRay(transform.position + new Vector3(0, jumpSetting.jumpDetectionOffset, 0), transform.forward + transform.right, Color.yellow);
            Debug.DrawRay(transform.position + new Vector3(0, jumpSetting.jumpDetectionOffset, 0), transform.forward - transform.right, Color.yellow);
            if(!Physics.Raycast(transform.position + new Vector3(0, jumpSetting.jumpDetectionOffset, 0), transform.forward + transform.right,1f,jumpSetting.jumpMask.value) 
                || 
                !Physics.Raycast(transform.position + new Vector3(0, jumpSetting.jumpDetectionOffset, 0), transform.forward - transform.right, 1f, jumpSetting.jumpMask.value))
            {
                Debug.Log("Not enough wall space");
                canClimb = false;
                return;
            }


            Vector3 plateformPosition = new Vector3(frontObject.point.x, frontObject.transform.position.y + frontObject.collider.bounds.size.y / 2, frontObject.point.z) + transform.forward * jumpSetting.topJumpOffsetMultiplier;

            //This is for objecs which the capsule cast might not detect, Not usefull ?
            //Debug.DrawRay(new Vector3(frontObject.point.x, frontObject.transform.position.y + frontObject.collider.bounds.size.y / 2 + 0.01f, frontObject.point.z), Vector3.forward, Color.green);

            //Check if can be climbed
            if (plateformPosition.y - transform.position.y < jumpSetting.grabLimit)
            {
                //Debugs for Nothing on platform
                debugBox_Size = GetComponent<Collider>().bounds.size * 1.7f;
                debugBox_Center = plateformPosition + new Vector3(0, debugBox_Size.y / 2 + 0.01f, 0) /*+ new Vector3(0, 0.1f, 0)*/;
                debugBox_Color = Color.black;
                DebugExtension.DebugBounds(new Bounds(debugBox_Center, debugBox_Size)/*new Vector3(1,1,1) * debugCapsule_Radius *2)*/, debugBox_Color);

                //Check for nothing on platform
                if (Physics.CheckBox(debugBox_Center, debugBox_Size / 2, this.transform.rotation, moveSetting.groundMask.value))
                {
                    Debug.Log("No space to climb ");
                    canClimb = false;
                    return;
                }

                //Store plateform position for future jump
                canClimb = true;
                moveToPosition = plateformPosition;

                //Debug.Log("Can climb here " + (plateformPosition.y - transform.position.y));


            }// Check for Grab limit
            else if (plateformPosition.y - transform.position.y >= jumpSetting.grabLimit && plateformPosition.y - transform.position.y < jumpSetting.jumpLedgeGrabLimit)
            {
                //Debug if space for player at grab position
                debugBox_Size = GetComponent<Collider>().bounds.size * 1.2f;
                debugBox_Center = new Vector3(frontObject.point.x, frontObject.transform.position.y + frontObject.collider.bounds.size.y / 2, frontObject.point.z) + this.transform.forward * -0.33f;
                debugBox_Color = Color.magenta;
                DebugExtension.DebugBounds(new Bounds(debugBox_Center, debugBox_Size), debugBox_Color);
                
                //Check for space for player at grab position
                if (Physics.CheckBox(debugBox_Center, debugBox_Size / 2, this.transform.rotation, moveSetting.groundMask.value))
                {
                    Debug.Log("Can't Grab here");
                    canClimb = false;
                    return;
                }

                //Debug for hand location
                debugBox_Size = new Vector3(0.2f, 0.2f, 0.2f) + this.transform.right * 0.8f; // Kinda Dirty way to do this...
                debugBox_Center = new Vector3(frontObject.point.x, frontObject.transform.position.y + frontObject.collider.bounds.size.y / 2 + debugBox_Size.y/2 + 0.01f, frontObject.point.z) + this.transform.forward *0.05f;
                debugBox_Color = Color.green;
                DebugExtension.DebugBounds(new Bounds(debugBox_Center, debugBox_Size)/*new Vector3(1,1,1) * debugCapsule_Radius *2)*/, debugBox_Color);

                //Check for hand space
                if (Physics.CheckBox(debugBox_Center, debugBox_Size / 2, this.transform.rotation, moveSetting.groundMask.value))
                {
                    Debug.Log("No space for hands");
                    canClimb = false;
                    return;
                }

                //Store position if possible
                canClimb = true;
                moveToPosition = new Vector3(frontObject.point.x, (frontObject.transform.position.y + frontObject.collider.bounds.size.y / 2), frontObject.point.z) + transform.forward * -0.2f;
                
                //Debug.Log("Can ledge Grab here " + (plateformPosition.y - transform.position.y));
            }
        }
        else
        {
            canClimb = false;
        }
    }


    /// <summary>
    /// Checks if the player can drop down to the ground, designed to be usied during a Ledge Grab tho
    /// </summary>
    private void CheckForLedgeDrop()
    {
        Debug.DrawRay(transform.position, new Vector3(0, -3f, 0), Color.yellow);

        Ray dropRay = new Ray(transform.position + new Vector3(0, 0.02f, 0), Vector3.down);
        RaycastHit dropToObject;

        if (Physics.Raycast(dropRay,out dropToObject, jumpSetting.dropHeightLimit, moveSetting.groundMask.value))
        {
            if (!Physics.CapsuleCast(dropToObject.point, dropToObject.point + new Vector3(0,characterHeight,0), 0.08f, Vector3.up))
            {
                Debug.DrawRay(dropToObject.point, new Vector3(0, 2, 0), Color.yellow);
                canDrop = true;
                //moveToPosition = plateformPosition;
                //Debug.Log("Can drop here ");           
            }
        }
    }

    /// <summary>
    /// Checks for edges where to player might be able to drop down to.
    /// </summary>
    private void CheckForLedge()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.2f, 0), transform.forward + -transform.up, Color.magenta);

        Ray edgeRay = new Ray(transform.position + new Vector3(0, 0.2f, 0), transform.forward + -transform.up);
        RaycastHit dropToObject;

        if (!Physics.Raycast(edgeRay, out dropToObject, jumpSetting.dropToLedgeLimit, moveSetting.groundMask.value))
        {
            /*if (!Physics.CapsuleCast(dropToObject.point, dropToObject.point + new Vector3(0, characterHeight, 0), 0.08f, Vector3.up))
            {
                Debug.DrawRay(dropToObject.point, new Vector3(0, 2, 0), Color.yellow);
                canDrop = true;
                //moveToPosition = plateformPosition;
                
            }*/

            //Debug.Log("Can ledge grab here ");
        }
    }
    /// <summary>
    /// if Called moves to moveToPosition (global var).
    /// </summary>
    private void Climb()
    {
        canMove = false;
        isCrawling = false;
        canClimb = false;
        rBody.useGravity = false;

        if (moveToPosition.y - transform.position.y < jumpSetting.jumpLimit)
        {
            //Debug.Log("Doing a jump");
            transform.DOMove(moveToPosition,0.4f).SetDelay(0.7f).OnComplete(() => EndOfClimbing(false));
        }
        else if (moveToPosition.y - transform.position.y >= jumpSetting.jumpLimit && moveToPosition.y - transform.position.y < jumpSetting.grabLimit)
        {
            //Debug.Log("Doing a grab" + (moveToPosition.y - transform.position.y) );
            transform.DOMove(moveToPosition, 0.4f).SetDelay(0.7f).OnComplete(() => EndOfClimbing(false));

        }
        else if (moveToPosition.y - transform.position.y >= jumpSetting.grabLimit && moveToPosition.y - transform.position.y < jumpSetting.jumpLedgeGrabLimit)
        {
            isLedgeGrabbing = true;
            // Setting exact position as it could not be setup before
            moveToPosition.y -= characterHeight;

            //Debug.Log("Doing a ledge grab");
            transform.DOMove(moveToPosition, 0.4f).SetDelay(0.7f).OnComplete(() => EndOfClimbing(true));
            

        }
        else
        {
            Debug.LogWarning("You should not be able to jump, report to a programmer");
        }
    }

    /// <summary>
    /// Resets all changed properties by the jump to get back into proper movement.
    /// </summary>
    /// <param name="isledgeGrab">is the player going to be ledge grabbing at the end of the climb?</param>
    private void EndOfClimbing(bool isledgeGrab)
    {
        isLedgeGrabbing = false;

        animator.ResetTrigger(CharacterAnimationParam.onJump);
        animator.ResetTrigger(CharacterAnimationParam.onClimb);
        if (isledgeGrab)
        {
            isLedgeGrabbing = true;
            //Debug.Log("Setting up Ledge grab");
            rBody.useGravity = false;

            //Making sure the player is facing the wall he jumped on.
            Ray frontRay = new Ray(transform.position + new Vector3(0, 1f, 0), transform.forward);
            RaycastHit frontObject;

            if (Physics.Raycast(frontRay, out frontObject, 1f, jumpSetting.jumpMask.value))
            {
                this.transform.rotation = Quaternion.LookRotation(-frontObject.normal);
            }
        }
        else
        {
            
            rBody.useGravity = true;
        }
        canMove = true;
    }

    #endregion Methods

    #region InputLogic
    public void OnAction(InputActionList action, InputState state)
    {
        if (action == InputActionList.Interact && state == InputState.Pressed)
        {
            if (!isCrawling && canClimb && IsGrounded() && canMove)
            {
                animator.SetTrigger(CharacterAnimationParam.onJump);
                Climb();
            }
            else if (listNPC.Count != 0 && IsGrounded())
            {
                NPCSimpleBehavior NPC = GetNearestNPC().GetComponent<NPCSimpleBehavior>();
                if (!NPC.isSpeaking)
                {
                    NPC.LookAtPlayer(this.transform.position);
                    NPC.LaunchDialog();
                }

            }
            else if( isLedgeGrabbing && canClimb && !IsGrounded() && canMove)
            {
                animator.SetTrigger(CharacterAnimationParam.onClimb);
                isLedgeGrabbing = false;
                Climb();
            }
        }

        if (action == InputActionList.Crawl && state == InputState.Pressed )
        {
            if (!IsGrounded() && isLedgeGrabbing && canDrop)
            {
                animator.SetTrigger(CharacterAnimationParam.onFall);
                EndOfClimbing(false);
                rBody.useGravity = true;
            }
        }

        if (action == InputActionList.Crawl && state == InputState.Hold)
        {
            if (IsGrounded())
            {
                isCrawling = true;

            }
        }

        if ((action == InputActionList.Crawl && state == InputState.Released) || (action == InputActionList.Crawl && state == InputState.NONE))
        {
            CheckForCrawl();
            if (!isForcedCrawling)
            {
                isCrawling = false;
            }
            
        }
    }
    #endregion

    #region NPC Logic
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
        for (int i = 0; i < listNPC.Count; i++)
        {
            if (i != 0 && Vector3.Distance(listNPC[i].transform.position, this.transform.position) < Vector3.Distance(nearest.transform.position, this.transform.position))
            {
                nearest = listNPC[i];
            }
        }
        return nearest;
    }

    public void OnExplorationEnter()
    {
        canMove = true;
    }

    public void OnExplorationEnd()
    {
        canMove = false;
    }
    #endregion
}
