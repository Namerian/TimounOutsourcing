using UnityEngine;
using System.Collections;
using Combat;
using System;
using Events;

namespace Monster.Effects
{
    [RequireComponent(typeof(Monster))]
    public class MonsterVFX : VFX,
    CombatEvents.IEntitySubstractLife,
    CombatEvents.IImpactAttackHandler,
    CombatEvents.IEntityBrokenArmor,
    CombatEvents.IEntityFullArmor,
    CombatEvents.IEntityHighArmor,
    CombatEvents.IEntityMediumArmor,
    CombatEvents.IEntityLowArmor,
    CombatEvents.IAfterInitCombatHandler
    {
        //[SerializeField]
        private GameObject onDamageTakenEffect;
        [SerializeField]
        private Vector3 onDamageTakenEffectOffset;

        //[SerializeField]
        private GameObject onAttackEffect;
        [SerializeField]
        private Vector3 onAttackEffectOffset;

        //[SerializeField]
        private GameObject onArmorBreakEffect;
        [SerializeField]
        private Vector3 onArmorBreakEffectOffset = new Vector3(0,1.5f,0);

        [SerializeField]
        private GameObject armor;

        void Awake()
        {
            EventCenter.AddSubscriber(this);

            if (armor == null)
                Debug.LogWarning("No Armor Material attributed");
        }

        void Start()
        {
            onDamageTakenEffect = VFXManager.instance.GetVFX("VFX_Hit_Basic_3");

            onAttackEffect = VFXManager.instance.GetVFX("VFX_OniHit");

            onArmorBreakEffect = VFXManager.instance.GetVFX("VFX_ArmorBreak");
        }

        public void Cleanup()
        {
            EventCenter.RemoveSubscriber(this);
        }

        public void OnEntitySubstractLife(Entity entity, float damage)
        {
            if (entity.gameObject == this.gameObject)
            {
                InstantiateVFX(onDamageTakenEffect, this.gameObject, onDamageTakenEffectOffset, 1);
                armor.GetComponent<Renderer>().material.SetFloat("_Fracture", GetComponent<ArmorMonster>().currentArmor / GetComponent<ArmorMonster>().maxArmor);
            }
        }

        public void OnImpactAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
        {
            if (parOwner != null && parOwner.gameObject == this.gameObject)
            {
                /*if(parAction == this.GetComponent<SimpleAttackMonster>())
                {
                    InstantiateVFX(onAttackEffect, parTarget.gameObject, onAttackEffectOffset, 3);
                }*/
            }
        }

        public void OnEntityBrokenArmor(Entity entity)
        {
            if (entity != null && entity.gameObject == this.gameObject)
            {
                InstantiateVFX(onArmorBreakEffect, entity.gameObject, onArmorBreakEffectOffset, 3);
                armor.SetActive(false);
            }
        }

        public void OnEntityFullArmor(Entity entity)
        {
            if (entity != null && entity.gameObject == this.gameObject)
            {
                armor.SetActive(true);
                //armor.GetComponent<Renderer>().material.SetFloat("_Fracture", 0);
            }
        }
        public void OnEntityHighArmor(Entity entity)
        {
            if (entity != null && entity.gameObject == this.gameObject)
            {
                armor.SetActive(true);
                //armor.GetComponent<Renderer>().material.SetFloat("_Fracture", 0.25);
            }
        }
        public void OnEntityMediumArmor(Entity entity)
        {
            if (entity != null && entity.gameObject == this.gameObject)
            {
                armor.SetActive(true);
                //armor.GetComponent<Renderer>().material.SetFloat("_Fracture", 0.2f);
            }
        }

        public void OnEntityLowArmor(Entity entity)
        {
            if (entity != null && entity.gameObject == this.gameObject)
            {
                armor.SetActive(true);
            }
        }

        public void OnAfterInitCombat()
        {
            armor.SetActive(true);
            armor.GetComponent<Renderer>().material.SetFloat("_Fracture", 1);
        }
    }
}