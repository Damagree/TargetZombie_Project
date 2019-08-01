using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrtho : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().orthographic = true;
    }
    
}
