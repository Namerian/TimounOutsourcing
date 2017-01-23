using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Linq;
using UnityEngine.UI;
using Events;
using Combat;
using System;
using DG.Tweening;
public class WheelManager : MonoBehaviour, CombatEvents.IAfterInitCombatHandler
{

    public List<GameObject> slotList = new List<GameObject>();
    int _nbOfPlayers;
    public GameObject objectToSpawn;

    //public List<WheelSlot> slotList = new List<WheelSlot>();
    private static WheelManager wheelManager;

    public static WheelManager Instance()
    {
        if (!wheelManager)
        {
            wheelManager = FindObjectOfType(typeof(WheelManager)) as WheelManager;
            if (!wheelManager)
            {
                Debug.LogError("There needs to be one active WheelManager script on a GameObject in your scene");
            }
        }
        return wheelManager;
    }

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void SpawnSlot(int nbOfSlots)
    {
        for(int i = 0; i < nbOfSlots; i++)
        {
            GameObject newSlot = Instantiate(slotList[i], objectToSpawn.transform, false) as GameObject;
            newSlot.GetComponent<WheelSlot>().ID = i;
            newSlot.GetComponent<WheelSlot>().player = CombatManager.instance.listOfPlayers[i];
            newSlot.GetComponentInChildren<UIPlayerStamina>().entity = newSlot.GetComponent<WheelSlot>().player;
            newSlot.GetComponentInChildren<UIPlayerLife>().entity = newSlot.GetComponent<WheelSlot>().player;
            newSlot.name = "Slot" + i;
        }
    }

    
    public void ActivateImage(Image image)
    {
        image.DOFade(1, 0);
        image.gameObject.SetActive(true);
    }

    public void MaskImage(Image image)
    {
        image.gameObject.SetActive(false);
    }

    public void OnAfterInitCombat()
    {
        _nbOfPlayers = CombatManager.instance.listOfPlayers.Count;
        switch (_nbOfPlayers)
        {
            case 1:
                SpawnSlot(1);
                break;
            case 2:
                SpawnSlot(2);
                break;
            case 3:
                SpawnSlot(3);
                break;
            case 4:
                SpawnSlot(4);
                break;
            default:
                break;
        }
    }
}
