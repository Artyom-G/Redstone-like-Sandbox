using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cross : MonoBehaviour
{
    Data d;
    public Sprite Body1;
    public Sprite Body0;
    public LayerMask mask;
    bool charges=false;
    float WaitTime;
    RaycastHit2D[] inputRay = new RaycastHit2D[4];
    void Start(){
        WaitTime = CommonFunctions.updateTimer;
        d = GetComponent<Data>();
        StartCoroutine("Main");
    }
    public IEnumerator Main(){
        yield return new WaitForSeconds(WaitTime);
        WaitTime = CommonFunctions.updateTimer;    

        for (int i = 0; i < d.inputCharge.Length; i++)
        {
            d.inputCharge[i]=false;
            d.inputObj[i]=null;
            d.inputObjCon[i]=null;
            d.outputCharge[i]=false;
            d.outputObj[i]=null;
            d.outputObjCon[i]=null;
        }

        //inputRay[0] = Physics2D.Raycast(new Vector3(0,0,0), new Vector3(1,1,1));
        inputRay[0] = Physics2D.Raycast(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right, 0.2f, mask, transform.position.z);
        inputRay[1] = Physics2D.Raycast(d.inputCon[1].gameObject.transform.position, d.inputCon[1].gameObject.transform.right, 0.2f, mask, transform.position.z);
        inputRay[2] = Physics2D.Raycast(d.inputCon[2].gameObject.transform.position, d.inputCon[2].gameObject.transform.up, 0.2f, mask, transform.position.z);
        inputRay[3] = Physics2D.Raycast(d.inputCon[3].gameObject.transform.position, -d.inputCon[3].gameObject.transform.up, 0.2f, mask, transform.position.z);
        charges = false;
        for (int i = 0; i < inputRay.Length; i++)
        {
            if (inputRay[i].collider != null){
                d.inputObjCon[i] = inputRay[i].transform.gameObject.GetComponent<SpriteRenderer>();
                //d.inputObjCon[i].enabled=true;
                d.inputObj[i] = d.inputObjCon[i].transform.parent.parent.gameObject;
                d.inputCharge[i] = d.inputObj[i].GetComponent<Data>().outputCharge[0];
                if(d.inputCharge[i]) 
                {
                    charges = true;
                }
            }
            else{
                d.inputObjCon[i] = null;
                d.inputObj[i] = null;
                d.inputCharge[i] = false;
                //d.inputObjCon[i].enabled=false;
            }
        }
        for (int i = 0; i < inputRay.Length; i++)
        {
            d.inputCon[i].color = CommonFunctions.BoolToColor(d.inputCharge[i]);
            d.outputCharge[i] = charges;
            d.outputCon[i].color = CommonFunctions.BoolToColor(d.outputCharge[i]);
            d.body.sprite = CommonFunctions.BoolToSprite(d.outputCharge[i], Body0, Body1);
        }
        StartCoroutine("Main");
    }
    public void UpdateListener(object sender, EventArgs e){
        for (int i = 0; i < d.inputCharge.Length; i++)
        {
            d.inputCharge[i]=false;
            d.inputObj[i]=null;
            d.inputObjCon[i]=null;
            d.outputCharge[i]=false;
            d.outputObj[i]=null;
            d.outputObjCon[i]=null;
            d.outputCon[i].color = CommonFunctions.BoolToColor(d.outputCharge[i]);
            d.body.sprite = CommonFunctions.BoolToSprite(d.outputCharge[i], Body0, Body1);
            WaitTime = 0.3f;
            StopCoroutine("Main");
            StartCoroutine("Main");
        }
    }
    void OnEnable(){
        Data.OnMapUpdate += UpdateListener;
    }
    void OnDisable(){
        Data.OnMapUpdate -= UpdateListener;
    }
    void OnDrawGizmosSelected(){
        d = GetComponent<Data>();
        Gizmos.color = new Color(1, 0, 0, 0.75f);
        Gizmos.DrawRay(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right*0.2f);
        Gizmos.DrawRay(d.inputCon[1].gameObject.transform.position, d.inputCon[1].gameObject.transform.right*0.2f);
        Gizmos.DrawRay(d.inputCon[2].gameObject.transform.position, d.inputCon[2].gameObject.transform.up*0.2f);
        Gizmos.DrawRay(d.inputCon[3].gameObject.transform.position, -d.inputCon[3].gameObject.transform.up*0.2f);
    }
}
