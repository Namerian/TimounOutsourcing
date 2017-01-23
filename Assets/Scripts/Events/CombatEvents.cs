using UnityEngine.EventSystems;
using UnityEngine;
using Combat;
using System.Collections.Generic;
namespace Combat
{
    public class CombatEvents
    {
        public interface ICombatEnterHandler : IEventSystemHandler
        {
            void OnCombatEnter();
        }

        public interface ICombatEndHandler : IEventSystemHandler
        {
            void OnCombatEnd();
        }

        internal interface IInitCombatHandler : IEventSystemHandler
        {
            void OnInitCombat();
        }

        internal interface IAfterInitCombatHandler : IEventSystemHandler
        {
            void OnAfterInitCombat();
        }

        #region Attack
        internal interface IEventCameraHandler : IEventSystemHandler
        {
            void OnEventCamera(MoveCombatCamera.CameraCurve cameraCurve, Transform target, bool start = false);
        }

        internal interface ICastAction : IEventSystemHandler
        {
            void OnCastAction(EntityAction parAction, Entity parOwner, Entity parTarget);
        }

        internal interface IExecuteAction : IEventSystemHandler
        {
            void OnExecuteAction(CustomActionList.Action parAction, Entity parOwner, Entity parTarget);
        }

        internal interface IStartAttackHandler : IEventSystemHandler
        {
            void OnStartAttack(EntityAction parAction, Entity parOwner, Entity parTarget);
        }

        internal interface IImpactAttackHandler : IEventSystemHandler
        {
            void OnImpactAttack(EntityAction parAction, Entity parOwner, Entity parTarget);
        }
        internal interface IEndCoolDownAttackHandler : IEventSystemHandler
        {
            void OnEndCoolDownAttack(EntityAction parAction);
        }

        internal interface IStartGuardHandler : IEventSystemHandler
        {
            void OnStartGuard(Entity parOwner);
        }

        internal interface IKeepGuardHandler : IEventSystemHandler
        {
            void OnKeepGuard(Entity parOwner);
        }

        internal interface IEndGuardHandler : IEventSystemHandler
        {
            void OnEndGuard(Entity parOwner);
        }

        internal interface IShowSpecialBarHarasserHandler : IEventSystemHandler
        {
            void OnShowSpecialBarHarasser();
        }

        internal interface IUpdateSpecialBarHarasserHandler : IEventSystemHandler
        {
            void OnUpdateSpecialBarHarasser(float parCurrentAmount, float parMaxAmount);
        }

        internal interface IHideSpecialBarHarasserHandler : IEventSystemHandler
        {
            void OnHideSpecialBarHarasser();
        }
        #endregion

        #region Abilities
        internal interface IPreparationEvade : IEventSystemHandler
        {
            void OnPrepareEvade( Entity parOwner, float prepareDuration);
        }

        internal interface IStartEvade : IEventSystemHandler
        {
            void OnStartEvade(Entity parOwner);
        }

        internal interface IEndEvade : IEventSystemHandler
        {
            void OnEndEvade(Entity parOwner);
        }
        #endregion

        #region Turn

        public interface ITurnTransitionHandler : IEventSystemHandler
        {
            void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration);
        }

        public interface IStartTurnHandler : IEventSystemHandler
        {
            void OnStartTurn(TurnManager.TurnState currentState);

        }

        public interface INewTurnHandler: IEventSystemHandler
        {
            void OnNewTurn(TurnManager.TurnState state, float turnDuration);
            
        }

        public interface IFeedbackTurnPlayer: IEventSystemHandler
        {
            void FeedbackTurnPlayer(float animationDuration);
        }

        public interface IEndTurnHandler : IEventSystemHandler
        {
            void OnEndTurn(TurnManager.TurnState currentState);
        }

        #endregion

        #region Entity Life 

        public interface IEntityAddLife : IEventSystemHandler
        {
            void OnEntityAddLife(Entity entity, float damage);
        }

        public interface IEntitySubstractLife : IEventSystemHandler
        {
            void OnEntitySubstractLife(Entity entity, float damage);
        }

        public interface IEntityIsOutOfLife : IEventSystemHandler
        {
            void OnEntityIsOutOfLife(Entity entity);
        }

        public interface IEntityIsLowOnLife : IEventSystemHandler
        {
            void OnEntityIsLowOnLife(Entity entity);
        }

        public interface IEntityIsNormalOnLife : IEventSystemHandler
        {
            void OnEntityIsNormalOnLife(Entity entity);
        }

        public interface IEntityIsFullOnLife : IEventSystemHandler
        {
            void OnEntityIsFullOnLife(Entity entity);
        }

        #endregion

        #region Entity Stamina
        public interface IEntityAddStamina : IEventSystemHandler
        {
            void OnEntityAddStamina(Entity entity, float amount);
        }

        public interface IEntitySubstractStamina : IEventSystemHandler
        {
            void OnEntitySubstractStamina(Entity entity, float amount);
        }

