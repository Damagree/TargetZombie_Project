using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    //public GameManager gameManager;

    public Wave wave;

    public Transform SpawnPoint;
    public Transform SpawnPoint2;
    //public Text waveCountdownText;

    public float timeBetweenWaves = 5f;

    public float countdown = 2f;
    private int waveIndex = 0;

    public int increaseSpeedIndex = 0;
    public int spawnPoint = 0;
    public float spawnWait = 2f;
    
    private void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {

        if (countdown <= 0f)
        {
            
            StartCoroutine(SpawnWave());
            Debug.Log("enemies Alive: " + EnemiesAlive);
            countdown = timeBetweenWaves;
            return;
        }


        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Stages++;
        int counter = wave.count;

        if (increaseSpeedIndex + 2 == PlayerStats.Stages)
        {
            Mover.speed+=0.5f;
            increaseSpeedIndex += 2;
            if (spawnWait > 1)
            {
                spawnWait -= 0.01f;
            }
        }

        for (int i = 0; i < counter; i++)
        {
            int random = Random.Range(0, 100);
            int civilianIndex = Random.Range(0, 3);

            if(random < 40)
            {
                SpawnEnemy(wave.civilian[civilianIndex]);
            }
            else
            {

                int randomZombie = Random.Range(0, 100);

                if (PlayerStats.Stages % 3 == 0)
                {
                    //special zombie
                    if(randomZombie < 20)
                    {
                        SpawnEnemy(wave.enemy[1]);
                    }
                    else
                    {
                        SpawnEnemy(wave.enemy[0]);
                    }
                }
                else
                {
                    SpawnEnemy(wave.enemy[0]);
                }
            }

            if (spawnPoint == 1)
            {
                spawnPoint = 0;
            }
            else
            {
                spawnPoint++;
            }

           
            if (((i+1) % 2) != 0 || i == 0)
            {
                yield return new WaitForSeconds(0f);
            }
            else
            {
                yield return new WaitForSeconds(spawnWait);
            }
            EnemiesAlive++;
        }


        waveIndex++;
        wave.count += 2;

    }

    void SpawnEnemy(GameObject obj)
    {
        
        if (spawnPoint == 0)
        {
            Instantiate(obj, SpawnPoint.position, SpawnPoint.rotation);
            
        }
        if (spawnPoint == 1)
        {
            Instantiate(obj, SpawnPoint2.position, SpawnPoint.rotation);
        }
    }

}
