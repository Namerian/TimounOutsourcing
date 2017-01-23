using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ContextControlUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ContextManager.instance.panelContextList.Add(this);
	}
	
	public void Show()
    {
        this.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void Mask()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
    }
}
