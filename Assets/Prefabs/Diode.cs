using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diode : MonoBehaviour
{
    Data d;
    public Sprite[] Indicators = new Sprite[5];
    public SpriteRenderer Indicator1;
    public SpriteRenderer Indicator2;
    public Sprite[] Body = new Sprite[5];
    public LayerMask mask;
    public int Type = 0;
    public AudioClip ClickSound;
    public GameObject SoundObject;
    void Start(){
        d = GetComponent<Data>();
        StartCoroutine("Main");
    }
public IEnumerator Main(){
        yield return new WaitForSeconds(CommonFunctions.updateTimer);
        d.outputCon[0].gameObject.SetActive(true);
        d.outputCon[1].gameObject.SetActive(false);
        d.outputCon[2].gameObject.SetActive(false);
        Indicator2.gameObject.SetActive(false);
        d.outputCharge[0] = false;
        d.outputCharge[1] = false;
        d.outputCharge[2] = false;
        RaycastHit2D inputRay1 = Physics2D.Raycast(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right, 0.2f, mask, transform.position.z);
        if (inputRay1.collider != null){
            d.inputObjCon[0] = inputRay1.transform.gameObject.GetComponent<SpriteRenderer>();
            d.inputObj[0] = d.inputObjCon[0].transform.parent.parent.gameObject;
            d.outputCharge[0] = d.inputCharge[0];
            d.inputCharge[0] = d.inputObj[0].GetComponent<Data>().outputCharge[CommonFunctions.FindIndexOfCon(d.inputObjCon[0])];
        }
        else{
            d.inputObjCon[0] = null;
            d.inputObj[0] = null;
            d.inputCharge[0] = false;
            d.outputCharge[0] = false;
        }
        RaycastHit2D inputRay2 = Physics2D.Raycast(d.inputCon[1].gameObject.transform.position, -d.inputCon[1].gameObject.transform.up, 0.2f, mask, transform.position.z);
        switch (Type){
            case 0: //1-Way
                d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
                break;
            case 1: //1-Way Angled
                d.outputCharge[1] = d.outputCharge[0];
                d.outputCharge[0] = false;
                d.outputCon[1].color = CommonFunctions.BoolToColor(d.outputCharge[1]);
                d.outputCon[0].gameObject.SetActive(false);
                d.outputCon[1].gameObject.SetActive(true);
                break;
            case 2: //2-Way
                d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
                d.outputCharge[1] = d.outputCharge[0];
                d.outputCon[1].color = CommonFunctions.BoolToColor(d.outputCharge[1]);
                d.outputCon[1].gameObject.SetActive(true);
                break;
            case 3: //2-Way T-Shaped
                d.outputCharge[1] = d.outputCharge[0];
                d.outputCon[1].color = CommonFunctions.BoolToColor(d.outputCharge[1]);
                d.outputCharge[2] = d.outputCharge[0];
                d.outputCharge[0] = false;
                d.outputCon[2].color = CommonFunctions.BoolToColor(d.outputCharge[2]);
                d.outputCon[0].gameObject.SetActive(false);
                d.outputCon[1].gameObject.SetActive(true);
                d.outputCon[2].gameObject.SetActive(true);
                break;
            case 4: //3-Way
                d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
                d.outputCharge[1] = d.outputCharge[0];
                d.outputCon[1].color = CommonFunctions.BoolToColor(d.outputCharge[1]);
                d.outputCharge[2] = d.outputCharge[0];
                d.outputCon[2].color = CommonFunctions.BoolToColor(d.outputCharge[2]);
                d.outputCon[1].gameObject.SetActive(true);
                d.outputCon[2].gameObject.SetActive(true);
                break;
            case 5: //Bridge
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
                Indicator2.gameObject.SetActive(true);
                Indicator2.sprite = Indicators[Type+2];
                d.outputCharge[0] = d.inputCharge[0];
                d.outputCharge[1] = d.inputCharge[1];
                d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
                d.outputCon[1].color = CommonFunctions.BoolToColor(d.outputCharge[1]);
                d.outputCon[1].gameObject.SetActive(true);
                Indicator2.color = CommonFunctions.BoolToColor(d.inputCharge[1]);
                break;
            case 6: //Mirror
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
                Indicator2.gameObject.SetActive(true);
                Indicator2.sprite = Indicators[Type+2];
                d.outputCharge[0] = d.inputCharge[1];
                d.outputCharge[1] = d.inputCharge[0];
                d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
                d.outputCon[1].color = CommonFunctions.BoolToColor(d.outputCharge[1]);
                d.outputCon[1].gameObject.SetActive(true);
                Indicator2.color = CommonFunctions.BoolToColor(d.inputCharge[1]);
                break;
        }
        Indicator1.color = CommonFunctions.BoolToColor(d.inputCharge[0]);
        Indicator1.sprite = Indicators[Type];
        d.body.sprite = Body[Type];
        StartCoroutine("Main");
    }
    void OnMouseDown(){
        if(OnUIHover.hovering) return;
        Type++;
        if(Type>=Body.Length) Type = 0;
        d.body.sprite = Body[Type];
        Indicator1.sprite = Indicators[Type];
        d.body.sprite = Body[Type];
        CursorSystem.MakeSound(SoundObject, ClickSound, 0.5f);
    }
    void OnDrawGizmosSelected(){
        d = GetComponent<Data>();
        Gizmos.color = new Color(1, 0, 0, 0.75f);
        Gizmos.DrawRay(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right*0.2f);
        Gizmos.DrawRay(d.inputCon[1].gameObject.transform.position, -d.inputCon[1].gameObject.transform.up*0.2f);
    }
}
