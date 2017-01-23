using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Events;
using Combat;
public class UIText : MonoBehaviour {

    protected Text _text;

    protected virtual void Awake()
    {
        _text = this.GetComponent<Text>();
    }
}
