using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Data : MonoBehaviour
{
    [Header("Input")]
    public bool[] inputCharge = new bool[1];
    public SpriteRenderer[] inputCon = new SpriteRenderer[1];
    //[System.NonSerialized]
    public GameObject[] inputObj = new GameObject[1];
    //[System.NonSerialized]
    public SpriteRenderer[] inputObjCon = new SpriteRenderer[1];
    [Header("Output")]
    public bool[] outputCharge = new bool[1];
    public SpriteRenderer[] outputCon = new SpriteRenderer[1];
    //[System.NonSerialized]
    public GameObject[] outputObj = new GameObject[1];
    //[System.NonSerialized]
    public SpriteRenderer[] outputObjCon = new SpriteRenderer[1];
    [Header("Other")]
    public SpriteRenderer body;
    public static event EventHandler OnMapUpdate;
    public AudioClip RemoveBuildingSound;
    public GameObject SoundObject;
    public bool unchangable = false;
    void OnMouseOver () {
        if(OnUIHover.hovering || unchangable) return;
        if(Input.GetMouseButtonDown(1)){
            if(OnMapUpdate != null) OnMapUpdate?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
            CursorSystem.MakeSound(SoundObject, RemoveBuildingSound, 0.5f);
        }
        if(Input.GetKeyDown("r")){
            if(OnMapUpdate != null) OnMapUpdate?.Invoke(this, EventArgs.Empty);
            gameObject.transform.GetChild(0).Rotate(0, 0, -90);
            CursorSystem.MakeSound(SoundObject, RemoveBuildingSound, 0.5f);
        }
        if(Input.GetKeyDown("f")){
            if(OnMapUpdate != null) OnMapUpdate?.Invoke(this, EventArgs.Empty);
            gameObject.transform.GetChild(0).localScale = new Vector3(-gameObject.transform.GetChild(0).localScale.x, gameObject.transform.GetChild(0).localScale.y, gameObject.transform.GetChild(0).localScale.z);
            CursorSystem.MakeSound(SoundObject, RemoveBuildingSound, 0.5f);
        }
    }
}
