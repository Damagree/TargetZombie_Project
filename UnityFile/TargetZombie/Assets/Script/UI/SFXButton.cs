using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SFXButton : MonoBehaviour
{

    public static SFXButton Instance;
    public AudioClip FlashKill;
    public AudioClip Button;

    public bool off = true;

    public void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            off = false;
        }
    }

    public void Clicked()
    {
        GameObject[] sfx;
        sfx = GameObject.FindGameObjectsWithTag("sfxButtons");
        sfx[0].GetComponent<AudioSource>().clip = Button;
        sfx[0].GetComponent<AudioSource>().Play();
    }

    public void Flash()
    {
        GameObject[] sfx;
        sfx = GameObject.FindGameObjectsWithTag("sfxButtons");
        sfx[0].GetComponent<AudioSource>().clip = FlashKill;
        sfx[0].GetComponent<AudioSource>().Play();
    }
}
