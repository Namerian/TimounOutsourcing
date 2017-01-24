using UnityEngine;
using System.Collections;

public class DestroySFXByTime : MonoBehaviour {
    public float delayToDestroy;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, delayToDestroy);
    }

    void OnDestroy()
    {
        if(this.GetComponent<AudioSource>() != null)
        {
            SFXManager.instance.RemoveAudioFromList(this.GetComponent<AudioSource>());
        }
    }
}
