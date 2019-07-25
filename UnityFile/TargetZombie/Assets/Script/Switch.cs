using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{

    public Text switchText;
    public MusicManager audio;
    private GameObject[] music;
    private GameObject[] sfx;
   
    public void MusicClicked()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        if (switchText.text == "ON")
        {
            music[0].GetComponent<AudioSource>().mute=true;
            switchText.text = "OFF";
        }
        else if (switchText.text == "OFF")
        {
            music[0].GetComponent<AudioSource>().mute =false;
            switchText.text = "ON";
        }
    }
    public void SFXClicked()
    {
        sfx = GameObject.FindGameObjectsWithTag("sfx");
        if (switchText.text == "ON")
        {
            sfx[0].GetComponent<AudioSource>().mute=true;
            switchText.text = "OFF";
        }
        else if (switchText.text == "OFF")
        {
            sfx[0].GetComponent<AudioSource>().mute =false;
            switchText.text = "ON";
        }
    }
}
