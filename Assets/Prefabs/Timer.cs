using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    Data d;
    public Sprite[] Body0 = new Sprite[5];
    public Sprite[] Body1 = new Sprite[5];
    public float[] TimerFloat = new float[5];
    bool oldInput = false;
    public int Type = 0;
    public LayerMask mask;
    public AudioClip ClickSound;
    public GameObject SoundObject;
    public SpriteRenderer Indicator1;
    public SpriteRenderer Indicator2;
    public SpriteRenderer ClockArm;
    void Start(){
        d = GetComponent<Data>();
        StartCoroutine("Main");
    }
    public IEnumerator Main(){
        RaycastHit2D inputRay = Physics2D.Raycast(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right, 0.2f, mask, transform.position.z);
        if (inputRay.collider != null){
            d.inputObjCon[0] = inputRay.transform.gameObject.GetComponent<SpriteRenderer>();
            d.inputObj[0] = d.inputObjCon[0].transform.parent.parent.gameObject;
            d.inputCharge[0] = d.inputObj[0].GetComponent<Data>().outputCharge[CommonFunctions.FindIndexOfCon(d.inputObjCon[0])];
        }
        else{
            d.inputObjCon[0] = null;
            d.inputObj[0] = null;
            d.inputCharge[0] = false;

        }
        if(oldInput != d.inputCharge[0]){
            yield return new WaitForSeconds(TimerFloat[Type]-CommonFunctions.updateTimer);
            d.outputCharge[0] = d.inputCharge[0];
            oldInput = d.inputCharge[0];
        }else{
            oldInput = d.inputCharge[0];
            yield return new WaitForSeconds(CommonFunctions.updateTimer);
        }
        ChangeColor();
        StartCoroutine("Main");
    }
    void OnMouseDown(){
        if(OnUIHover.hovering) return;
        Type++;
        if(Type>=TimerFloat.Length) Type = 0;
        ClockArm.transform.Rotate(new Vector3(0,0, (360/-TimerFloat.Length)));
        CursorSystem.MakeSound(SoundObject, ClickSound, 0.5f);
    }
    void OnDrawGizmosSelected(){
        d = GetComponent<Data>();
        Gizmos.color = new Color(1, 0, 0, 0.75f);
        Gizmos.DrawRay(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right*0.2f);
    }
    void ChangeColor(){
        Indicator1.color = CommonFunctions.BoolToColor(d.outputCharge[0], 2);
        Indicator2.color = CommonFunctions.BoolToColor(d.outputCharge[0], 3);
        ClockArm.color = CommonFunctions.BoolToColor(d.outputCharge[0], 3);
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
