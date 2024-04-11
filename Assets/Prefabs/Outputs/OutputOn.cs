using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputOn : MonoBehaviour
{
    Data d;
    public LayerMask mask;
    public SpriteRenderer Indicator;
    void Start(){
        d = GetComponent<Data>();
        StartCoroutine("Main");
    }
    public IEnumerator Main(){
        yield return new WaitForSeconds(CommonFunctions.updateTimer);
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
        Indicator.color = CommonFunctions.BoolToColor(d.inputCharge[0]);
        StartCoroutine("Main");
    }
    void OnDrawGizmosSelected(){
        d = GetComponent<Data>();
        Gizmos.color = new Color(1, 0, 0, 0.75f);
        Gizmos.DrawRay(d.inputCon[0].gameObject.transform.position, -d.inputCon[0].gameObject.transform.right*0.2f);
    }
}
