using UnityEngine;
using System.Collections;

public class UIPanelModal : UIPanel {

	void Start()
    {
        UIManager.instance.modalWindow = this;
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}