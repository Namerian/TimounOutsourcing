using UnityEngine;
using System.Collections;
using Events;
using Combat;
using UnityEngine.UI;

public class UICoolDownAction : UIFillImage {

    public Entity entity;
    public int index;
    protected override void Awake()
    {
        base.Awake();
        EventCenter.AddSubscriber(this);
        _imageFill = transform.GetChild(0).GetComponent<Image>();
    }
    
}
