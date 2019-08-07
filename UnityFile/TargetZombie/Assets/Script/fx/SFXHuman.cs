using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHuman : MonoBehaviour
{
    public static SFXHuman Instance;
    public AudioClip MaleDie;
    public AudioClip WomanDie;

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
}
