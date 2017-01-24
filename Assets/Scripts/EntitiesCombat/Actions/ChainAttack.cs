using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;
using Events;
using GameInput;

public class ChainAttack : AttackAction,
    CombatEvents.IInitCombatHandler,
    CombatEvents.IExecuteAction,
    CombatEvents.IStartAttackHandler,
    CombatEvents.IImpactAttackHandler,
    CombatEvents.IEndCoolDownAttackHandler,
    CombatEvents.ICastAction
{
    public void OnInitCombat()
    {
        this.owner = GetComponent<Entity>();
        this.isCasting = false;
        this.target = null;
        this.isReady = true;
        this.damageMultiplier = 1f;
        this.staminaCostMultiplier = 1f;
    }

    public void OnExecuteAction(CustomActionList.Action parAction, Entity parOwner, Entity parTarget)
    {
        if (this.owner == parOwner && parOwner.lifeScript.lifeState != Life.LifeState.OutOfLife && parOwner.staminaScript.staminaState != Stamina.StaminaState.OutOfStamina)
        {
            if (this.isReady)
            {
                SetChainAttack(parAction);
                if (isCasting)
                {
                    InteruptCasting(parOwner, parTarget);
                }
                else if( castTime == 0)
                {
                    //Reset combo timing values
                    EventCenter.FireEvent<CombatEvents.IStartAttackHandler>((handler) => handler.OnStartAttack(this, parOwner, parTarget));
                }else
                {
                    //Launch Casting function
                    EventCenter.FireEvent<CombatEvents.ICastAction>((handler) => handler.OnCastAction(this, parOwner, parTarget));
                }
                
            }
        }
    }

    void SetChainAttack(CustomActionList.Action parAction)
    {
        this.name = parAction.name;
        this.damage = parAction.damage;
        this.damageMultiplierBonus = parAction.damageMultiplier;
        this.staminaCost = parAction.stamina;
        this.armorPiercingBonus = parAction.armorPiercingBonus;
        this.maxTime = parAction.maxTime;
        this.goodPercent = parAction.goodPercent;
        this.goodPercentStart = parAction.goodPercentStart;
        this.perfectPercent = parAction.perfectPercent;
        this.perfectPercentStart = parAction.perfectPercentStart;
    }

    //should probably be an event
    public void OnCastAction(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        isCasting = true;

        Debug.Log("Start Casting");
        //Should launch OnStartAttack after certain time

        StartCoroutine(WaitForCast(parOwner, parTarget));
    }

    IEnumerator WaitForCast(Entity parOwner, Entity parTarget)
    {
        while (isCasting)
        {
            yield return new WaitForSeconds(castTime);
            EventCenter.FireEvent<CombatEvents.IStartAttackHandler>((handler) => handler.OnStartAttack(this, parOwner, parTarget));
            Debug.Log("Casting Done");
            StopAllCoroutines();
        }
    }

    /// <summary>
    /// Interupts Casting
    /// </summary>
    public void InteruptCasting(Entity parOwner, Entity parTarget)
    {
        StopAllCoroutines();
        isCasting = false;
        EventCenter.FireEvent<CombatEvents.IStartAttackHandler>((handler) => handler.OnStartAttack(this, parOwner, parTarget));

        Debug.Log("Casting Interupted ");
    }

    /// <summary>
    /// Starts when the attack animation is launched, triggers timers for impacts and ability cooldown
    /// </summary>
    /// <param name="parAction"></param>
    /// <param name="parOwner"></param>
    /// <param name="parTarget"></param>
    public void OnStartAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        if (parOwner.gameObject == this.gameObject && parAction == this)
        {
            EventCenter.FireEvent<CombatEvents.IResetTimingHandler>((handler) => handler.OnResetTiming(parAction, parTarget));

            isCasting = false;

            this.owner = parOwner;
            this.target = parTarget;
            this.isReady = false;
            this.entityAction = parAction;
            
            StartCoroutine(Timer(this.impactTime, startImpactEvent));
            StartCoroutine(Timer(this.coolDown, startEndCoolDownEvent));

            if (this.owner.GetComponent<Player.Player>())
            {
                //EventCenter.FireEvent<CombatEvents.ICheckTimerRhythmHandler>((handler) => handler.OnCheckTimerRhythm(this, this.owner, this.target));
                //EventCenter.FireEvent<CombatEvents.IUpdateRhythmHandler>((handler) => handler.OnUpdateRhythm(this, this.target));
                XInput.instance.useVibe(XInputDotNetPure.PlayerIndex.One, 0.1f, 1f, 1f);
            }
        }
    }

    /// <summary>
    /// Handles the impact effects of the attack
    /// </summary>
    /// <param name="parAction"></param>
    /// <param name="parOwner"></param>
    /// <param name="parTarget"></param>
    public void OnImpactAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        if (parOwner != null && parOwner.gameObject == this.gameObject && parAction == this)
        {
            parOwner.staminaScript.SubstractStamina(this.staminaCost * this.staminaCostMultiplier);

            if (parTarget.entityStance == Entity.EntityStance.EVADE)
            {
                Debug.Log("Attack evaded");
                return;
            }

            float lifeDamage = this.damage * this.damageMultiplier;

            //Checking for Armor
            if (parTarget.armorScript.armorState == Armor.ArmorState.NoArmor || parTarget.armorScript.armorState == Armor.ArmorState.BrokenArmor)
            {
                //Debug.Log("No Armor Detected");   
            }
            else
            {
                //Debug.Log("Armor Detected");
                float armorDamage = parTarget.armorScript.blowDamage + armorPiercingBonus;

                parTarget.armorScript.SubstractArmor(armorDamage);

                lifeDamage -= parTarget.armorScript.damageAbsorption;
            }

            // Dirty ?
            if (lifeDamage <= 0)
                return;

            //Check Guard
            if (parTarget.GetComponent<Player.Player>() && parTarget.entityStance == Entity.EntityStance.GUARD)
            {
                if (parTarget.GetComponent<Player.Player>().guardScript.guardDamageAbsorbtion != 0)
                {
                    lifeDamage -= (lifeDamage * parTarget.GetComponent<Player.Player>().guardScript.guardDamageAbsorbtion / 100);
                }
            }
            else if (parTarget.GetComponent<Player.Player>() && parTarget.entityStance == Entity.EntityStance.NONE)
            {
                XInput.instance.useVibe(XInputDotNetPure.PlayerIndex.One, 0.1f, 1f, 1f);
            }

            if (lifeDamage < 1)
                Debug.LogWarning("Really Low damage attack, is this usefull ?");

            parTarget.lifeScript.SubstractLife(lifeDamage);

        }
    }

    private void startImpactEvent()
    {
        EventCenter.FireEvent<CombatEvents.IImpactAttackHandler>((handler) => handler.OnImpactAttack(this, this.owner, this.target));
    }

    private void startEndCoolDownEvent()
    {
        EventCenter.FireEvent<CombatEvents.IEndCoolDownAttackHandler>((handler) => handler.OnEndCoolDownAttack(this));
    }

    private void startEndCoolDownEntityEvent()
    {
        EventCenter.FireEvent<CombatEvents.IEndCoolDownEntityHandler>((handler) => handler.OnEndCoolDownEntity(this.owner));
    }

    public void OnEndCoolDownAttack(EntityAction parAction)
    {
        if (this.owner != null && this.owner.gameObject == this.gameObject && this.entityAction == parAction)
        {
            this.isReady = true;
        }
    }
}
