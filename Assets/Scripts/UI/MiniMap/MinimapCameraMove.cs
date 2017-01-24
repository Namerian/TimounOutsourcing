using UnityEngine;
using System.Collections;

public class MinimapCameraMove : MonoBehaviour {

    public GameObject target;
    Vector3 _newPosition;
    Quaternion _newRotation;
    public float offsetY;
	
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update () {
        _newPosition = target.transform.position + Vector3.up * offsetY;
        _newRotation = Quaternion.Euler(90, Camera.main.transform.eulerAngles.y, 0);
        transform.rotation = _newRotation;
        transform.position = _newPosition;
	}
}
