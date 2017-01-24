using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class SwapImage : MonoBehaviour {
    public List<Image> imageList = new List<Image>();
	// Use this for initialization
	protected virtual void Start () {
	    foreach(Transform child in transform)
        {
            if (child.GetComponent<Image>())
            {
                imageList.Add(child.GetComponent<Image>());
            }
        }
	}

    protected void MaskAll()
    {
        foreach(Image parImage in imageList)
        {
            parImage.gameObject.SetActive(false);
            //parImage.DOFade(0, 0f);
            
        }
    }

    protected void ShowImage(Image parImage)
    {
        
        parImage.gameObject.SetActive(true);

        //parImage.DOFade(1, 0f);
        
    }
}
