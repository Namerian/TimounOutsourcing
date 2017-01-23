using UnityEngine;
using System.Collections;
using System;
using Events;
using Combat;
using GameInput;
namespace Player
{
    public class Player : Entity,
        CombatEvents.IInitCombatHandler
    {
        [HideInInspector]
        public Guard guardScript;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            this.entityState = EntityState.ALIVE;
            this.transform.name = this.entityName;
            this.lifeScript = GetComponent<PlayerLife>();
            this.staminaScript = GetComponent<PlayerStamina>();
            this.armorScript = GetComponent<ArmorPlayer>();
            this.guardScript = GetComponent<Guard>();

            //Invoke("SendEvent", 0.3f); //quickfix à retirer DIRTY
        }

        public override void Death()
        {
            Debug.Log("death");
            Destroy(this.gameObject);
        }


        void SendEvent()
        {
            this.lifeScript.lifeState = Life.LifeState.Full;
            this.staminaScript.staminaState = Stamina.StaminaState.Full;
            //this.armorScript.armorState = Armor.ArmorState.FullArmor;
            this.lifeScript.currentLife = this.lifeScript.maxLife;
            this.staminaScript.entityStaminaCurrent = this.staminaScript.entityStaminaMax;
            //this.armorScript.currentArmor = this.armorScript.maxArmor;
            EventCenter.FireEvent<CombatEvents.ISendEntityInfo>((handler) => handler.OnSendEntityInfo(this));
        }


        public virtual void OnInitCombat()
        {
            Invoke("SendEvent", 0.1f);
            
        }
    }
}


