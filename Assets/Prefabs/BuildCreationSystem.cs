using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCreationSystem : MonoBehaviour
{
    public GameObject BuildingPrefab;
    public GameObject Hint;
    public AudioClip ClickSound;
    public GameObject SoundObject;
    void Start(){
        Hint.SetActive(false);
    }
    public void OnClicked()
    {
        //print(BuildingPrefab.name);
        CursorSystem.MakeSound(SoundObject, ClickSound, 0.5f);
        GameObject TiedBuilding;
        if (CursorSystem.TiedBuilding!=null) Destroy(CursorSystem.TiedBuilding);
        CursorSystem.TiedBuilding = Instantiate(BuildingPrefab, new Vector3(CursorSystem.MousePos.x, CursorSystem.MousePos.y, 1), Quaternion.identity);
        TiedBuilding = CursorSystem.TiedBuilding;
        TiedBuilding.GetComponent<BoxCollider2D>().enabled = false;
        Data tbd = TiedBuilding.GetComponent<Data>();
        for (int i = 0; i < tbd.outputCon.Length; i++)
        {
            tbd.outputCon[i].gameObject.SetActive(false);
        }
        tbd.body.color = new Color(0.6f,0.6f,0.6f,1);
    }
    public void OnHover(bool hovering){
        Hint.SetActive(hovering);
    }
}
