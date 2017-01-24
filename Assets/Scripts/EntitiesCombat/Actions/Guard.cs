using UnityEngine;

using Events;
using Combat;

public class Guard : DefenseAction,
    CombatEvents.IStartGuardHandler,
    CombatEvents.IEndGuardHandler,
    CombatEvents.IExecuteAction,
    CombatEvents.IImpactAttackHandler,
    CombatEvents.ITurnTransitionHandler,
    CombatEvents.IEntityIsOutOfStamina,
    CombatEvents.INewTurnHandler,
    CombatEvents.IInitCombatHandler,
    CombatEvents.IKeepGuardHandler
    //CombatEvents.ICurrentRhythmHandler
{
    private bool _inGuard = false;

    [SerializeField]
    private float _EndOfGuardDelay = 0.2f;

    
    private float _GuardDelayTimer;

    [SerializeField]
    [Range(0,100)]
    public float guardDamageAbsorbtion = 0;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
        this.staminaCostReduction = 1;

        owner = this.GetComponent<Entity>();
    }

    void Update()
    {
        //Old school Timer (Dirty?) cause I need to be able to stop it in real time 
        if (_inGuard)
        {

            _GuardDelayTimer += Time.deltaTime;

            //Debug.Log("BraceForRegen");
            if (_GuardDelayTimer >= _EndOfGuardDelay)
            {
                //Debug.Log("Regen should start again");
                _GuardDelayTimer = 0;
                if( owner != null)
                    EventCenter.FireEvent<CombatEvents.IEndGuardHandler>((handler) => handler.OnEndGuard(owner));
            }
        }
    }

    public void OnStartGuard(Entity parOwner)
    {
        if(owner == parOwner)
        {
            if (parOwner.staminaScript.staminaState != Stamina.StaminaState.OutOfStamina)
            {
                owner.entityStance = Entity.EntityStance.GUARD;

                if (!_inGuard)
                {
                    //EventCenter.FireEvent<CombatEvents.ICheckTimerRhythmHandler>((handler) => handler.OnCheckTimerRhythm(this));
                }


                _GuardDelayTimer = 0;
                this._inGuard = true;
            }
        }
    }
        
    public void OnCurrentRhythm(RhythmManager.RhythmState parCurrentRythm, EntityAction parAction, Entity parOwner, Entity parTarget = null)
    {
        if (parCurrentRythm == RhythmManager.RhythmState.Perfect)
        {
            this.staminaCostMultiplier = this.baseStaminaCostMultiplier;
        }
        else if (parCurrentRythm == RhythmManager.RhythmState.Bad)
        {
            this.staminaCostMultiplier = this.staminaCostMultiplierMalus;
        }
    }

    public void OnEndGuard(Entity parOwner)
    {
        if (owner == parOwner)
        {
            this._inGuard = false;
            parOwner.entityStance = Entity.EntityStance.NONE;
        }
    }

    public void OnKeepGuard(Entity parOwner)
    {
        if(owner == parOwner)
        {
            _GuardDelayTimer = 0;
        }
    }

    public void OnImpactAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        if(parTarget == this.GetComponent<Player.Player>() && parTarget.entityStance == Entity.EntityStance.GUARD)
        {
            parTarget.GetComponentInChildren<PlayerCombatUI>().Mask();

            this.owner.staminaScript.SubstractStamina(this.staminaCost * this.staminaCostMultiplier);
            this.staminaCostReduction = 1f;

            if(!this._inGuard)
            {
                parTarget.entityStance = Entity.EntityStance.NONE;
            }

        }
    }

    public void OnExecuteAction(CustomActionList.Action parAction, Entity parOwner, Entity parTarget)
    {
        /*if (parAction == this)
        {
            if (parOwner.staminaScript.staminaState != Stamina.StaminaState.OutOfStamina)
            {
                EventCenter.FireEvent<CombatEvents.IStartGuardHandler>((handler) => handler.OnStartGuard(parOwner));
            }
        }*/
    }

    public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
    {
        if (this.owner != null)
        {
            //_owner.entityStance = Entity.EntityStance.NONE;
            OnEndGuard(owner);
        }
    }

    public void OnEntityIsOutOfStamina(Entity entity)
    {
        if (this.owner != null && entity == this.owner)
        {
            OnEndGuard(this.owner);
        }
        
    }

    public void OnInitCombat()
    {
        if (owner != null)
        {
            OnEndGuard(owner);
            owner.entityStance = Entity.EntityStance.NONE;
        }
    }

    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        if (owner != null)
        {
            OnEndGuard(owner);
            owner.entityStance = Entity.EntityStance.NONE;
        }
    }
}
