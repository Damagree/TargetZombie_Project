using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redline : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Civilian")
        {
            PlayerStats.Score++;
            Debug.Log("Saved");
        }
    }
}
