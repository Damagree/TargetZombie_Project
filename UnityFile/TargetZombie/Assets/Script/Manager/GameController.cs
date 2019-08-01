using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSaver;
    private GameObject[] flashKill;

    private Vector2 beginTouchPos, endTouchPos;
    private Touch touch;

    public MainMenu mainMenu;

    private Enemy enemy;

    public Text score;
    public GameObject[] heart;
    public Transform SpawnPoinA;
    public Transform SpawnPointD;

    private int lifeBefore = 3;
    private int beforeScore = 0;

    public SFXBullet BulletSound;
    private GameObject[] sfx;

    public GameObject flashKillButton;
    public GameObject flashKillFader;
    public GameObject impactEffect;
    public GameObject flashButton;

    private void Start()
    {
        sfx = GameObject.FindGameObjectsWithTag("sfxZombies");
        WaveSpawner.EnemiesAlive = 0;
        PlayerStats.currentLive = 3;
        PlayerStats.Score = 0;
        Mover.speed = 1;
        WaveSpawner.spawnWait = 2f;
        PlayerStats.hasFlashKill = false;

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

            //sound Effect
            PlayBulletSFX();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(bullet, SpawnPointD.position, SpawnPointD.rotation);

            //sound Effect
            PlayBulletSFX();
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bulletSaver, SpawnPoinA.position, SpawnPoinA.rotation);

            //sound Effect
            PlayBulletSFX();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(bulletSaver, SpawnPointD.position, SpawnPointD.rotation);

            //sound Effect
            PlayBulletSFX();
        }

        //Touch Input
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Debug.Log("Current Position x : " + touch.position.x);
            Debug.Log("Current Position y : " + touch.position.y);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    beginTouchPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    endTouchPos = touch.position;
                    if (beginTouchPos.y <= Screen.height / 2)
                    {

                        Debug.Log("begin y: " + beginTouchPos.y);
                        Debug.Log("end y: " + endTouchPos.y);

                        if (beginTouchPos == endTouchPos)
                        {
                            CheckTap();
                        }

                        if (beginTouchPos != endTouchPos)
                        {
                            CheckSwipe();
                        }
                    }


                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }
        }

        //checking player status
        if (PlayerStats.currentLive <= 0)
        {
            GameOver();
        }

        //Check live
        if(lifeBefore != PlayerStats.currentLive)
        {
            UpdateHeart();
        }

        //FlashKill earned
        FlashKillButtonActive();

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
        foreach (GameObject flash in flashKill)
        {
            enemy = flash.GetComponent<Enemy>();
            enemy.Die();
            GameObject effect = Instantiate(impactEffect, enemy.transform.position, enemy.transform.rotation);
            Destroy(effect.gameObject, 3f);

        }
        PlayerStats.hasFlashKill = false;
        flashKillFader.SetActive(false);
    }

    void FlashKillButtonActive()
    {
        if(PlayerStats.hasFlashKill == true)
        {
            flashKillButton.SetActive(true);
        }
        else
        {
            flashButton.GetComponent<Animator>().Play("Normal", 0, 0f);
            flashButton.GetComponent<Animator>().Play("Pressed", 0, 0f);
            flashButton.GetComponent<Animator>().Play("Highlighted", 0, 0f);
            flashKillButton.SetActive(false);
        }
    }

    public void onClick()
    {
        FlashKill();
        flashKillFader.SetActive(true);
    }

    void PlayBulletSFX()
    {
        sfx[0].GetComponent<AudioSource>().clip = BulletSound.GetComponent<SFXBullet>().Bullet;
        sfx[0].GetComponent<AudioSource>().Play();
    }

    void GameOver()
    {
        PlayerStats.isAlive = false;
    }

    void CheckTap()
    {
        if (beginTouchPos.x < Screen.width / 2)
        {
            Instantiate(bullet, SpawnPoinA.position, SpawnPoinA.rotation);

            //sound Effect
            PlayBulletSFX();
        }
        else
        {
            Instantiate(bullet, SpawnPointD.position, SpawnPointD.rotation);

            //sound Effect
            PlayBulletSFX();
        }
    }

    void CheckSwipe()
    {
        if (beginTouchPos.x < Screen.width / 2)
        {
            Instantiate(bulletSaver, SpawnPoinA.position, SpawnPoinA.rotation);
            PlayBulletSFX();
        }
        else
        {
            Instantiate(bulletSaver, SpawnPointD.position, SpawnPointD.rotation);
            PlayBulletSFX();
        }
    }
}
