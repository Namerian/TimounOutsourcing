using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;

public class SpawnUI : MonoBehaviour,
    CombatEvents.IAfterInitCombatHandler,
    CombatEvents.ICombatEndHandler
{
    public GameObject UILife;
    public GameObject UIStamina;
    public GameObject canvasToSpawn;
    public float offsetTop;
    public float offsetLeft;
    UILife _UILife;
    UIStamina _UIStamina;
    Entity _entity;
    int _id;

    GameObject newUILife;
    GameObject newUIStamina;

    void Awake()
    {
        EventCenter.AddSubscriber(this);
    }

	// Use this for initialization
	void Start () {
        

        //SpawnNewUI();
    }

    void SpawnNewUI()
    {
        canvasToSpawn = UIManager.instance.panelCombat.gameObject;
        _id = _entity.ID;
        _UILife = UILife.GetComponentInChildren<UILife>();
        _UIStamina = UIStamina.GetComponentInChildren<UIStamina>();

        _UILife.entity = _entity;
        _UIStamina.entity = _entity;

        newUILife = Instantiate(UILife);
        newUILife.transform.SetParent(canvasToSpawn.transform, false);
        newUILife.name = "UILife" + this.GetComponent<Entity>().name;
        newUIStamina = Instantiate(UIStamina);
        newUIStamina.transform.SetParent(canvasToSpawn.transform, false);
        newUIStamina.name = "UIStamina" + this.GetComponent<Entity>().name;
        

        RectTransform tCanvas = canvasToSpawn.GetComponent<RectTransform>();
        float canvasWidth = tCanvas.rect.width;
        float canvasHeight = tCanvas.rect.height;

        RectTransform tLife = newUILife.GetComponent<RectTransform>();
        RectTransform tStamina = newUIStamina.GetComponent<RectTransform>();

        if (_entity.GetComponent<Player.Player>())
        {
            Vector2 UILifePosition = new Vector2(tLife.rect.width * _id + offsetLeft, 0);
            tLife.anchoredPosition = UILifePosition;

            Vector2 UIStaminaPosition = new Vector2(tStamina.rect.width * _id + offsetLeft, 0);
            tStamina.anchoredPosition = UIStaminaPosition;

        }
        else if(_entity.GetComponent<Monster.Monster>())
        {
            Vector2 UILifePosition = new Vector2(canvasWidth - tLife.rect.width - (tLife.rect.width* _id) - offsetLeft , 0);
            tLife.anchoredPosition = UILifePosition;

            Vector2 UIStaminaPosition = new Vector2(canvasWidth - tLife.rect.width - (tLife.rect.width * _id) - offsetLeft, 0);
            tStamina.anchoredPosition = UIStaminaPosition;
        }
        SetAnchors(tLife, canvasToSpawn.GetComponent<RectTransform>());
        SetAnchors(tStamina, canvasToSpawn.GetComponent<RectTransform>());
    }

    void SetAnchors(RectTransform t, RectTransform pt)
    {
        Vector2 newAnchorsMin = new Vector2(t.anchorMin.x + t.offsetMin.x / pt.rect.width,
                                                t.anchorMin.y + t.offsetMin.y / pt.rect.height);
        Vector2 newAnchorsMax = new Vector2(t.anchorMax.x + t.offsetMax.x / pt.rect.width,
                                            t.anchorMax.y + t.offsetMax.y / pt.rect.height);
        t.anchorMin = newAnchorsMin;
        t.anchorMax = newAnchorsMax;
        t.offsetMin = t.offsetMax = new Vector2(0, 0);
    }

    void DeleteUI()
    {
        Destroy(newUILife);
        Destroy(newUIStamina);
    }

    public void OnInitCombat()
    {
        
        
    }

    public void OnCombatEnd()
    {
        DeleteUI();
    }

    public void OnAfterInitCombat()
    {
        _entity = this.GetComponent<Entity>();
        if (_entity.GetComponent<Monster.Monster>())
        {
            if (_entity.GetComponent<Monster.Monster>().IsInCombatZone())
            {
                SpawnNewUI();
            }
        }
        else
        {
            SpawnNewUI();
        }
    }
}
