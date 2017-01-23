using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using DG.Tweening;
using Events;
using GameInput;
using System.IO;

public class TriggerImage : Trigger, InputEvents.IActionHandler {

    public Texture2D textureImage;
    Image imageToShow;
    string imageName;
    bool isShowing;
    
    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    void Start()
    {
        triggerType = TriggerType.Image;
        TriggerManager.instance.triggerList.Add(this);
        if (textureImage == null)
        {
            Debug.LogError("Texture not set for the " + this.gameObject.name + " image trigger.");
        }
        else
        {
           
            //imageToShow.DOFade(0, 0);
        }
    }

    Image ConvertTextureToImage()
    {
        GameObject newObj = new GameObject();
        newObj.name = imageName;
        Image NewImage = newObj.AddComponent<Image>();
        NewImage.sprite = Sprite.Create(textureImage, new Rect(0, 0, textureImage.width, textureImage.height), new Vector2(0.5f, 0.5f));
        NewImage.transform.SetParent(UIManager.instance.panelStory.transform, false);
        NewImage.rectTransform.sizeDelta = new Vector2(textureImage.width, textureImage.height);
        return NewImage;
    }


    void FitToScreen()
    {
        float canvasWidth = UIManager.instance.panelStory.GetComponent<RectTransform>().rect.width;
        float canvasHeight = UIManager.instance.panelStory.GetComponent<RectTransform>().rect.height;
        float imageWidth = imageToShow.rectTransform.rect.width;
        float imageHeight = imageToShow.rectTransform.rect.height;

        if (imageWidth > canvasWidth || imageHeight > canvasHeight)
        {
            imageToShow.rectTransform.sizeDelta = new Vector2(canvasWidth, canvasHeight);
        }
        else
        {
            imageToShow.rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
        }
    }

    protected override void Execute()
    {
        if (!isShowing)
        {
            imageName = textureImage.name;
            imageToShow = ConvertTextureToImage();

            FitToScreen();

            imageToShow.transform.DOScale(0, 0);
            imageToShow.transform.DOScale(1, 0.5f);
            imageToShow.DOFade(1, 0.5f).OnComplete(() => isShowing = true);
            this.GetComponent<Collider>().enabled = false;
            ContextManager.instance.ChangeContext(InputContextList.Dialogue);
        }
    }

    public void OnAction(InputActionList action, InputState state)
    {
        if (!ContextManager.instance.CompareContext(InputContextList.Dialogue))
        {
            return;
        }

        if(action == InputActionList.Interact && state == InputState.Pressed && isShowing)
        {
            Hide();
        }
    }

    void Hide()
    {
        imageToShow.transform.DOScale(0, 0.5f);
        imageToShow.DOFade(0, 0.5f).OnComplete(() => isShowing = false);
        ContextManager.instance.ChangeContext(InputContextList.Exploration);
        Destroy(this.gameObject);

    }

    protected override void OnDestroy()
    {
        EventCenter.RemoveSubscriber(this);
        TriggerManager.instance.RemoveFromList(this);
    }
}
