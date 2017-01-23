using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Linq;
using UnityEngine.UI;
using Events;
using Combat;
using System;
using DG.Tweening;
using GameInput;
public class WheelSlot : MonoBehaviour,
    CombatEvents.IEntitySubstractLife,
    CombatEvents.IEntityIsOutOfLife,
    CombatEvents.IEntityIsLowOnLife,
    CombatEvents.IEntityIsNormalOnLife,
    CombatEvents.IEntityIsFullOnLife,
    CombatEvents.IEntityIsOutOfStamina,
    CombatEvents.IEntityIsFullOfStamina,
    CombatEvents.IExecuteAction,
    CombatEvents.ITurnTransitionHandler,
    InputEvents.IActionHandler,
    CombatEvents.IStartAttackHandler
    {

    public int ID;

    public GameObject staminaState;
    public GameObject normalState;
    public GameObject outState;

    public Image staminaNormal;
    public Image staminaAttack;
    public Image staminaLowLife;

    public Image normalNormal;
    public Image normalAttack;
    public Image normalLowLife;

    public Image outNormal;
    public Image outHit;
    public Image outLowLife;
    public Image outDead;

    public Player.Player player;

    public UIPlayerStamina stamina;
    public UIPlayerLife life;

    public Text typeText;
    public Text actionText;
    public List<Image> skillList = new List<Image>();
    public Image defendSkillImage;
    public Image attackSkillImage;
    public Image specialSkillImage;

    // Use this for initialization
    void Start () {
        Init();
        EventCenter.AddSubscriber(this);
    }

	public void Init()
    {
        GameObject[] tempState = gameObject.transform.GetChild(0).gameObject.Children().ToArray();
        staminaState = tempState[0];
        normalState = tempState[1];
        outState = tempState[2];

        Image[] staminaChildren = staminaState.Children().OfComponent<Image>().ToArray();
        staminaNormal = staminaChildren[0];
        staminaAttack = staminaChildren[1];
        staminaLowLife = staminaChildren[2];

        Image[] normalChildren = normalState.Children().OfComponent<Image>().ToArray(); ;
        normalNormal = normalChildren[0];
        normalAttack = normalChildren[1];
        normalLowLife = normalChildren[2];

        Image[] outChildren = outState.Children().OfComponent<Image>().ToArray();
        outNormal = outChildren[0];
        outHit = outChildren[1];
        outLowLife = outChildren[2];
        outDead = outChildren[3];

        DisableChildren(staminaState);
        DisableChildren(normalState);
        DisableChildren(outState);
        WheelManager.Instance().ActivateImage(normalNormal);
        WheelManager.Instance().ActivateImage(staminaNormal);

        //DIRTY
        Image[] tempSkillImage = transform.GetChild(3).GetComponentsInChildren<Image>();
        foreach(GameObject image in transform.GetChild(3).gameObject.Children() )
        {
            skillList.Add(image.GetComponent<Image>());
        }
        specialSkillImage = skillList[0];
        attackSkillImage = skillList[1];
        defendSkillImage = skillList[2];

        actionText = transform.GetChild(4).GetComponentInChildren<Text>();
        typeText = transform.GetChild(transform.childCount-1).GetComponent<Text>();
    }

    public void DisableChildren(GameObject parent)
    {
        GameObject[] tempObjects = parent.Descendants().ToArray();
        foreach (GameObject gameobject in tempObjects)
        {
            gameobject.SetActive(false);
        }
    }

    public void OnEntitySubstractLife(Entity parEntity, float damage)
    {
        if(parEntity == player)
        {
            WheelManager.Instance().ActivateImage(outHit);
            outHit.DOFade(0, 0).SetDelay(0.5f);
        }
    }

    public void OnEntityIsOutOfLife(Entity parEntity)
    {
        if(parEntity == player)
        {
            WheelManager.Instance().ActivateImage(outDead);
        }
    }

    public void OnEntityIsLowOnLife(Entity parEntity)
    {
        if (parEntity == player)
        {
            if(parEntity.staminaScript.staminaState == Stamina.StaminaState.OutOfStamina)
            {
                WheelManager.Instance().ActivateImage(outLowLife);
            }
            else
            {
                WheelManager.Instance().ActivateImage(normalLowLife);
            }
            WheelManager.Instance().ActivateImage(staminaLowLife);
        }
    }

    public void OnEntityIsNormalOnLife(Entity parEntity)
    {
        if (parEntity == player)
        {
            WheelManager.Instance().ActivateImage(normalNormal);
            WheelManager.Instance().ActivateImage(staminaNormal);
        }
    }

    public void OnEntityIsFullOnLife(Entity parEntity)
    {
        if (parEntity == player)
        {
            WheelManager.Instance().ActivateImage(normalNormal);
            WheelManager.Instance().ActivateImage(staminaNormal);
        }
    }

    public void OnEntityIsOutOfStamina(Entity parEntity)
    {
        if (parEntity == player)
        {
            WheelManager.Instance().ActivateImage(outNormal);
        }
    }

    public void OnEntityIsFullOfStamina(Entity parEntity)
    {
        if (parEntity == player)
        {
            //Debug.Log(parEntity.entityName);
            WheelManager.Instance().MaskImage(outNormal);
            WheelManager.Instance().MaskImage(outHit);
            WheelManager.Instance().MaskImage(outLowLife);
            WheelManager.Instance().ActivateImage(normalNormal);
            WheelManager.Instance().ActivateImage(staminaNormal);
        }
    }

    public void OnExecuteAction(CustomActionList.Action parAction, Entity parOwner, Entity parTarget)
    {
        /*if(parOwner == player)
        {
            WheelManager.Instance().ActivateImage(normalAttack);
            WheelManager.Instance().ActivateImage(staminaAttack);
            normalAttack.DOFade(0, 0).SetDelay(parAction.animationTime).OnComplete(()=> WheelManager.Instance().MaskImage(normalAttack));
            staminaAttack.DOFade(0, 0).SetDelay(parAction.animationTime).OnComplete(() => WheelManager.Instance().MaskImage(staminaAttack));
        }*/
    }

    public void OnTurnTransition(TurnManager.TurnState prevState, TurnManager.TurnState currentState, float transitionDuration)
    {
        if (prevState == TurnManager.TurnState.PlayerTurn)
        {
            actionText.text = "Defend";
            MaskAllSkillImage();
            defendSkillImage.DOFade(1, 0);
        }

        if(prevState == TurnManager.TurnState.Enemyturn)
        {
            actionText.text = "Attack";
            MaskAllSkillImage();
            attackSkillImage.DOFade(1, 0);
        }
    }

    public void OnAction(InputActionList action, InputState state)
    {
        if(action == InputActionList.AbilityModifier && state == InputState.Hold && TurnManager.Instance().currentTurnState == TurnManager.TurnState.PlayerTurn)
        {
            typeText.text = "Special";
            MaskAllSkillImage();
            specialSkillImage.DOFade(1, 0);
        }
        else
        {
            if(typeText.text != "Normal")
            {
                typeText.text = "Normal";
                MaskAllSkillImage();
                attackSkillImage.DOFade(1, 0);
            }
        }
    }

    public void MaskAllSkillImage()
    {
        foreach(Image image in skillList)
        {
            image.DOFade(0, 0);
        }
    }

    public void OnStartAttack(EntityAction parAction, Entity parOwner, Entity parTarget)
    {
        if(parOwner == player)
        {
            if(player.entityArchetype == Entity.EntityArchetype.HARASSER )
            {
                /*if(player.GetComponent<SimpleAttackHarasser>() && parAction.GetType() == typeof(SimpleAttackHarasser))
                {
                    StartCoroutine(fillIcon(attackSkillImage.transform.GetChild(0).GetComponent<Image>(), player.GetComponent<SimpleAttackHarasser>().coolDown));
                }

                if(player.GetComponent<SpecialAttackHarasser>() && parAction.GetType() == typeof(SpecialAttackHarasser))
                {
                    StartCoroutine(fillIcon(specialSkillImage.transform.GetChild(0).GetComponent<Image>(), player.GetComponent<SpecialAttackHarasser>().coolDown));
                }*/
            }

            if(player.entityArchetype == Entity.EntityArchetype.TANK)
            {
                /*if (player.GetComponent<SimpleAttackTank>() && parAction.GetType() == typeof(SimpleAttackTank))
                {
                    StartCoroutine(fillIcon(attackSkillImage.transform.GetChild(0).GetComponent<Image>(), player.GetComponent<SimpleAttackTank>().coolDown));
                }*/

                //Special Attack Tank
                /*if (player.GetComponent<SpecialAttackTank>() && parAction.GetType() == typeof(SpecialAttackTank))
                {
                    StartCoroutine(fillIcon(specialSkillImage.transform.GetChild(0).GetComponent<Image>(), player.GetComponent<SpecialAttackTank>().coolDown));
                }*/
            }
        }
    }

    public IEnumerator fillIcon(Image icon, float cdTimer)
    {
        icon.fillAmount = 1;
        float timer = 0;
        while (timer <= cdTimer)
        {
            icon.fillAmount = 1 - (timer / cdTimer);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        timer = 0;
        icon.fillAmount = 0;
    }
}
