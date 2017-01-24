using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class NPCManager : MonoBehaviour {
    public static NPCManager instance;

    public List<NPCSimpleBehavior> NPCList = new List<NPCSimpleBehavior>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public NPCSimpleBehavior GetNPCByID(int parID)
    {
        return NPCList.FirstOrDefault(NPC => NPC.ID == parID);
    }


}
