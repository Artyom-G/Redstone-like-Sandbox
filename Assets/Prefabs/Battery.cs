using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Battery : MonoBehaviour
{
    Data d;
    public Sprite Body1;
    public Sprite Body0;
    public SpriteRenderer Indicator;
    public AudioClip ClickSound;
    public GameObject SoundObject;
    void Start(){
        d = gameObject.GetComponent<Data>();
        //d.outputCharge[0]=true;
        ChangeColor();
        d.body.sprite = CommonFunctions.BoolToSprite(d.outputCharge[0], Body1, Body0);
    }
    void OnMouseDown(){
        if(OnUIHover.hovering) return;
        d.outputCharge[0]=!d.outputCharge[0];
        ChangeColor();
        d.body.sprite = CommonFunctions.BoolToSprite(d.outputCharge[0], Body1, Body0);
        CursorSystem.MakeSound(SoundObject, ClickSound, 0.5f);
    }
    void ChangeColor(){
        Indicator.color = CommonFunctions.BoolToColor(d.outputCharge[0]);
        d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
    }
    void SubscribeToColorChanger(){
        CursorSystem.OnColorChange.AddListener(ChangeColor);
    }
    void OnEnable(){
        Invoke("SubscribeToColorChanger",0.5f);
    }
    void OnDisable(){
        CursorSystem.OnColorChange.RemoveListener(ChangeColor);
    }
}
