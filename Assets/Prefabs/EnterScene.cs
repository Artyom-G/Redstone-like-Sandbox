using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour
{
    public string sceneName = "SampleScene";
    public void LoadScene(){
        SceneManager.LoadScene(sceneName);
    }
}
