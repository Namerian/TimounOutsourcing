using UnityEngine;
using System.Collections;
using Events;
using Combat;
using System;
using UnityEngine.UI;

public class UITimer : UIFillImage, CombatEvents.INewTurnHandler {

    Text timerText;
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
        timerText = this.transform.GetChild(1).GetComponent<Text>();
    }

    public void OnNewTurn(TurnManager.TurnState state, float turnDuration)
    {
        StartCoroutine(Newturn(state, turnDuration));
        if(state == TurnManager.TurnState.PlayerTurn)
        {
            this._textImage.text = "Player turn";
            UIManager.instance.ShakeScaleUI(_textImage.gameObject.transform, 1, 0.5f, 10, 90);
        }
        else if(state == TurnManager.TurnState.Enemyturn)
        {
            this._textImage.text = "Enemy turn";
            UIManager.instance.ShakeScaleUI(_textImage.gameObject.transform, 1, 0.5f, 10, 90);
        }
    }
    
    IEnumerator Newturn(TurnManager.TurnState state, float turnDuration)
    {
        yield return new WaitForEndOfFrame();
        float _timer = turnDuration;
        while (_timer <= turnDuration)
        {
            this._imageFill.fillAmount = _timer / turnDuration;
            _timer -= Time.deltaTime;
            
            if(_timer <= 0)
            {
                yield break;
            }
            timerText.text = Mathf.Round(_timer).ToString();
            yield return new WaitForEndOfFrame();
        }
    }
}
