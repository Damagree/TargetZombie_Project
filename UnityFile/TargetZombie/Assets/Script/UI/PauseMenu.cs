using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public string menuSceneName;
    public UIFader uiFader;
    public GameObject musicManager;
    private GameObject[] music;

    public void Clicked()
    {
           Toggle();
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        uiFader.FadeTo(SceneManager.GetActiveScene().name);
        WaveSpawner.EnemiesAlive = 0;
    }

    public void Menu()
    {
        Toggle();
        music = GameObject.FindGameObjectsWithTag("music");
        music[0].GetComponent<AudioSource>().clip = musicManager.GetComponent<MusicManager>().menu;
        StartCoroutine(music[0].GetComponent<MusicManager>().FadeIn());
        uiFader.FadeTo(menuSceneName);
        WaveSpawner.EnemiesAlive = 0;
    }
}
