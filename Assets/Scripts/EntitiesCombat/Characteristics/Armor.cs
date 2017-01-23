using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;

public class Armor : MonoBehaviour,
    CombatEvents.IStartTurnHandler,
    CombatEvents.INewTurnHandler,
    CombatEvents.IInitCombatHandler
{

    public enum ArmorState
    {
        FullArmor,
        HighArmor,
        MediumArmor,
        LowArmor,
        BrokenArmor,
        NoArmor
    }

    public float currentArmor;
    public Entity armorEntity;

    [Header("ArmorSettings")]
    public float maxArmor;
    public ArmorState armorState;
    public float damageAbsorption = 5f;
    public float blowDamage = 5f;

    [Header("Armor Threshold in percentage")]
    [Range(0, 100)]
    public float lowArmorThreshold = 25f;
    [Range(0, 100)]
    public float mediumArmorThreshold = 50f;
    [Range(0, 100)]
    public float highArmorThreshold = 75f;

    

    [Header("Armor Regeneration")]
    public float armorRegenerationRate = 1;
    public float armorRegenerationDelay = 0.4f;
    public float brokenArmorRegenDelay = 10f;

    protected float _currentBrokenArmorRegenDelay;

    protected bool canRegen;

    protected float _lowArmor;
    protected float _mediumArmor;
    protected float _highArmor;
    protected bool _isOutOfArmor;
    // Use this for initialization

    protected virtual void Start () {
        currentArmor = maxArmor;
        //armorState = ArmorState.FullArmor;

        _lowArmor = maxArmor * lowArmorThreshold / 100;
        _mediumArmor = maxArmor * mediumArmorThreshold / 100;
        _highArmor = maxArmor * highArmorThreshold / 100;
    }

    void Update()
    {
        //Old school Timer (Dirty?) cause I need to be able to stop it in real time 
        if (_isOutOfArmor && canRegen && (armorState != ArmorState.NoArmor))
        {
            _currentBrokenArmorRegenDelay += Time.deltaTime;

            //Debug.Log("BraceForRegen");

            if (_currentBrokenArmorRegenDelay >= brokenArmorRegenDelay)
            {
                //Debug.Log("Regen should start again");
                _currentBrokenArmorRegenDelay = 0;
                canRegen = true;
                _isOutOfArmor = false;
                StartCoroutine(RegenArmor());
            }
        }
    }

    public void AddArmor(float amount)
    {
        if (armorState == ArmorState.NoArmor)
            return;

        //Debug.Log("AddingArmor");
        currentArmor += amount;
        currentArmor = Mathf.Min(currentArmor, maxArmor);

        EventCenter.FireEvent<CombatEvents.IEntityAddArmor>((handler) => handler.OnEntityAddArmor(armorEntity, amount));

        if(currentArmor != 0)
        {
            _isOutOfArmor = false;
        }

        //Max
        if (currentArmor >= maxArmor)
        {
            armorState = ArmorState.FullArmor;
            EventCenter.FireEvent<CombatEvents.IEntityFullArmor>((handler) => handler.OnEntityFullArmor(armorEntity));
        }

        //High
        if (currentArmor >= _mediumArmor && currentArmor < _highArmor)
        {
            armorState = ArmorState.HighArmor;
            EventCenter.FireEvent<CombatEvents.IEntityHighArmor>((handler) => handler.OnEntityHighArmor(armorEntity));
        }


        //Medium
        if (currentArmor >= _lowArmor && currentArmor < _mediumArmor )
        {
            armorState = ArmorState.MediumArmor;
            EventCenter.FireEvent<CombatEvents.IEntityMediumArmor>((handler) => handler.OnEntityMediumArmor(armorEntity));
        }

        //Low
        if (currentArmor >= 0 && currentArmor < _lowArmor)
        {
            armorState = ArmorState.LowArmor;
            EventCenter.FireEvent<CombatEvents.IEntityLowArmor>((handler) => handler.OnEntityLowArmor(armorEntity));
        }
    }

    public void SubstractArmor(float amount)
    {
        if (armorState == ArmorState.NoArmor)
            return;

        currentArmor -= amount;
        currentArmor = Mathf.Max(0, currentArmor);

        EventCenter.FireEvent<CombatEvents.IEntitySubstractArmor>((handler) => handler.OnEntitySubstractArmor(armorEntity, amount));


        //High
        if (currentArmor >= _mediumArmor && currentArmor < _highArmor)
        {
            armorState = ArmorState.HighArmor;
            EventCenter.FireEvent<CombatEvents.IEntityHighArmor>((handler) => handler.OnEntityHighArmor(armorEntity));
        }


        //Medium
        if (currentArmor >= _lowArmor && currentArmor < _mediumArmor)
        {
            armorState = ArmorState.MediumArmor;
            EventCenter.FireEvent<CombatEvents.IEntityMediumArmor>((handler) => handler.OnEntityMediumArmor(armorEntity));
        }

        //Low
        if (currentArmor > 0 && currentArmor < _lowArmor)
        {
            armorState = ArmorState.LowArmor;
            EventCenter.FireEvent<CombatEvents.IEntityLowArmor>((handler) => handler.OnEntityLowArmor(armorEntity));
        }

        //BrokenArmor
        if (currentArmor <= 0)
        {
            armorState = ArmorState.BrokenArmor;

            StopAllCoroutines();

            if(!_isOutOfArmor)
                EventCenter.FireEvent<CombatEvents.IEntityBrokenArmor>((handler) => handler.OnEntityBrokenArmor(armorEntity));

            _isOutOfArmor = true;
            _currentBrokenArmorRegenDelay = 0;
            //Debug.Log("BrokenArmor");

            
        }
    }

    public IEnumerator RegenArmor()
    {
        //Debug.Log("Regen");
        while (canRegen)
        {
            AddArmor(armorRegenerationRate);
            yield return new WaitForSeconds(armorRegenerationDelay);
        }
    }

    public void OnStartTurn(TurnManager.TurnState currentState)
    {
        if (currentState == TurnManager.TurnState.PlayerTurn)
        {
            if (armorState == ArmorState.NoArmor)
                return;

            StopAllCoroutines();
            canRegen = true;

            if (!_isOutOfArmor)
            {
                //Debug.Log("Regen Restarts");
                StartCoroutine(RegenArmor());
            }
            
        }
    }

    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        if (state == TurnManager.TurnState.PlayerTurn)
        {
            if (armorState == ArmorState.NoArmor)
                return;

            canRegen = false;
            StopAllCoroutines();
        }
    }

    public void OnInitCombat()
    {
        if(maxArmor > 0)
        {
            currentArmor = maxArmor;
            armorState = ArmorState.FullArmor;

            canRegen = true;
            StartCoroutine(RegenArmor());
        }
        else
        {
            currentArmor = 0;
            armorState = ArmorState.NoArmor;

            canRegen = false;
        }
    }
}
