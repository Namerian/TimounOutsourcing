using UnityEngine;
using System.Collections;
using Combat;
using System;

namespace Player.Animation
{
    #region Helpers

    //This class is to reference all Animation parameters, so we don't mess up the strings.
    public class PlayerAnimationParam
    {
        //Float have no prefix/suffix
        //public const string Speed = "Speed";

        // Integers have ID Suffix
        //public const string GameStateID = "GameStateID";

        //Triggers have prefix On
        //public const string OnSwitchGameState = "OnSwitchGameState";

        //Bools have prefix Is
        public const string IsGuarding = "IsGuarding";
        public const string IsLowStamina = "IsLowStamina";
    }
    #endregion

    [RequireComponent(typeof(Player))]
    public class PlayerAnimator : EntityAnimator,
        CombatEvents.IStartGuardHandler,
        CombatEvents.IEndGuardHandler,
        CombatEvents.IEntityIsLowOnStamina,
        CombatEvents.IEntityIsNormalOnStamina
    {

        private Player player;

        public override void Initialize()
        {
            player = GetComponent<Player>();
        }

        public override void AnimationUpdate()
        {
            
        }

        public void OnStartGuard(Entity parOwner)
        {
            if (parOwner.gameObject == this.gameObject)
            {
                SetParameterB(PlayerAnimationParam.IsGuarding,true);
            }
        }

        public void OnEndGuard(Entity parOwner)
        {
            if (parOwner.gameObject == this.gameObject)
            {
                SetParameterB(PlayerAnimationParam.IsGuarding, false);
            }
        }

        public void OnEntityIsLowOnStamina(Entity entity)
        {
            if (entity.gameObject == this.gameObject)
            {
                SetParameterB(PlayerAnimationParam.IsLowStamina, true);
            }
        }

        public void OnIEntityIsNormalOnStamina(Entity entity)
        {
            if (entity.gameObject == this.gameObject)
            {
                SetParameterB(PlayerAnimationParam.IsLowStamina, false);
            }
        }


    }
}

