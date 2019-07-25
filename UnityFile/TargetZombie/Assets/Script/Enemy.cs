using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isDead;
    public int worth = 10;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    public void Die()
    {
        isDead = true;

        PlayerStats.Score += worth;
        WaveSpawner.EnemiesAlive--;
    }
}
