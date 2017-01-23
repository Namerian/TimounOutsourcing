using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {

    NPCSimpleBehavior simpleBehavior;
    NPCInteractUI npcInteractUI;

    void Start()
    {
        simpleBehavior = this.GetComponent<NPCSimpleBehavior>();
        npcInteractUI = this.GetComponentInChildren<NPCInteractUI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            simpleBehavior.player = other.GetComponent<CharacterControllerLogic>();
            simpleBehavior.player.AddNpcToList(this.gameObject);
            simpleBehavior.isPlayerNear = true;
            npcInteractUI.Show();
            npcInteractUI.isActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            simpleBehavior.player.RemoveNpcFromList(this.gameObject);
            simpleBehavior.player = null;
            simpleBehavior.isPlayerNear = false;
            simpleBehavior.RotateTo(simpleBehavior.initialRotation);
            npcInteractUI.isActive = false;
            simpleBehavior.EndDialog();
            npcInteractUI.Mask();

        }
    }
}
