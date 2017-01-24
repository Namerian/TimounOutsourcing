using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class PlayerCombatUI : MonoBehaviour {

    Image aimImage;
    CanvasGroup canvasGroup;
    public bool isActive;
    // Use this for initialization
    void Start () {
        canvasGroup = this.GetComponent<CanvasGroup>();
        aimImage = this.transform.GetChild(0).GetComponent<Image>();
        Mask();
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive || ContextManager.instance.currentContext == GameInput.InputContextList.Combat)
        {
            transform.LookAt(Camera.main.transform);
        }
	}

    public void Show()
    {
        aimImage.DOFade(1, 0.1f);
        isActive = true;
    }

    public void Mask()
    {
        aimImage.DOFade(0, 0.1f);
        isActive = false;
    }
}
