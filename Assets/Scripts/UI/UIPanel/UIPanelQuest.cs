using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UIPanelQuest : UIPanel {
    public List<GameObject> questSlot = new List<GameObject>();
    public GameObject activeObject;
    public GameObject slot;
    public GameObject questContainer;
    int currentIndex;
 
	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        questContainer = transform.GetChild(0).gameObject;
        slot = (GameObject)Resources.Load("Quests/QuestSlot");
        if(transform.GetChild(0).childCount > 0)
        {
            GameObject[] tempSlots = transform.GetChild(0).GetComponentsInChildren<GameObject>();
            foreach (GameObject gameObject in tempSlots)
            {
                questSlot.Add(gameObject);
            }
        }
        currentIndex = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentIndex++;
            currentIndex = Mathf.Min(currentIndex, questSlot.Count-1);
            ShowSlot(currentIndex);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentIndex--;
            currentIndex = Mathf.Max(0, currentIndex);
            ShowSlot(currentIndex);
        }
	}

    public void AddSlot(GameObject slot)
    {
        questSlot.Add(slot);
        MaskAll();
        ShowSlot(currentIndex);
    }

    public void DeleteSlot(GameObject slot)
    {
        questSlot.Remove(slot);
        Destroy(slot);
    }

    public void ShowSlot(int parCurrentIndex)
    {
        if(parCurrentIndex < questSlot.Count)
        {
            currentIndex = parCurrentIndex;
            MaskAll();
            questSlot[parCurrentIndex].SetActive(true);
            questSlot[parCurrentIndex].transform.SetAsLastSibling();
        }
    }

    void MaskAll()
    {
        foreach(GameObject gameObject in questSlot)
        {
            gameObject.SetActive(false);
        }
    }
}
