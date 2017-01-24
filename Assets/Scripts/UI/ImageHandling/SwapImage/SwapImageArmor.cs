using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Events;
using Combat;
using System;

public class SwapImageArmor : SwapImage, 
    CombatEvents.IEntityFullArmor, 
    CombatEvents.IEntityBrokenArmor, 
    CombatEvents.IEntityLowArmor, 
    CombatEvents.IEntityHighArmor,
    CombatEvents.IEntityAddArmor,
    CombatEvents.IEntitySubstractArmor,
    CombatEvents.IAfterInitCombatHandler{



    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

	// Use this for initialization
	protected override void Start () {
        base.Start();
        imageList.Reverse();
        MaskAll();

	}

    public void OnEntityFullArmor(Entity parEntity)
    {
        
        /*if(parEntity == GetComponentInParent<Player.Player>())
        {
            MaskAll();
            ShowImage(imgArmorFull);
        }

        if(parEntity == GetComponentInParent<Monster.Monster>())
        {
            MaskAll();
            ShowImage(imgArmorFull);
        }*/
    }

    public void OnEntityBrokenArmor(Entity parEntity)
    {
        /*if (parEntity == GetComponentInParent<Player.Player>())
        {
            MaskAll();
            ShowImage(imgArmorBreak);
        }

        if (parEntity == GetComponentInParent<Monster.Monster>())
        {
            MaskAll();
            ShowImage(imgArmorBreak);
        }*/
    }

    public void OnEntityLowArmor(Entity parEntity)
    {
        /*if (parEntity == GetComponentInParent<Player.Player>())
        {
            MaskAll();
            ShowImage(imgArmorLow);
        }
        if (parEntity == GetComponentInParent<Monster.Monster>())
        {
            MaskAll();
            ShowImage(imgArmorLow);
        }*/
    }

    public void OnEntityHighArmor(Entity parEntity)
    {
        /*if (parEntity == GetComponentInParent<Player.Player>())
        {
            MaskAll();
            ShowImage(imgArmorHigh);
        }
        if (parEntity == GetComponentInParent<Monster.Monster>())
        {
            MaskAll();
            ShowImage(imgArmorHigh);
        }*/
    }

    public void OnAfterInitCombat()
    {
        MaskAll();
        foreach (Player.Player player in CombatManager.instance.listOfPlayers)
        {
            if (player == GetComponentInParent<Player.Player>())
            {
                if(player.armorScript.armorState != Armor.ArmorState.NoArmor)
                {
                    ShowImage(imageList[imageList.Count - 1]);
                }
                    
            }
        }

        foreach (Monster.Monster monster in CombatManager.instance.listOfMonsters)
        {
            if (monster == GetComponentInParent<Monster.Monster>())
            {
                if (monster.armorScript.armorState != Armor.ArmorState.NoArmor)
                {
                    ShowImage(imageList[imageList.Count-1]);
                }
            }
        }
    }

    public void OnEntityAddArmor(Entity parEntity, float amount)
    {

        if (parEntity == GetComponentInParent<Player.Player>())
        {
            float newArmorAmount = Mathf.Min(parEntity.GetComponent<Armor>().currentArmor + amount, parEntity.GetComponent<Armor>().maxArmor);
            float range = parEntity.GetComponent<Armor>().maxArmor / imageList.Count;
            for (int i = 0; i < imageList.Count; i++)
            {
                if (newArmorAmount <= range * i)
                {
                    MaskAll();
                    imageList[i].gameObject.SetActive(true);
                    ShowImage(imageList[i]);
                    break;
                }
            }
        }

        if (parEntity == GetComponentInParent<Monster.Monster>())
        {
            float newArmorAmount = Mathf.Min(parEntity.GetComponent<Armor>().currentArmor + amount, parEntity.GetComponent<Armor>().maxArmor);
            float range = parEntity.GetComponent<Armor>().maxArmor / imageList.Count;
            for (int i = 0; i < imageList.Count; i++)
            {
                if (newArmorAmount <= range * i)
                {
                    MaskAll();
                    imageList[i].gameObject.SetActive(true);
                    ShowImage(imageList[i]);
                    break;
                }
            }
        }
    }

    public void OnEntitySubstractArmor(Entity parEntity, float amount)
    {
        if (parEntity == GetComponentInParent<Player.Player>())
        {
            float newArmorAmount = Mathf.Min(parEntity.GetComponent<Armor>().currentArmor, parEntity.GetComponent<Armor>().maxArmor);
            float range = parEntity.GetComponent<Armor>().maxArmor / imageList.Count;

            for (int i = 0; i < imageList.Count; i++)
            {
                if (newArmorAmount <= range * i)
                {
                    MaskAll();
                    imageList[i].gameObject.SetActive(true);
                    ShowImage(imageList[i]);
                    break;
                }
            }
        }

        if (parEntity == GetComponentInParent<Monster.Monster>())
        {
            float newArmorAmount = Mathf.Min(parEntity.GetComponent<Armor>().currentArmor , parEntity.GetComponent<Armor>().maxArmor);
            float range = parEntity.GetComponent<Armor>().maxArmor / imageList.Count;

            for (int i = 0; i  < imageList.Count; i++)
            {
                if (newArmorAmount <= range * i)
                {
                    MaskAll();
                    imageList[i].gameObject.SetActive(true);
                    ShowImage(imageList[i]);
                    break;
                }
            }
        }
    }
}