        public interface IEntityIsOutOfStamina : IEventSystemHandler
        {
            void OnEntityIsOutOfStamina(Entity entity);
        }

        public interface IEntityIsLowOnStamina : IEventSystemHandler
        {
            void OnEntityIsLowOnStamina(Entity entity);
        }

        public interface IEntityIsNormalOnStamina : IEventSystemHandler
        {
            void OnIEntityIsNormalOnStamina(Entity entity);
        }

        public interface IEntityIsFullOfStamina : IEventSystemHandler
        {
            void OnEntityIsFullOfStamina(Entity entity);
        }


        #endregion

        #region Entity Armor
        public interface IEntityAddArmor : IEventSystemHandler
        {
            void OnEntityAddArmor(Entity entity, float amount);
        }

        public interface IEntitySubstractArmor : IEventSystemHandler
        {
            void OnEntitySubstractArmor(Entity entity, float amount);
        }

        public interface IEntityBrokenArmor : IEventSystemHandler
        {
            void OnEntityBrokenArmor(Entity entity);
        }

        public interface IEntityLowArmor : IEventSystemHandler
        {
            void OnEntityLowArmor(Entity entity);
        }

        public interface IEntityMediumArmor : IEventSystemHandler
        {
            void OnEntityMediumArmor(Entity entity);
        }

        public interface IEntityHighArmor : IEventSystemHandler
        {
            void OnEntityHighArmor(Entity entity);
        }

        public interface IEntityFullArmor : IEventSystemHandler
        {
            void OnEntityFullArmor(Entity entity);
        }
        #endregion

        #region UI_CoolDown
        internal interface IStartUICoolDownHandler : IEventSystemHandler
        {
            void OnStartUICoolDown(EntityAction parAction);
        }

        internal interface IEndUICoolDownHandler : IEventSystemHandler
        {
            void OnEndUICoolDown(EntityAction parAction);
        }
        #endregion

        #region Timing

        internal interface IResetTimingHandler : IEventSystemHandler
        {
            void OnResetTiming(EntityAction parAction, Entity parTarget);
        }
        internal interface IPauseTimingHandler : IEventSystemHandler
        {
            void OnPauseRhythm();
        }

        internal interface IResumeTimingHandler : IEventSystemHandler
        {
            void OnResumeRhythm();
        }
        /*
        internal interface ICheckTimerRhythmHandler : IEventSystemHandler
        {
            void OnCheckTimerRhythm(EntityAction action, Entity parOwner = null, Entity parTarget = null);
        }
		
		internal interface IResetTimerRythmHandler : IEventSystemHandler
        {
            void OnResetTimerRythm(EntityAction action);
        }*/

        internal interface IInputPressedHandler : IEventSystemHandler
        {
            void OnInputPressed(KeyCode keyCode);
        }

        internal interface IInputUnPressedHandler : IEventSystemHandler
        {
            void OnInputUnPressed(KeyCode keyCode);
        }

        /*internal interface IUpdateComboHandler : IEventSystemHandler
        {
            void OnUpdateCombo(int currentCombo, RhythmManager.RhythmState currentState);
        }

        internal interface IEndTimingBarHandler : IEventSystemHandler
        {
            void OnEndTimingBar();
        }
        */
        internal interface IComboBrokenHandler : IEventSystemHandler
        {
            void OnComboBroken();
        }

        /*
        internal interface IUpdateRhythmHandler : IEventSystemHandler
        {
            void OnUpdateRhythm(EntityAction parAction, Entity parTarget);
        }

        internal interface ICurrentRhythmHandler : IEventSystemHandler
        {
            void OnCurrentRhythm(RhythmManager.RhythmState parCurrentRythm, EntityAction parAction, Entity parOwner, Entity parTarget = null);
        }*/


        #endregion

        #region Info

        public interface ISendEntityInfo : IEventSystemHandler
        {
            void OnSendEntityInfo(Entity entity);
        }

        internal interface IShowCurrentTimingHandler : IEventSystemHandler
        {
            void OnShowCurrentTiming(RhythmManager.RhythmState rythmState);
        }

        internal interface IUpdateCurrentTimingHandler : IEventSystemHandler
        {
            void OnUpdateCurrentTiming(RhythmManager.RhythmState rythmState, EntityAction parAction);
        }

        internal interface IEndCoolDownEntityHandler : IEventSystemHandler
        {
            void OnEndCoolDownEntity(Entity parEntity);
        }
        #endregion

        public interface IStartJumpHandler : IEventSystemHandler
        {
            void OnStartJump(Entity parOwner, Entity parTarget = null, EntityAction parAction = null);
        }

        public interface IEndJumpHandler : IEventSystemHandler
        {
            void OnEndJump(Entity parOwner);
        }

        public interface iPlayerLost : IEventSystemHandler
        {
            void OnPlayerLost();
        }
        
    }
}

