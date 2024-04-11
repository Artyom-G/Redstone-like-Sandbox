using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUIHover : MonoBehaviour
{
    public static bool hovering;

    public void Hovering(bool _hovering){
        hovering = _hovering;
        print(hovering);
    }
}
