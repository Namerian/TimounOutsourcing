using UnityEngine;
using System.Collections;
using System;
using Events;

[Serializable]
public class EntityAction : MonoBehaviour {

    public enum ActionRythmType
    {
        PRESSED,
        UNPRESSED,
        SPAM,
    }

    public string name;
    [Header("Base settings")]
    [HideInInspector]
    public Entity owner;
    [HideInInspector]
    public Entity target;
    [HideInInspector]
    public EntityAction entityAction;
    [HideInInspector]
    public float damageMultiplier = 1f;
    [HideInInspector]
    public bool isCasting = false;

    [HideInInspector]
    public float staminaCostMultiplier = 1f;

    [Header("Timing/Delay settings")]
    [Tooltip("delay before starting impact delay")]
    public float castTime;
    [Tooltip("delay to impact")]
    public float impactTime;
    [Tooltip("time of the whole animation")]
    public float animationTime;
    [Tooltip("cooldown between each attack of this type from this character")]
    public float coolDown;

    [HideInInspector]
    public float baseStaminaCostMultiplier = 1f;

    [Header("Stamina settings")]
    public float staminaCost;
    public float staminaCostMultiplierMalus;

    [Header("Perfect Timing settings")]
    [HideInInspector]
    public float maxTime;
    [Tooltip("The good timing duration in % ")]
    [Range(0, 100)]
    public float goodPercent;
    [Tooltip("The good timing start point in % ")]
    [Range(0, 100)]
    public float goodPercentStart;
    [Tooltip("The perfect timing in % ")]
    [Range(0,100)]
    public float perfectPercent;
    [Tooltip("The perfect timing start point in % ")]
    [Range(0, 100)]
    public float perfectPercentStart;


    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }


    public IEnumerator Timer(float parTime, Action action_event)
    {
        yield return new WaitForSeconds(parTime);
        action_event();
    }
}
