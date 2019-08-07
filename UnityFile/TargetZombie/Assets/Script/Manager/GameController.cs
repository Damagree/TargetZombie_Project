using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSaver;
    private GameObject[] flashKill;
    private GameObject[] flashKillSpecial;

    private Vector2 beginTouchPos, endTouchPos;
    private Touch touch;
    public List<touchLocation> touches = new List<touchLocation>();

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
    public GameObject tutorial;
    public Text speed;
    private float beforeSpeed=0;
    private float tutorialTime = 3f;


    private void Start()
    {
        sfx = GameObject.FindGameObjectsWithTag("sfxZombies");
        WaveSpawner.EnemiesAlive = 0;
        PlayerStats.currentLive = 3;
        PlayerStats.Score = 0;
        Mover.speed = 1;
        PlayerStats.Stages = 0;
        WaveSpawner.spawnWait = 2f;
        PlayerStats.hasFlashKill = false;
        beforeSpeed= Mover.speed;
        speed.text = Mover.speed.ToString();

        score.text = beforeScore.ToString();
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }

    private void Update()
    {
        if (tutorialTime >= 0)
        {
            Debug.Log(tutorialTime);
            tutorial.SetActive(true);
            tutorialTime -= Time.deltaTime;
        }
        else
        {
            Destroy(tutorial);
        }
        //Update Text score
        if (beforeScore != PlayerStats.Score)
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

        int i = 0;
        while (i < Input.touchCount)
        {
            Vector2 Tolerance = new Vector2(Screen.width / 10, Screen.height / 10);
            touch = Input.GetTouch(i);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touches.Add(new touchLocation(touch.fingerId, touch.position));
                    //beginTouchPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    touchLocation currentTouch = touches.Find(touchLocation => touchLocation.touchId == touch.fingerId);
                    currentTouch.endTouch = touch.position;
                    //endTouchPos = touch.position;
                    if (currentTouch.beginTouch.y <= Screen.height / 2)
                    {
                        if (currentTouch.beginTouch == currentTouch.endTouch)
                        {
                            CheckTap(currentTouch.beginTouch);
                        }
                         else if (currentTouch.beginTouch != currentTouch.endTouch) 
                        {
                            if (Mathf.Abs(currentTouch.endTouch.x - currentTouch.beginTouch.x) >= Tolerance.x ||
                                Mathf.Abs(currentTouch.endTouch.y - currentTouch.beginTouch.y) >= Tolerance.y)
                            {
                                CheckSwipe(currentTouch.beginTouch);
                            }
                            else
                            {
                                CheckTap(currentTouch.beginTouch);
                            }
                        }
                        
                    }
                    touches.RemoveAt(touches.IndexOf(currentTouch));
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break; 
            }
            i++;
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
        if (PlayerStats.hasFlashKill == true)
        {
            flashKillButton.SetActive(true);
        }
        else
        {
            flashKillButton.SetActive(false);
        }

        //death
        if (!PlayerStats.isAlive)
        {
            WaveSpawner.EnemiesAlive = 0;
            PlayerStats.currentLive = 3;
            PlayerStats.isAlive = true;
            mainMenu.GameOver();
        }
        if (beforeSpeed != Mover.speed) 
        {
            beforeSpeed = Mover.speed;
            speed.text=Mover.speed.ToString();
        }
    }
    
    void UpdateHeart()
    {
        for (int i = 1; i <= heart.Length; i++)
        {
            if (PlayerStats.currentLive >= 0)
            {
                if (i <= PlayerStats.currentLive)
                {
                    heart[i - 1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                }
                else
                {
                    heart[i - 1].GetComponent<Image>().color = new Color32(255, 0, 0, 100);
                }
            }
            else
            {
                heart[i - 1].GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            }

        }
    }

    public void FlashKill()
    {
        flashKill = GameObject.FindGameObjectsWithTag("Enemy");
        flashKillSpecial = GameObject.FindGameObjectsWithTag("SpecialEnemy");

        if (flashKill != null)
        {
            foreach (GameObject flash in flashKill)
            {
                enemy = flash.GetComponent<Enemy>();
                enemy.Die();
                GameObject effect = Instantiate(impactEffect, enemy.transform.position, enemy.transform.rotation);
                Destroy(effect.gameObject, 3f);

            }
        }
        if (flashKillSpecial != null)
        {
            foreach (GameObject flash in flashKillSpecial)
            {
                enemy = flash.GetComponent<Enemy>();
                enemy.Die();
                GameObject effect = Instantiate(impactEffect, enemy.transform.position, enemy.transform.rotation);
                Destroy(effect.gameObject, 3f);

            }
        }

        Handheld.Vibrate();
        PlayerStats.hasFlashKill = false;
        flashKillFader.SetActive(false);
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

    void CheckTap(Vector2 beginTouch)
    {
        if (beginTouch.x < Screen.width / 2)
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

    void CheckSwipe(Vector2 beginTouch)
    {
        if (beginTouch.x < Screen.width / 2)
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
