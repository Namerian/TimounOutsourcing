using UnityEngine;
using System.Collections;

public class UIPanelRestart : UIPanel {

	// Use this for initialization
	void Start () {
        UIManager.instance.restartWhitePanel = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
