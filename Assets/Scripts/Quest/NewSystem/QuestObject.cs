using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    private bool inTrigger = false;

    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();

    // Use this for initialization
    void Start () {
        //SetQuestMarker();
	}
	
	// Update is called once per frame
	void Update () {
        /*Debug.Log(inTrigger);
        if (inTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("trigger");
            QuestManager.instance.QuestRequest(this);
        }*/
	}

    /*void SetQuestMarker()
    {
        if (QuestManager.instance.CheckCompleteQuests(this))
        {
            Debug.Log("complete");
        }else if (QuestManager.instance.CheckAvailableQuests(this))
        {
            Debug.Log("available");
        }
        else if (QuestManager.instance.CheckAcceptedQuests(this))
        {
            Debug.Log("accepted");
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
