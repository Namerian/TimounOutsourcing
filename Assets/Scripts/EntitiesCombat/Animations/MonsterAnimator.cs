using UnityEngine;
using System.Collections;
using Combat;
using Events;
using System;

namespace Monster.Animaton
{
    #region Helpers

    //This class is to reference all Animation parameters, so we don't mess up the strings.
    public class MonsterAnimationParam
    {
        public const string attackPreparationSpeed = "AttackPerparationSpeed";
        public const string attackWaitSpeed = "AttackWaitSpeed";

        public const string isWeakIdle = "IsWeakIdle";
        public const string isHighDamage = "IsHighDamage";
    }
    #endregion

    [RequireComponent(typeof(Monster))]
    public class MonsterAnimator : EntityAnimator
    {

        [SerializeField]
        private float highDamageThreshold = 10f;

        [SerializeField]
        private float attackPreparationSpeed = 1f;
        [SerializeField]
        private float attackWaitSpeed = 0.2f;

        private Monster monster;

        public override void Initialize()
        {
            monster = GetComponent<Monster>();

            SetParameterF(MonsterAnimationParam.attackPreparationSpeed, attackPreparationSpeed);
            SetParameterF(MonsterAnimationParam.attackWaitSpeed, attackWaitSpeed);

        }

        public override void AnimationUpdate()
        {
            if (monster.GetComponent<MonsterLife>().lifeState == Life.LifeState.LowLife)
                SetParameterB(MonsterAnimationParam.isWeakIdle, true);
            else
                SetParameterB(MonsterAnimationParam.isWeakIdle, false);
        }


        public override void OnStartAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
        {
            if (parOwner.gameObject == this.gameObject)
            {
                Trigger(GeneralAnimationParam.onStartAttack);
            }
        }

        public override void OnEntitySubstractLife(Entity entity, float damage)
        {
            if (entity.gameObject == this.gameObject)
            {


                if (damage > highDamageThreshold)
                    SetParameterB(MonsterAnimationParam.isHighDamage, true);
                else
                    SetParameterB(MonsterAnimationParam.isHighDamage, false);

                Trigger(GeneralAnimationParam.onDamageTaken);
            }
        }
    }
}

