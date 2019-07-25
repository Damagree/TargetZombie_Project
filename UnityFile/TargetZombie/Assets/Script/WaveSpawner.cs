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

    public int spawnPoint = 0;

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

       
        //if (waveIndex == waves.Length)
        //{
        //    gameManager.WinLevel();
        //    this.enabled = false;
        //}

        

        //waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    private void FixedUpdate()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            
            countdown = timeBetweenWaves;
            return;
        }


        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Stages++;

        EnemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            int random = Random.Range(0, 100);
            int civilianIndex = Random.Range(0, 3);

            if(random < 40)
            {
                SpawnEnemy(wave.civilian[civilianIndex]);
            }
            else
            {
                SpawnEnemy(wave.enemy);
            }

            if (spawnPoint == 1)
            {
                spawnPoint = 0;
            }
            else
            {
                spawnPoint++;
            }
            
            yield return new WaitForSeconds(1f);
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
