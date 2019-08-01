using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redline : MonoBehaviour
{
    public int scoreMale = 10;
    public int scoreMale2 = 15;
    public int scoreFemale = 20;
    public int enemy = 10;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MaleCivilian")
        {
            PlayerStats.Score += scoreMale;
        }

        if (other.tag == "MaleCivilian2")
        {
            PlayerStats.Score += scoreMale2;
        }

        if (other.tag == "FemaleCivilian")
        {
            PlayerStats.Score += scoreFemale;
        }

        if (other.tag == "Enemy" || other.tag == "SpecialEnemy")
        {
            if (PlayerStats.Score-enemy < 0)
            {
                PlayerStats.Score = 0;
            }
            else
            {
                PlayerStats.Score -= enemy;
                
            }
            PlayerStats.currentLive--;

        }
        

        Debug.Log("current score: " + PlayerStats.Score);
    }
}
