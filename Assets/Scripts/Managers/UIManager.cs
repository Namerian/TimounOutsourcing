using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
public class UIManager : MonoBehaviour {
    public static UIManager instance;

    public Dictionary<UIPanel, int> panelDictionary = new Dictionary<UIPanel, int>();
    public List<UIPanel> panelList = new List<UIPanel>();
    public UIPanelCombat panelCombat;
    public UIPanelContextInput panelContextInput;
    public UIPanelDialog panelDialog;
    public UIPanelStory panelStory;
    public UIPanelQuest panelQuest;
    //Not with other panels
    public UIPanelModal modalWindow;
    public UIPanelRestart restartWhitePanel;
    void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Invoke("AssignPanel", 0.1f);
    }

    void AssignPanel()
    {
        foreach(UIPanel parPanel in panelList)
        {
            switch (parPanel.GetType().ToString())
            {
                case "UIPanelCombat":
                    panelCombat = (UIPanelCombat)parPanel;
                    break;
                case "UIPanelContextInput":
                    panelContextInput = (UIPanelContextInput)parPanel;
                    break;
                case "UIPanelDialog":
                    panelDialog = (UIPanelDialog)parPanel;
                    break;
                case "UIPanelStory":
                    panelStory = (UIPanelStory)parPanel;
                    break;
                case "UIPanelQuest":
                    panelQuest = (UIPanelQuest)parPanel;
                    break;
            }
        }
    }

    #region Utils
    public void Fade(GameObject objectToFade, float alpha, float duration)
    {
       if(objectToFade.GetComponent<Image>()!= null)
       {
            objectToFade.GetComponent<Image>().DOFade(alpha, duration).OnComplete(()=> CheckAlpha(objectToFade, alpha));
       }
       else if (objectToFade.GetComponent<CanvasGroup>() != null)
       {
            objectToFade.GetComponent<CanvasGroup>().DOFade(alpha, duration).OnComplete(()=>CheckAlpha(objectToFade, alpha));
       }
       else if(objectToFade.GetComponent<Text>() != null)
        {
            objectToFade.GetComponent<Text>().DOFade(alpha, duration).OnComplete(() => CheckAlpha(objectToFade, alpha));
        }
    }

    public void ShakeScaleUI(Transform objectToShake, float strength, float duration, int vibration, float randomness)
    {
        Vector3 initialPosition = objectToShake.transform.position;
        objectToShake.DOKill(true);
        objectToShake.transform.DOShakeScale(duration, strength, vibration, randomness)
            .OnComplete(() => objectToShake.DOKill(true))
            .OnComplete(() => objectToShake.transform.position = initialPosition);
    }

    public void ChangeColor(GameObject objectToColor, Color nextColor, float duration)
    {
        if(objectToColor.GetComponent<Image>() != null)
        {
            objectToColor.GetComponent<Image>().DOColor(nextColor, duration);
        }
        else if(objectToColor.GetComponent<Text>() != null)
        {
            objectToColor.GetComponent<Text>().DOColor(nextColor, duration);
        }
    }

    public void PopText(Text text, float duration)
    {
        //text.gameObject.transform.DOMoveY(-1, duration);
        text.rectTransform.DOAnchorPos(new Vector2(80, 100), duration);
        text.DOFade(0, duration);
        Destroy(text.gameObject, duration);
    }


    void CheckAlpha(GameObject gameObjectToCheck, float alpha)
    {
        if (alpha == 0)
        {
            gameObjectToCheck.SetActive(false);
        }
        else
        {
            gameObjectToCheck.SetActive(true);
        }
    }

    public void PopUpScale(Transform gameObjectToScale, float durationIn, float durationOut, float duration)
    {
        gameObjectToScale.DOScale(0, 0);
        gameObjectToScale.DOScale(1, durationIn);
        if(gameObjectToScale.GetComponent<Image>() != null)
        {
            gameObjectToScale.GetComponent<Image>().DOFade(0, durationOut).SetDelay(duration);
        }
        else if(gameObjectToScale.GetComponent<Text>() != null)
        {
            gameObjectToScale.GetComponent<Text>().DOFade(0, durationOut).SetDelay(duration);
        }
    }


    #endregion
}
