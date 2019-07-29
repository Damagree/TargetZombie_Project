using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject bullet;
    private GameObject[] flashKill;

    public MainMenu mainMenu;

    private Enemy enemy;

    public Text score;
    public GameObject[] heart;
    public Transform SpawnPoinA;
    public Transform SpawnPointD;
    public Button FlashKillButton;

    private int lifeBefore = 3;
    private int beforeScore = 0;

    public ButtonClicked Sound;
    private GameObject[] sfx;

    public GameObject impactEffect;

    private void Start()
    {
        sfx = GameObject.FindGameObjectsWithTag("sfx");

        WaveSpawner.EnemiesAlive = 0;
        PlayerStats.currentLive = 3;
        PlayerStats.Score = 0;

        Debug.Log("sfx dalem sfx: " + Sound.GetComponent<ButtonClicked>().Bullet.name);
        score.text = beforeScore.ToString();
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }


    private void Update()
    {
        //Update Text score
        if(beforeScore != PlayerStats.Score)
        {
            score.text = PlayerStats.Score.ToString();
            beforeScore = PlayerStats.Score;
        }

        //Controller debug
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(bullet, SpawnPoinA.position, SpawnPoinA.rotation);
            
            sfx[0].GetComponent<AudioSource>().clip = Sound.GetComponent<ButtonClicked>().Bullet;
            sfx[0].GetComponent<AudioSource>().Play();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(bullet, SpawnPointD.position, SpawnPointD.rotation);
            sfx = GameObject.FindGameObjectsWithTag("sfx");
            sfx[0].GetComponent<AudioSource>().clip = Sound.GetComponent<ButtonClicked>().Bullet;
            sfx[0].GetComponent<AudioSource>().Play();
        }

        //checking player status
        if(PlayerStats.currentLive <= 0)
        {
            GameOver();
        }

        //Check live
        if(lifeBefore != PlayerStats.currentLive)
        {
            UpdateHeart();
        }

        //death
        if (!PlayerStats.isAlive)
        {
            WaveSpawner.EnemiesAlive = 0;
            PlayerStats.currentLive = 3;
            PlayerStats.isAlive = true;
            mainMenu.GameOver();
        }
    }
    
    void UpdateHeart()
    {
        for (int i = 1; i <= heart.Length; i++)
        {
            if (i <= PlayerStats.currentLive)
            {
                heart[i-1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
            else
            {
                heart[i-1].GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            }

        }
    }

    public void FlashKill()
    {
        flashKill = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject flash in flashKill)
        {
            enemy = flash.GetComponent<Enemy>();
            enemy.Die();
            GameObject effect = Instantiate(impactEffect, enemy.transform.position, enemy.transform.rotation);
            Destroy(effect.gameObject, 3f);
        }
        Debug.Log("score: " + PlayerStats.Score);

    }
    public void onClick()
    {
        FlashKill();
    }

    void GameOver()
    {
        PlayerStats.isAlive = false;
        
    }
}
