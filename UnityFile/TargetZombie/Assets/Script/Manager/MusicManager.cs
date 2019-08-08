using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioClip menu;
    public AudioClip main;
    public AudioClip gameOver;
    public bool off=true;
    

    public void Awake()
    {
        if (SceneManager.GetSceneByName("Game Over").isLoaded == false)
        {
            gameObject.GetComponent<AudioSource>().clip = menu;
            StartCoroutine(FadeIn());
            if (Instance != null)
            {
                GameObject.Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
                off = false;
            }
        }
        else
        {
          
            if (Instance != null)
            {
                GameObject.Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
                off = false;
            }
        }

    }

    public IEnumerator FadeIn()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().volume = 0f;
        while (gameObject.GetComponent<AudioSource>().volume != 1.0f)
        {
            gameObject.GetComponent<AudioSource>().volume += Time.deltaTime/2f ;
            yield return null;
        }
    }
    public IEnumerator FadeOut()
    {
        float startVolume = gameObject.GetComponent<AudioSource>().volume;
        while (gameObject.GetComponent<AudioSource>().volume > 0)
        {
            gameObject.GetComponent<AudioSource>().volume -= startVolume * Time.deltaTime / 5f;
            yield return null;
        }
    }
}