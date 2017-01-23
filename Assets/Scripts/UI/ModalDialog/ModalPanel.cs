using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;
public class EventButtonDetails
{
    public string buttonTitle;
    public Sprite buttonBackGround;
    public UnityAction action;
}


public class ModalPanelDetails
{
    public string title; //Not implemented yet
    public string question;
    public Sprite iconImage;
    public Sprite panelBackgroundImage; // Not implemented yet

    public EventButtonDetails button1Details;
    public EventButtonDetails button2Details;
    public EventButtonDetails button3Details;

}

public class ModalPanel : MonoBehaviour {

    public Text question;
    public Image iconImage;
    public Button button1;
    public Button button2;
    public Button button3;

    public Text button1Text;
    public Text button2Text;
    public Text button3Text;

    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
            {
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene");
            }
        }
        return modalPanel;
    }

   void Start()
    {
        //Dirty stuff
        Invoke("Init", 0.1f);
        
    }

    void Init()
    {
        iconImage = UIManager.instance.modalWindow.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        question = UIManager.instance.modalWindow.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        button1 = UIManager.instance.modalWindow.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        button2 = UIManager.instance.modalWindow.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        button3 = UIManager.instance.modalWindow.transform.GetChild(1).GetChild(2).GetComponent<Button>();

        button1Text = button1.GetComponentInChildren<Text>();
        button2Text = button2.GetComponentInChildren<Text>();
        button3Text = button3.GetComponentInChildren<Text>();
        modalPanelObject = UIManager.instance.modalWindow.transform.parent.gameObject;
    }

    public void newChoice(ModalPanelDetails details)
    {
        modalPanelObject.SetActive(true);

        this.iconImage.gameObject.SetActive(false);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);

        this.transform.DOScale(0, 0);
        this.transform.DOScale(1, 1f);
       

        this.question.text = details.question;

        if (details.iconImage)
        {
            this.iconImage.sprite = details.iconImage;
            this.iconImage.gameObject.SetActive(true);
        }

        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(details.button1Details.action);
        button1.onClick.AddListener(ClosePanel);
        button1Text.text = details.button1Details.buttonTitle;
        button1.gameObject.SetActive(true);

        if(details.button1Details.buttonBackGround != null)
        {
            button1.GetComponent<Image>().sprite = details.button1Details.buttonBackGround;
        }

        if(details.button2Details != null)
        {
            button2.onClick.RemoveAllListeners();
            button2.onClick.AddListener(details.button2Details.action);
            button2.onClick.AddListener(ClosePanel);
            button2Text.text = details.button2Details.buttonTitle;
            button2.gameObject.SetActive(true);
            if (details.button2Details.buttonBackGround != null)
            {
                button2.GetComponent<Image>().sprite = details.button2Details.buttonBackGround;
            }
        }

        if(details.button3Details != null)
        {
            button3.onClick.RemoveAllListeners();
            button3.onClick.AddListener(details.button3Details.action);
            button3.onClick.AddListener(ClosePanel);
            button3Text.text = details.button3Details.buttonTitle;
            button3.gameObject.SetActive(true);
            if (details.button3Details.buttonBackGround != null)
            {
                button3.GetComponent<Image>().sprite = details.button3Details.buttonBackGround;
            }
        }
        //button1.Select();
    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
