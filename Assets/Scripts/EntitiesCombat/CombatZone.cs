using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CombatZone : MonoBehaviour {

    public List<Monster.Monster> monsterList;
	// Use this for initialization
	void Start () {
        Monster.Monster[] tempMonsters = GetComponentsInChildren<Monster.Monster>();

        foreach(Monster.Monster monster in tempMonsters)
        {
            monsterList.Add(monster);
        }
	}

}
