using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Combat;
using Events;
using System;
using Exploration;
public class UIRestartModal : MonoBehaviour, CombatEvents.iPlayerLost, ExplorationEvents.IEndPrototye {

    public Sprite iconLoose;
    public Sprite iconEnd;
    private ModalPanel _modalPanel;

    public Image whitePanel;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

    // Use this for initialization
    void Start () {
        _modalPanel = ModalPanel.Instance();
        
    }

    public void RestartModal()
    {
        ContextManager.instance.ChangeContext(GameInput.InputContextList.Dialogue);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "You lost, do you want to try again ?", iconImage = iconLoose };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Try again", action = TryAgain };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Main menu", action = GoBackToMainMenu };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Quit", action = Quit };
        _modalPanel.newChoice(modalPanelDetails);
    }

    public void EndPrototypeModal()
    {
        ContextManager.instance.ChangeContext(GameInput.InputContextList.Dialogue);
        ModalPanelDetails modalPanelDetails = new ModalPanelDetails { question = "Thanks for playing !"/*, iconImage = iconEnd*/ };
        modalPanelDetails.button1Details = new EventButtonDetails { buttonTitle = "Try again", action = TryAgain };
        modalPanelDetails.button2Details = new EventButtonDetails { buttonTitle = "Main menu", action = GoBackToMainMenu };
        modalPanelDetails.button3Details = new EventButtonDetails { buttonTitle = "Quit", action = Quit };
        _modalPanel.newChoice(modalPanelDetails);
    }

    public void TryAgain()
    {
        whitePanel = UIManager.instance.restartWhitePanel.GetComponent<Image>();
        whitePanel.transform.DOScale(0, 0);
        whitePanel.transform.DOScale(1, 0.7f);
        whitePanel.DOFade(1, 0.7f).OnComplete(() => SceneManager.LoadScene(1));
    }

    public void GoBackToMainMenu()
    {
        whitePanel = UIManager.instance.restartWhitePanel.GetComponent<Image>();
        whitePanel.transform.DOScale(0, 0);
        whitePanel.transform.DOScale(1, 0.7f);
        whitePanel.DOFade(1, 0.7f).OnComplete(() => SceneManager.LoadScene(0));
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit ();
#endif
    }

    public void OnPlayerLost()
    {
        RestartModal();
    }

    public void OnEndPrototype()
    {
        EndPrototypeModal();
    }


}
