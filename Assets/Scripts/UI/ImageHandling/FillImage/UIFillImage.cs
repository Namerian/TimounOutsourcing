using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class UIFillImage : MonoBehaviour {

    protected Image _imageFill;
    protected Text _textImage;

    public float shakeDuration;
    public float shakeStrength;
    public int shakeNbOfVibration;
    public float shakeRandomness;


    protected  virtual void Awake()
    {
        _imageFill = this.GetComponent<Image>();
        _textImage = this.GetComponentInChildren<Text>();
    }
}
