using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIButtonMenu : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{

    Text buttonText;
    Image buttonHoverImage;
    
    void Start()
    {
        buttonText = GetComponentInChildren<Text>();
        buttonHoverImage = transform.GetChild(0).GetComponent<Image>();
        buttonHoverImage.DOFade(0, 0);
    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonHoverImage.DOFade(1, 0.2f);
        buttonText.DOColor(Color.yellow, 0.3f);
    }

    public void OnDeselect(BaseEventData data)
    {
        buttonHoverImage.DOFade(0, 0.2f);
        buttonText.DOColor(Color.white, 0.3f);
    }

    void OnDisable()
    {
        buttonHoverImage.DOFade(0, 0.2f);
        buttonText.DOColor(Color.white, 0.3f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonHoverImage.DOFade(1, 0.2f);
        buttonText.DOColor(Color.yellow, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonHoverImage.DOFade(0, 0.2f);
        buttonText.DOColor(Color.white, 0.3f);
    }
}

