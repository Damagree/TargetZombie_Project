using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject zombie;
    public GameObject[] civilians;
    public Vector3 spawnValues;
    public Vector3 spawnValues2;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }
    
    void SpawnWave()
    {
        Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = new Quaternion(0, 180, 0, 1);
        Instantiate(zombie, spawnPosition, spawnRotation);

        Vector3 spawnPosition2 = new Vector3(spawnValues2.x, spawnValues2.y, spawnValues2.z);
        Instantiate(zombie, spawnPosition2, spawnRotation);
    }

}
