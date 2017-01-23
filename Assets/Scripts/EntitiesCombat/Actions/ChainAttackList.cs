using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Events;

namespace Combat
{
    public class ChainAttackList : MonoBehaviour,
    CombatEvents.IAfterInitCombatHandler
    {
        public static ChainAttackList instance;

        public List<ISequenceList> sequencesList;

        [Serializable]
        public struct ISequenceList
        {
            public String sequenceName;
            //public float damage;
            public List<EntityAction> attacks; // Might be Dirty to use Entity action instead of chain action but no way to get that list for now 
        }
        [HideInInspector]
        public ISequenceList playerSequenceList;
        

        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }else if(instance != this)
            {
                Destroy(gameObject);
            }

            sequencesList.Clear();

            EventCenter.AddSubscriber(this);
        }

        void OnInspectorGUI()
        {
            //serializedObject.Update();
            //EditorGUILayout.PropertyField(playerSequenceList.attaks);
            //serializedObject.ApplyModifiedProperties();
        }

        public void OnAfterInitCombat()
        {
            sequencesList.Clear();


            if (CombatManager.instance.listOfPlayers[1].listOfActions.Count < 5)
            {
                Debug.LogError("ChainAttacks are not configured");
                return;
            }
            else
            {
                // Ultra DIRTY DIRTY DIRTY, Tout ce système devrait être editable dans l'inspecteur, et sauvegardable d'une manière ou d'une autre.
                playerSequenceList.sequenceName = "Tornado";
                playerSequenceList.attacks.Add(CombatManager.instance.listOfPlayers[0].listOfActions[3]);
                playerSequenceList.attacks.Add(CombatManager.instance.listOfPlayers[0].listOfActions[4]);
                playerSequenceList.attacks.Add(CombatManager.instance.listOfPlayers[1].listOfActions[3]);

                sequencesList.Add(playerSequenceList);

            }


        }

    }

}

