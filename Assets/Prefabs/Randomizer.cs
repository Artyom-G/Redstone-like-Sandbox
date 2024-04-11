using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    Data d;
    public SpriteRenderer Indicator1;
    public SpriteRenderer Indicator2;
    bool oldInput = false;
    int Type = 0;
    public LayerMask mask;
    public AudioClip ClickSound;
    public GameObject SoundObject;
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
        if(oldInput != d.inputCharge[0] && d.inputCharge[0]){
            d.inputCon[0].color = CommonFunctions.BoolToColor(d.inputCharge[0]);
            if(Random.Range(0, 2) == 0) d.outputCharge[0] = false;
            else d.outputCharge[0] = true;
            d.outputCon[0].color = CommonFunctions.BoolToColor(d.outputCharge[0]);
            oldInput = d.inputCharge[0];
        }else{
            oldInput = d.inputCharge[0];
        }
        ChangeColor();
        yield return new WaitForSeconds(CommonFunctions.updateTimer);
        StartCoroutine("Main");
    }
    void OnDrawGizmosSelected(){
        d = GetComponent<Data>();
        Gizmos.color = new Color(1, 0, 0, 0.75f);
        Gizmos.DrawRay(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right*0.2f);
    }
    void ChangeColor(){
        Indicator1.color = CommonFunctions.BoolToColor(d.outputCharge[0]);
        Indicator2.color = CommonFunctions.BoolToColor(d.outputCharge[0], 1);
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
