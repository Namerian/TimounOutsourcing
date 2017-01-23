using UnityEngine;
using System.Collections;
using Combat;
using System;
using Events;

namespace Player.Effects
{
    [RequireComponent(typeof(Player))]
    public class PlayerVFX : VFX,
    CombatEvents.IEntitySubstractLife,
    CombatEvents.IImpactAttackHandler
    {
        public GameObject OnDamageTakenEffect;

        //[SerializeField]
        private GameObject onAttackEffect;
        [SerializeField]
        private Vector3 onAttackEffectOffset = new Vector3(0f, 12f, 0f);

        void Awake()
        {
            EventCenter.AddSubscriber(this);
        }

        void Start()
        {
            OnDamageTakenEffect = VFXManager.instance.GetVFX("VFX_HitEffect");

            onAttackEffect = VFXManager.instance.GetVFX("VFX_Slash");
        }
        public void Cleanup()
        {
            EventCenter.RemoveSubscriber(this);
        }

        public void OnEntitySubstractLife(Entity entity, float damage)
        {
            if (entity.gameObject == this.gameObject)
            {
                InstantiateVFX(OnDamageTakenEffect, this.gameObject,default(Vector3),1);
            }
        }

        public void OnImpactAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
        {
            if (parOwner != null && parOwner.gameObject == this.gameObject)
            {
                /*if (parAction == this.GetComponent<SpecialAttackHarasser>())
                {
                    onAttackEffectOffset = new Vector3(-1f, 2f, 1.3f);
                    InstantiateVFX(onAttackEffect, parTarget.gameObject, onAttackEffectOffset, 0.5f);
                }*/
            }
        }
    }
}
