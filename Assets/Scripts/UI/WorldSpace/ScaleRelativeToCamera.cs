using UnityEngine;
using System.Collections;

public class ScaleRelativeToCamera : MonoBehaviour
{
    public Camera cam;
    public float objectScale = -1.0f;
    private Vector3 initialScale;
    NPCInteractUI npcInteractUI;
    // set the initial scale, and setup reference camera
    void Start()
    {
        // record initial scale, use this as a basis
        initialScale = transform.localScale;
        npcInteractUI = this.GetComponent<NPCInteractUI>();
        // if no specific camera, grab the default camera
        if (cam == null)
            cam = Camera.main;
    }

    // scale object relative to distance from camera plane
    void Update()
    {
        if (npcInteractUI.isActive)
        {
            float dist = Vector3.Distance(this.transform.position, cam.transform.position);
            transform.localScale = initialScale * dist * objectScale / 10;
        }
    }
}
