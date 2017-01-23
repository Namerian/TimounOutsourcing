using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomActionList : ScriptableObject
{

    [System.Serializable]
    public class Action
    {
        [Header("Base settings :")]
        public string name;
        public Entity owner;
        public bool ranged;
        public bool isCasting;
        public float damage;
        public float damageMultiplier;
        public float stamina;
        public float armorPiercingBonus;
        public bool GuardBreaker;
        [Header("Timing settings :")]
        public float maxTime;
        [Range(0, 100)]
        public float goodPercent;
        [Tooltip("The good timing start point in % ")]
        [Range(0, 100)]
        public float goodPercentStart;
        [Tooltip("The perfect timing in % ")]
        [Range(0, 100)]
        public float perfectPercent;
        [Tooltip("The perfect timing start point in % ")]
        [Range(0, 100)]
        public float perfectPercentStart;
    }

    //This is our list we want to use to represent our class as an array.
    public List<Action> listOfActions = new List<Action>(1);

    void AddNew()
    {
        //Add a new index position to the end of our list
        listOfActions.Add(new Action());
    }

    void Remove(int index)
    {
        //Remove an index position from our list at a point in our list array
        listOfActions.RemoveAt(index);
    }
}
