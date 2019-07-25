using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioClip menu;
    public AudioClip main;
    public bool off=true;
    

    public void Awake()
    {
        gameObject.GetComponent<AudioSource>().clip = menu;
        Debug.Log("nama Menu: " + menu.name);
        Debug.Log("nama Main: " + main.name);

        gameObject.GetComponent<AudioSource>().Play();
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
                off = false;
            }
        

    }
    public void Mute()
    {
        gameObject.SetActive(false);
    }
}