using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{

    public Text switchText;

    public void Clicked()
    {
        if (switchText.text == "ON")
        {
            switchText.text = "OFF";
        }
        else if (switchText.text == "OFF")
        {
            switchText.text = "ON";
        }
    }
}
