using UnityEngine;
using System.Collections;

public class UIPanel : MonoBehaviour {
    public int index;
	// Use this for initialization
	protected virtual void Start () {
        index = this.transform.GetSiblingIndex();
        UIManager.instance.panelList.Add(this);
    }
}
