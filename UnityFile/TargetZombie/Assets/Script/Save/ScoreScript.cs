using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{

    public Text scoreText;
    public Text CannotBlank;
    public Text CannotSame;
    public InputField inputName;
    private float score=0f;
    public GameObject NoHighscorePanel;
    public GameObject HighscorePanel;
    public string Menu="Main Menu";
    public Animator anim;
    private GameObject[] music;
    public GameObject musicManager;
    public UIFader uiFader;



    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.Score == 0)
        {
            scoreText.text = "0";
        }
        else
        {
            StartCoroutine(Scoring());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(HighscorePanel.active == true &&(inputName.text=="" || inputName.text == null))
            {
                anim.SetBool("dropdown", true);
                CannotBlank.enabled = true;
                CannotSame.enabled = false;
            }
            if (NoHighscorePanel.active== true)
            {
                music = GameObject.FindGameObjectsWithTag("music");
                Debug.Log(NoHighscorePanel.active);
                music[0].GetComponent<AudioSource>().clip = musicManager.GetComponent<MusicManager>().menu;
                StartCoroutine(music[0].GetComponent<MusicManager>().FadeIn());
                uiFader.FadeTo(Menu);
            }
        }
    }

    IEnumerator Scoring()
    {
        int ScoreMinEdge = PlayerStats.Score;
        int start;
        float crop = Mathf.Floor(PlayerStats.Score / 100);
        score = (crop*100) - 50;
        if (score < 0)
        {
            score = 0;
        }
        start = (int)score;
        for (int i = start; i < PlayerStats.Score; i++)
        {
            score++;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(.005f);

        }
    }

}
