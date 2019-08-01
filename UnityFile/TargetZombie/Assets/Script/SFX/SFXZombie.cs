using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXZombie : MonoBehaviour
{
    public static SFXZombie Instance;
    public AudioClip Zombie;
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
