﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text scoreText;
    private float score=0f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = 0; i < PlayerStats.Score; i++)
        {

            score++;
            scoreText.text = score.ToString();
            if (PlayerStats.Score < 100)
            {
                yield return new WaitForSeconds(.05f);
            }else if (PlayerStats.Score>100 && PlayerStats.Score < 300)
            {
                yield return new WaitForSeconds(.01f);
            }
            else if (PlayerStats.Score > 300 && PlayerStats.Score < 500)
            {
                yield return new WaitForSeconds(.005f);
            }
            else
            {
                yield return new WaitForSeconds(.001f);
            }
        }
    }

}
