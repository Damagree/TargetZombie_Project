using UnityEngine;

public class SetResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("NativeWidth") == 0 || PlayerPrefs.GetFloat("NativeHeight") == 0)
        {
            PlayerPrefs.SetFloat("NativeWidth", Screen.width);
            PlayerPrefs.SetFloat("NativeHeight", Screen.height);
        }

        Screen.SetResolution(1280, 720, true);
        Camera.main.aspect = PlayerPrefs.GetFloat("NativeWidth") / PlayerPrefs.GetFloat("NativeHeight");
    }
}
