using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{

    public Text switchTextMusic;
    public Text switchTextSFX;
    private GameObject[] music;
    private GameObject[] sfxButtons;
    private GameObject[] sfxBullets;
    private GameObject[] sfxZombies;
    private GameObject[] sfxHumans;

    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        sfxButtons = GameObject.FindGameObjectsWithTag("sfxButtons");
        sfxBullets = GameObject.FindGameObjectsWithTag("sfxBullets");
        sfxZombies = GameObject.FindGameObjectsWithTag("sfxZombies");
        sfxHumans = GameObject.FindGameObjectsWithTag("sfxHumans");

        if (music[0].GetComponent<AudioSource>().mute == true)
        {
            switchTextMusic.text = "OFF";
        }
        if (sfxButtons[0].GetComponent<AudioSource>().mute == true)
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
        if (switchTextSFX.text == "ON")
        {
            sfxButtons[0].GetComponent<AudioSource>().mute=true;
            sfxBullets[0].GetComponent<AudioSource>().mute = true;
            sfxZombies[0].GetComponent<AudioSource>().mute = true;
            sfxHumans[0].GetComponent<AudioSource>().mute = true;
            switchTextSFX.text = "OFF";
        }
        else if (switchTextSFX.text == "OFF")
        {
            sfxButtons[0].GetComponent<AudioSource>().mute = false;
            sfxBullets[0].GetComponent<AudioSource>().mute = false;
            sfxZombies[0].GetComponent<AudioSource>().mute = false;
            sfxHumans[0].GetComponent<AudioSource>().mute = false;
            switchTextSFX.text = "ON";
        }
    }
}
