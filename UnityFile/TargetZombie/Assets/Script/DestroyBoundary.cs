using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);

        if (other.tag == "Saver" || other.tag == "Bullet")
        {
            return;
        }
        else
        {
            WaveSpawner.EnemiesAlive--;
        }
    }
}
