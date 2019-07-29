using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{

    public Text switchTextMusic;
    public Text switchTextSFX;
    private GameObject[] music;
    private GameObject[] sfx;

    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        sfx = GameObject.FindGameObjectsWithTag("sfx");

        if (music[0].GetComponent<AudioSource>().mute == true)
        {
            switchTextMusic.text = "OFF";
        }
        if (sfx[0].GetComponent<AudioSource>().mute == true)
        {
            switchTextSFX.text = "OFF";
        }
    }
    public void MusicClicked()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        if (switchTextMusic.text == "ON")
        {
            music[0].GetComponent<AudioSource>().mute=true;
            switchTextMusic.text = "OFF";
        }
        else if (switchTextMusic.text == "OFF")
        {
            music[0].GetComponent<AudioSource>().mute =false;
            switchTextMusic.text = "ON";
        }
    }
    public void SFXClicked()
    {
        sfx = GameObject.FindGameObjectsWithTag("sfx");
        if (switchTextSFX.text == "ON")
        {
            sfx[0].GetComponent<AudioSource>().mute=true;
            switchTextSFX.text = "OFF";
        }
        else if (switchTextSFX.text == "OFF")
        {
            sfx[0].GetComponent<AudioSource>().mute =false;
            switchTextSFX.text = "ON";
        }
    }
}
