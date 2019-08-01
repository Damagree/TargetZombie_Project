using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveData : MonoBehaviour
{
    public GameObject HighscorePanel;
    public GameObject NoHighscorePanel;
    public InputField inputName;
    private PlayerData name = new PlayerData(); 
    public static List<PlayerData> ListPlayerData = new List<PlayerData>();

    void Start()
    {
        if (SaveSystem.LoadScore() != null)
        {
            Debug.Log("start");
            ListPlayerData = SaveSystem.LoadScore();
            Debug.Log("load");
            foreach (var item in ListPlayerData)
            {
                Debug.Log("Username: " + item.username + " Score: " + item.score);
            }
            if (ListPlayerData.Count < 10)
            {
                
                HighscorePanel.SetActive(true);
                NoHighscorePanel.SetActive(false);
            }
            else
            {
                int temp = -1;
                string nameTemp = "";
                bool First = true;
                bool addToList = false;

                foreach (var item in ListPlayerData)
                {
                    if (item.score < name.score)
                    {
                        addToList = true;
                        if (First == true)
                        {
                            nameTemp = item.username;
                            temp = item.score;
                            First = false;
                        }
                        else if (item.score <= temp)
                        {
                            nameTemp = item.username;
                            temp = item.score;
                        }
                    }
                }

                Debug.Log(nameTemp);


                if (addToList == true)
                {
                    foreach (var item3 in ListPlayerData)
                    {
                        if (item3.username == nameTemp)
                        {
                            Debug.Log(item3.username);
                            Debug.Log(nameTemp);
                            ListPlayerData.Remove(item3);
                            Debug.Log("removed");
                            break;
                        }
                    }
                   
                    HighscorePanel.SetActive(true);
                    NoHighscorePanel.SetActive(false);
                }
                else
                {
                    HighscorePanel.SetActive(false);
                    NoHighscorePanel.SetActive(true);
                }
            }
        }
        else
        {
            HighscorePanel.SetActive(true);
            NoHighscorePanel.SetActive(false);
        }
        
    }

    public void Clicked()
    {
        HighscorePanel.SetActive(false);
        NoHighscorePanel.SetActive(true);
        name.username = inputName.text;
        SaveSystem.SaveScore(name, ListPlayerData);
    }
}
