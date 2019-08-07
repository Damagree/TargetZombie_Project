using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXBullet : MonoBehaviour
{
    public static SFXBullet Instance;
    public AudioClip Bullet;
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
