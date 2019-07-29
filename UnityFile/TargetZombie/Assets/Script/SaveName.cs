using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveName : MonoBehaviour
{
    public GameObject HighscorePanel;
    public GameObject NoHighscorePanel;
    bool Highscore = true;

    void Start()
    {
        if (Highscore == true)
        {
            HighscorePanel.SetActive(true);
            NoHighscorePanel.SetActive(false);
        }
        else
        {
            HighscorePanel.SetActive(false);
            NoHighscorePanel.SetActive(true);
        }
    }

    public void Clicked()
    {
        HighscorePanel.SetActive(false);
        NoHighscorePanel.SetActive(true);
    }
}
