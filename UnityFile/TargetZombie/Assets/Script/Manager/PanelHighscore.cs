using UnityEngine;
using UnityEngine.UI;

public class PanelHighscore : MonoBehaviour
{
    public Text nameText;
    public Text scoreText;
    public Text rank;

    public void InitPanel(int ranking, string name, int score)
    {
        nameText.text = name;
        scoreText.text = score.ToString();
        rank.text = ranking.ToString();
    }
}
