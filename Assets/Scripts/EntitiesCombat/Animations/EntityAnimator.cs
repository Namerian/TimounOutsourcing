using UnityEngine;
using System.Collections;
using Events;
using Combat;

public abstract class EntityAnimator : MonoBehaviour,
        CombatEvents.IStartAttackHandler,
        CombatEvents.IEntitySubstractLife
{

    #region Helpers

    public class GeneralAnimationParam
    {

        //Float have no prefix/suffix
        //public const string Speed = "Speed";

        // Integers have ID Suffix
        public const string GameStateID = "GameStateID";

        //Triggers have prefix On
        public const string OnSwitchGameState = "OnSwitchGameState";
        public const string onStartAttack = "OnStartAttack";
        public const string onDamageTaken = "OnDamageTaken";

        //Bools have prefix Is
    }

    public enum AnimationGameStates
    {
        Exploration = 0,
        Combat = 1,
        Dialog = 2
    }
    #endregion

    protected internal Animator animator;

    #region Base
    void Awake()
    {
        EventCenter.AddSubscriber(this);
        animator = GetComponentInChildren<Animator>() ?? GetComponent<Animator>();

        Initialize();
    }

    public abstract void Initialize();

    public void Cleanup()
    {
        EventCenter.RemoveSubscriber(this);
        animator = null;
    }

    public abstract void AnimationUpdate();

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            Debug.LogWarning("No Animator Found");
            return;
        }

        AnimationUpdate();
    }
    #endregion

    #region BaseAnimations
    public virtual void OnCombatEnter()
    {
        SetParameterI(GeneralAnimationParam.GameStateID, (int)AnimationGameStates.Combat);
        Trigger(GeneralAnimationParam.OnSwitchGameState);
    }

    public virtual void OnEntitySubstractLife(Entity entity, float damage)
    {
        if (entity.gameObject == this.gameObject)
        {
            Trigger(GeneralAnimationParam.onDamageTaken);
        }
    }

    public virtual void OnStartAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        if (parOwner.gameObject == this.gameObject)
        {
            Trigger(GeneralAnimationParam.onStartAttack);


        }
    }


    #endregion

    #region AnimationParamHandlers
    /// <summary>
    /// Sets a trigger in the animator
    /// </summary>
    public void Trigger(string triggerName)
    {
        if (animator != null && animator.isInitialized)
            animator.SetTrigger(triggerName);
    }

    public void ResetTrigger(string triggerName)
    {
        if (animator != null && animator.isInitialized)
            animator.ResetTrigger(triggerName);
    }

    /// <summary>
    /// Sets a boolean in the animator
    /// </summary>
    public void SetParameterB(string name, bool param)
    {
        if (animator != null && animator.isInitialized)
            animator.SetBool(name, param);
    }

    /// <summary>
    /// Sets an integer in the animation SM
    /// </summary>
    public void SetParameterI(string name, int param)
    {
        if (animator != null && animator.isInitialized)
            animator.SetInteger(name, param);
    }


    /// <summary>
    /// Sets a float in the animation SM
    /// </summary>
    public void SetParameterF(string name, float param)
    {
        if (animator != null && animator.isInitialized)
            animator.SetFloat(name, param);
    }
    #endregion
}
