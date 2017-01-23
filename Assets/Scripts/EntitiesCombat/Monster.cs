using UnityEngine;
using System.Collections;
using System;
using Events;
using Combat;
using System.Linq;

namespace Monster
{
    public class Monster : Entity,
        CombatEvents.IInitCombatHandler
    {
        public CombatZone combatZone;
        public override void Start()
        {
            this.entityState = EntityState.ALIVE;
            this.transform.name = this.entityName;
            this.lifeScript = GetComponent<MonsterLife>();
            this.staminaScript = GetComponent<MonsterStamina>();
            this.armorScript = GetComponent<ArmorMonster>();
            EventCenter.FireEvent<CombatEvents.ISendEntityInfo>((handler) => handler.OnSendEntityInfo(this));
            combatZone = this.transform.parent.gameObject.GetComponent<CombatZone>();
        }

        void SendEvent()
        {
            if (CombatManager.instance.listOfMonsters.Any(monster => monster.GetInstanceID() == this.GetInstanceID()))
            {
                this.lifeScript.lifeState = Life.LifeState.Full;
                this.staminaScript.staminaState = Stamina.StaminaState.Full;
                //this.armorScript.armorState = Armor.ArmorState.FullArmor;
                this.lifeScript.currentLife = this.lifeScript.maxLife;
                this.staminaScript.entityStaminaCurrent = this.staminaScript.entityStaminaMax;
                //this.armorScript.currentArmor = this.armorScript.maxArmor;
                EventCenter.FireEvent<CombatEvents.ISendEntityInfo>((handler) => handler.OnSendEntityInfo(this));
            }
        }

        public void OnInitCombat()
        {
             Invoke("SendEvent", 0.1f);
        }

        public override void Death()
        {
            Destroy(this.gameObject);
        }

        public bool IsInCombatZone()
        {
            return CombatManager.instance.listOfMonsters.Any(monster => monster.GetInstanceID() == this.GetInstanceID());
        }
    }
}

