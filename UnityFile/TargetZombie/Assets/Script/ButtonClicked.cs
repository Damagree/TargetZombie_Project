using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{

    public static ButtonClicked Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Lewat 1");
            GameObject.Destroy(this);
        }
        else
        {
            Debug.Log("Lewat 2");
            Instance = this;
            DontDestroyOnLoad(this);
        }


    }

    public void Clicked()
    {
        GameObject[] sfx;
        sfx = GameObject.FindGameObjectsWithTag("sfx");
        sfx[0].GetComponent<AudioSource>().Play();
        //Instance = this;
    }
}
