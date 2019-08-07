using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{

    private PlayerData[] ListPlayer;
    private List<PlayerData> ListPlayerData = null;

    public string parrentPath;
    public Transform parrentTransform;
    private GameObject parrentObject;
    //Child
    public GameObject Highscore;

    private void Start()
    {
        ListPlayerData = SaveSystem.LoadScore();
        ListPlayer = ListPlayerData.ToArray();
        Debug.Log("listplayer length: " + ListPlayer.Length);
        LoadDataPlayer();
        parrentObject = GameObject.Find(parrentPath);
        for (int i = 0; i < ListPlayer.Length; i++)
        {
            Highscore.GetComponent<PanelHighscore>().InitPanel(i + 1, ListPlayer[i].username, ListPlayer[i].score);
            GameObject newField = Instantiate(Highscore, transform);
            
            newField.transform.SetParent(parrentTransform.transform);

            Vector3 tempScale = newField.transform.localScale;

            Debug.Log("tempScale: " + tempScale);

            tempScale = new Vector3(1, 1, 1) - tempScale;
            newField.transform.localScale += tempScale;

            Debug.Log(newField.transform.localScale);
        }
    }

    void LoadDataPlayer()
    {
       

        for (int i = 0; i < ListPlayer.Length-1; i++)
        {
            for (int j = 0; j < ListPlayer.Length-1; j++)
            {
                if (ListPlayer[j].score < ListPlayer[j+1].score)
                {
                    PlayerData tmp = ListPlayer[j];
                    ListPlayer[j] = ListPlayer[j + 1];
                    ListPlayer[j + 1] = tmp;
                }
            }
        }
    }
}
