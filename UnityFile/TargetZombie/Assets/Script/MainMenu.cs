using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public string mainMenu = "Main Menu";
    public string leaderboard = "Leaderboard";
    public string main = "Main";
    public string setting = "Setting";
    public string gameOver = "Game Over";
    public UIFader uiFader;
    public GameObject musicManager;
    public GameObject buttonClicked;
    private GameObject[] music;
    private GameObject[] sfx;


    private void Start()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        sfx = GameObject.FindGameObjectsWithTag("sfx");

        if (music.Length == 0)
        {
            Instantiate<GameObject>(musicManager);
    
        }
        if (sfx.Length == 0)
        {
            Instantiate<GameObject>(buttonClicked);

        }
    }

    public void Play()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        music[0].GetComponent<AudioSource>().clip = musicManager.GetComponent<MusicManager>().main;
        music[0].GetComponent<AudioSource>().volume = 1;
        music[0].GetComponent<AudioSource>().Play();
        uiFader.FadeTo(main);
    }

    public void Leaderboard()
    {
        uiFader.FadeTo(leaderboard);
    }
    public void Setting()
    {
        uiFader.FadeTo(setting);
    }

    public void BackToMenu()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        if (music[0].GetComponent<AudioSource>().clip.name != musicManager.GetComponent<MusicManager>().menu.name)
        {
            music[0].GetComponent<AudioSource>().clip = musicManager.GetComponent<MusicManager>().menu;
            StartCoroutine(music[0].GetComponent<MusicManager>().FadeIn());
        }
        uiFader.FadeTo(mainMenu);
    }

    public void GameOver()
    {
        music = GameObject.FindGameObjectsWithTag("music");
        if (music[0].GetComponent<AudioSource>().clip.name != musicManager.GetComponent<MusicManager>().gameOver.name)
        {
            music[0].GetComponent<AudioSource>().clip = musicManager.GetComponent<MusicManager>().gameOver;
            StartCoroutine(music[0].GetComponent<MusicManager>().FadeIn());
        }
        uiFader.FadeTo(gameOver);
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitsSeconds()
    {
        yield return new WaitForSeconds(1f);
    }
}
