using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public string mainMenu = "Main Menu";
    public string leaderboard = "Leaderboard";
    public string main = "Main";
    public string setting = "Setting";
    public UIFader uiFader;

    public void Play()
    {
        uiFader.FadeTo(main);
    }

    public void Leaderboard()
    {
        uiFader.FadeTo(leaderboard);
    }
    public void Setting()
    {
        uiFader.FadeTo(setting);
    }

    public void BackToMenu()
    {
        uiFader.FadeTo(mainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
