using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CursorSystem : MonoBehaviour
{
    [Header("General")]
    SpriteRenderer CursorSprite;
    public Sprite CursorPoint;
    public Sprite CursorClick;
    public Camera cam;
    [System.NonSerialized]
    public static GameObject TiedBuilding = null;
    [Header("Mouse")]
    static public Vector2 MousePos;
    [Range(0, 10)]
    public float mouseScrollWheelSensitivity = 1.5f;
    [Range(0, 1)]
    public float mouseMovementSensitivity = 0.1f;
    Vector2 MouseMovementInitialPos;
    public AudioClip PlaceSound;
    public GameObject SoundObject;
    public static UnityEvent OnColorChange;
    public bool customCursor = false;
    void Awake(){
        if (OnColorChange == null) OnColorChange = new UnityEvent();
    }
    void Start(){
        Cursor.visible = !customCursor;
        CursorSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        CursorSprite.gameObject.SetActive(customCursor);
    }
    void Update(){
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(MousePos.x,MousePos.y,0);
        if(TiedBuilding!=null) {
            TiedBuilding.transform.position = new Vector3(Mathf.Round(transform.position.x+0.5f), Mathf.Round(transform.position.y+0.5f), 1);
            RaycastHit2D checkBuildingOnTile = Physics2D.Raycast(TiedBuilding.transform.position + new Vector3(-0.5f,-0.5f,0), Vector3.up, 0.1f);
            if(Input.GetMouseButtonUp(0) && checkBuildingOnTile.collider == null) {
                TiedBuilding.transform.position = new Vector3(Mathf.Round(transform.position.x+0.5f), Mathf.Round(transform.position.y+0.5f), 0);
                TiedBuilding.GetComponent<BoxCollider2D>().enabled = true;
                Data tbd = TiedBuilding.GetComponent<Data>();
                for (int i = 0; i < tbd.outputCon.Length; i++)
                {
                    tbd.outputCon[i].gameObject.SetActive(true);
                }
                tbd.body.color = new Color(1,1,1,1);
                TiedBuilding = null;
                MakeSound(SoundObject, PlaceSound, 0.5f);
            }
        }
        if(Input.GetMouseButton(0)){
            CursorSprite.sprite = CursorClick;
            if(Input.GetMouseButtonDown(0)) MouseMovementInitialPos = MousePos;
            cam.transform.position -= new Vector3(-MouseMovementInitialPos.x + MousePos.x, -MouseMovementInitialPos.y + MousePos.y, 0) * mouseMovementSensitivity;
        }
        else{
            CursorSprite.sprite = CursorPoint;
        }
        if(Input.GetAxis("Mouse ScrollWheel") != 0) cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * mouseScrollWheelSensitivity;
        if(Input.GetKeyDown("c")) {
            CommonFunctions.ColorIndex++;
            MakeSound(SoundObject, PlaceSound, 0.5f);
            if (CommonFunctions.ColorIndex >= CommonFunctions.ChargeColors.GetLength(0)) CommonFunctions.ColorIndex = 0;
            if(OnColorChange != null) OnColorChange.Invoke();
        }
    }
    static public void MakeSound(GameObject SoundObjPrefab, AudioClip ac, float lifetime){
        GameObject _obj = Instantiate(SoundObjPrefab);
        AudioSource _as = _obj.GetComponent<AudioSource>();
        _as.clip = ac;
        _as.Play();
        Destroy(_obj, lifetime);
    }
}
