using UnityEngine;
using System.Collections;
using System;
using Events;
using DG.Tweening;
using System.Collections.Generic;

namespace Combat
{
    public enum CombatPosition
    {
        NORMAL,
        MELEE,
        BACKSTAB
    }

    public class EntityPositioner : MonoBehaviour,
        CombatEvents.IStartJumpHandler,
        CombatEvents.ICombatEnterHandler,
        CombatEvents.IAfterInitCombatHandler
    {
        public Vector3 enemyMeleeOffset = new Vector3 (0,0,0);
        public Vector3 enemyBackstabOffset = new Vector3(0, 0, 0);

        public Transform entityBasePosition;

        public float backJumpPower = 5f;
        public float backJumpDuration = 1f;

        public float meleeJumpPower = 5f;
        public float meleeJumpDuration = 0.8f;

        private Entity _owner;

        public void Awake()
        {
            _owner = GetComponent(typeof(Entity)) as Entity;

            EventCenter.AddSubscriber(this);
        }

        public void Cleanup()
        {
            EventCenter.RemoveSubscriber(this);
        }

        void LaunchInit()
        {
            EventCenter.FireEvent<CombatEvents.IStartJumpHandler>((handler) => handler.OnStartJump(_owner));
        }

        public void OnCombatEnter()
        {

            //EventCenter.FireEvent<CombatEvents.IStartJumpHandler>((handler) => handler.OnStartJump(_owner));
            // Invoke("LaunchInit", 0.5f);
        }

        public void OnAfterInitCombat()
        {

            // Dirty Stuff*********************************************************************************
            if (_owner.GetComponent<Player.Player>())
            {
                entityBasePosition = CombatManager.instance.currentCombatZone.transform.FindChild("CharacterPosition" + _owner.ID);
            }

            if (_owner.GetComponent<Monster.Monster>())
            {
                if(_owner.GetComponent<Monster.Monster>().combatZone == CombatManager.instance.currentCombatZone)
                {
                    entityBasePosition = CombatManager.instance.currentCombatZone.transform.FindChild("EnemyPosition" + _owner.ID);
                }
                else
                {
                    entityBasePosition = _owner.GetComponent<Monster.Monster>().combatZone.transform.FindChild("EnemyPosition" + _owner.ID);
                }
               
            }

            if (!entityBasePosition)
            {
                Debug.Log("Can't position this entity" + _owner.ID + _owner.entityName);
            }

            EventCenter.FireEvent<CombatEvents.IStartJumpHandler>((handler) => handler.OnStartJump(_owner));
        }


        public void OnStartJump(Entity parOwner, Entity parTarget, EntityAction parAction)
        {
            if (parOwner.gameObject == this.gameObject)
            {
                if (!parTarget)
                {
                    transform.DOJump(entityBasePosition.position, backJumpPower, 1, backJumpDuration).OnComplete(() => EndJump(parOwner));

                    transform.rotation = entityBasePosition.rotation;
                }
                else if(parAction)
                {
                    if(!parTarget.GetComponent<EntityPositioner>())
                    {
                        Debug.LogError(parTarget.gameObject.name + " is missing an EntityPositioner");
                        return;
                    }

                    EntityPositioner enemyPositioner = parTarget.GetComponent<EntityPositioner>();
                    transform.DOJump(enemyPositioner.entityBasePosition.position + enemyMeleeOffset, meleeJumpPower, 1, meleeJumpDuration).OnComplete(() => EndJump(parOwner));

                    Debug.LogWarning("Melee Jump only, Can't handle backstab position yet.");
                }
                else
                {
                    Debug.LogWarning("Couldn't Jump");
                }
            }
        }

        private void EndJump(Entity parOwner)
        {
            EventCenter.FireEvent<CombatEvents.IEndJumpHandler>((handler) => handler.OnEndJump(parOwner));
        }

    }

}