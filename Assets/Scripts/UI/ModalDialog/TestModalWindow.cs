using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
public class TestModalWindow : MonoBehaviour {

    public Sprite icon;
    public Transform spawnPoint;
    public GameObject thingToSpawn;

    private ModalPanel _modalPanel;
    private DisplayManager _displayManager;

    void Awake()
    {
        _modalPanel = ModalPanel.Instance();
        _displayManager = DisplayManager.Instance();
    }



    //Send to the Modal Panel to set up the buttons and Fucntions to call
    public void TestYNC()
    {
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "Would you like a poke in the eye ?\nHow about with a sharp stick ?"};
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Yes", action = TestYesFunction };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "No", action = TestNoFunction };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Cancel", action = TestCancelFunction };
        _modalPanel.newChoice(modalPanelDetails);
    }

    public void TestYNCI()
    {
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "Would you like a poke in the eye ?\nHow about with a sharp stick ?", iconImage = icon};
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Yes", action = TestYesFunction };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "No", action = TestNoFunction };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Cancel", action = TestCancelFunction };
        _modalPanel.newChoice(modalPanelDetails);
    }

    public void TestC()
    {
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "This is an announcement !\nIf you don't like, shove off !"};
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Gotcha", action = TestCancelFunction };
        _modalPanel.newChoice(modalPanelDetails);
    }

    public void TestCI()
    {
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "This is an announcement !\nIf you don't like, shove off !", iconImage = icon};
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Gotcha", action = TestCancelFunction};
        _modalPanel.newChoice(modalPanelDetails);
    }

    public void TestLambda()
    {
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "Do you want to create 2 spheres ?" };
        modalPanelDetails.button1Details = new EventButtonDetails {
            buttonTitle = "Yes, Please !",
            action = () => { InstantiateObject(thingToSpawn); InstantiateObject(thingToSpawn); }
        };

        modalPanelDetails.button2Details = new EventButtonDetails
        {
            buttonTitle = "No thanks",
            action = TestNoFunction
        };

        _modalPanel.newChoice(modalPanelDetails);
       
    }


    //These are wrapped into UnityAction
    void TestYesFunction()
    {
        _displayManager.DisplayMessage("Heck Yeah !");
    }

    void TestNoFunction()
    {
        _displayManager.DisplayMessage("No Way");
    }

    void TestCancelFunction()
    {
        _displayManager.DisplayMessage("I give up !");
    }

    void InstantiateObject(GameObject thingToInstantiate)
    {
        _displayManager.DisplayMessage("Here we go");
        Instantiate(thingToInstantiate, spawnPoint.position, spawnPoint.rotation);
    }
}
