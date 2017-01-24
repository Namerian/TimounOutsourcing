using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using Exploration;
using GameInput;
using UnityEngine.SceneManagement;
public class ObjectContextExploration : ObjectContext {

	// Use this for initialization
	void Start () {
        TransitionContextManager.Instance().listOfGameObjectExplo.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
