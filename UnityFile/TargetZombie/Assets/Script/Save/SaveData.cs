using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveData : MonoBehaviour
{
    public GameObject HighscorePanel;
    public GameObject NoHighscorePanel;
    public GameObject ValidationPanel;
    public GameObject HighestScoreStar;
    public Text CannotBlank;
    public Text CannotSame;
    public InputField inputName;
    private PlayerData name = new PlayerData();
    public Animator anim;
    public static List<PlayerData> ListPlayerData = new List<PlayerData>();

    private string inputUser;
    private bool hasTyped = false;

    void Start()
    {
        if (SaveSystem.LoadScore() != null)
        {
            bool highest = true;
            ListPlayerData = SaveSystem.LoadScore();

            if (ListPlayerData.Count < 10)
            {
                Debug.Log(ListPlayerData.Count);
                if (ListPlayerData.Count > 0)
                {
                    foreach (var item in ListPlayerData)
                    {
                        if (item.score > name.score)
                        {
                            highest = false;
                        }
                    }
                }
                if (highest == true)
                {
                    HighestScoreStar.SetActive(true);
                }
                else
                {
                    HighestScoreStar.SetActive(false);
                }
                HighscorePanel.SetActive(true);
                NoHighscorePanel.SetActive(false);
            }
            else
            {
                int temp = -1;
                string nameTemp = "";
                bool First = true;
                bool addToList = false;
                highest = true;
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
                    else{
                        highest = false;
                    }
                }

                if (highest == true)
                {
                    HighestScoreStar.SetActive(true);
                }
                else
                {
                    HighestScoreStar.SetActive(false);
                }


                if (addToList == true)
                {
                    foreach (var item3 in ListPlayerData)
                    {
                        if (item3.username == nameTemp && item3.score == temp)
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

    public void InputClicked()
    {
        inputUser = inputName.text;
        if (inputName.text == "" && !hasTyped)
        {
            anim.SetBool("dropdown", false);
            CannotSame.enabled = false;
            CannotBlank.enabled = false;
            hasTyped = true;
        }

    }

    public void Clicked()
    {
        bool Same = false;
        if ((inputUser != null || inputUser != "" ) && inputName.text != "")
        {
            foreach (var item in ListPlayerData)
            {
                if(inputUser == item.username)
                {
                    Same = true;
                    break;
                }
            }
            if (Same == true)
            {
                anim.SetBool("dropdown", true);
                CannotSame.enabled = true;
                CannotBlank.enabled = false;
            }
            else {
                HighscorePanel.SetActive(false);
                NoHighscorePanel.SetActive(true);
                name.username = inputUser;
                SaveSystem.SaveScore(name, ListPlayerData);
            }
        }
        else
        {
            anim.SetBool("dropdown", true);
            CannotSame.enabled = false;
            CannotBlank.enabled = true;
            
        }
    }
}
