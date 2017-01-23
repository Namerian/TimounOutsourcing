using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class BasePhysics : MonoBehaviour {

    #region variables (private)

    [SerializeField]
    private LayerMask groundMask;

    [Header("Basic Behavior Rules")]
    public bool isCarriable;
    

    [Header ("Bump Parameters")]
    public bool isBumpable;
    [SerializeField]
    private float bumpPower = 10;
    [SerializeField]
    float bumpHeight = 1;
    


    //Helpers
    //[HideInInspector]
    public bool isCarried;
    //[HideInInspector]
    public bool isStuck;

    private Rigidbody rBody;
    #endregion

    #region Properties (public)

    #endregion

    // Use this for initialization
    void Start () 
	{
        rBody = GetComponent<Rigidbody>();

        if (!GetComponentInChildren<Collider>())
            Debug.Log("Missing a collider on this physiced object");

        
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision collisionObject) 
	{
	    if(collisionObject.gameObject.tag == Tags.Player )
        {
            if(isBumpable && !isStuck && !isCarried)
                Bump(collisionObject.transform.position, collisionObject.gameObject.GetComponent<CharacterControllerLogic>().Speed);
        }

        if (collisionObject.gameObject.tag == Tags.NPC)
        {
            if (isBumpable && !isStuck && !isCarried)
                Bump(collisionObject.transform.position, collisionObject.gameObject.GetComponent<NavMeshAgent>().speed);
        }

        if (collisionObject.gameObject.tag == Tags.Sticky)
        {
            if (!isStuck)
            {
                /*if (collisionObject.gameObject.GetComponent<ObjectCatcher>())
                {
                    isStuck = true;
                    collisionObject.gameObject.GetComponent<ObjectCatcher>().AddObject(this);
                } else
                    Debug.LogError("the collided object is missing the object catcher script." + collisionObject.gameObject.name);*/
            }
        }
    }
	

    public bool IsGrounded()
    {
        Debug.DrawRay(transform.position, new Vector3(0, 0.1f, 0), Color.black);
        return Physics.Raycast(transform.position + new Vector3(0, 0.02f, 0), Vector3.down, 0.1f, groundMask.value);
    }

    /// <summary>
    /// Bumps the current object from the given position
    /// </summary>
    /// <param name="from">Where the bump comes from</param>
    private void Bump( Vector3 from, float powerModifier = 1)
    {
        //Debug.Log("sadsa");
        from.y = this.transform.position.y;

        Vector3 direction = from - this.transform.position;
        direction += Vector3.up * bumpHeight;

        rBody.velocity -= direction * bumpPower * powerModifier;

    }
}
