using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{
    Data d;
    public Sprite[] GateIndicators = new Sprite[5];
    public SpriteRenderer Indicator;
    public LayerMask mask;
    bool outputCharge = false;
    public int gateType = 0;
    public AudioClip ClickSound;
    public GameObject SoundObject;
    void Start(){
        d = GetComponent<Data>();
        StartCoroutine("Main");
    }
public IEnumerator Main(){
        yield return new WaitForSeconds(CommonFunctions.updateTimer);
        RaycastHit2D inputRay1 = Physics2D.Raycast(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right, 0.2f, mask, transform.position.z);
        outputCharge = false;
        if (inputRay1.collider != null){
            d.inputObjCon[0] = inputRay1.transform.gameObject.GetComponent<SpriteRenderer>();
            d.inputObj[0] = d.inputObjCon[0].transform.parent.parent.gameObject;
            d.inputCharge[0] = d.inputObj[0].GetComponent<Data>().outputCharge[CommonFunctions.FindIndexOfCon(d.inputObjCon[0])];
            d.outputCharge[0] = d.inputCharge[0];
        }
        else{
            d.inputObjCon[0] = null;
            d.inputObj[0] = null;
            d.inputCharge[0] = false;
            d.outputCharge[0] = false;
        }
        RaycastHit2D inputRay2 = Physics2D.Raycast(d.inputCon[1].gameObject.transform.position, d.inputCon[1].gameObject.transform.right, 0.2f, mask, transform.position.z);
        if (inputRay2.collider != null){
            d.inputObjCon[1] = inputRay2.transform.gameObject.GetComponent<SpriteRenderer>();
            d.inputObj[1] = d.inputObjCon[1].transform.parent.parent.gameObject;
            d.inputCharge[1] = d.inputObj[1].GetComponent<Data>().outputCharge[CommonFunctions.FindIndexOfCon(d.inputObjCon[1])];
            d.outputCharge[1] = d.inputCharge[1];
        }
        else{
            d.inputObjCon[1] = null;
            d.inputObj[1] = null;
            d.inputCharge[1] = false;
            d.outputCharge[1] = false;
        }
        switch (gateType){
            case 0: //OR
                outputCharge = (d.outputCharge[0] || d.outputCharge[1]);
                break;
            case 1: //AND
                outputCharge = (d.outputCharge[0] && d.outputCharge[1]);
                break;
            case 2: //NOR
                outputCharge = (!d.outputCharge[0] && !d.outputCharge[1]);
                break;
            case 3: //NAND
                outputCharge = (!d.outputCharge[0] || !d.outputCharge[1]);
                break;
            case 4: //XOR
                outputCharge = (d.outputCharge[0] != d.outputCharge[1]);
                break;
        }
        //d.inputCon[0].color = CommonFunctions.BoolToColor(d.inputCharge[0]);
        //d.inputCon[1].color = CommonFunctions.BoolToColor(d.inputCharge[1]);
        d.outputCharge[0] = outputCharge;
        d.outputCharge[1] = outputCharge;
        d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
        d.outputCon[1].color = CommonFunctions.BoolToColor(d.outputCharge[1]);
        Indicator.color = CommonFunctions.BoolToColor(d.outputCharge[0] || d.outputCharge[1]);
        Indicator.sprite = GateIndicators[gateType];
        StartCoroutine("Main");
    }
    void OnMouseDown(){
        if(OnUIHover.hovering) return;
        gateType++;
        if(gateType>=GateIndicators.Length) gateType = 0;
        Indicator.sprite = GateIndicators[gateType];
        CursorSystem.MakeSound(SoundObject, ClickSound, 0.5f);
    }
    void OnDrawGizmosSelected(){
        d = GetComponent<Data>();
        Gizmos.color = new Color(1, 0, 0, 0.75f);
        Gizmos.DrawRay(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right*0.2f);
        Gizmos.DrawRay(d.inputCon[1].gameObject.transform.position, d.inputCon[1].gameObject.transform.right*0.2f);
    }
}
