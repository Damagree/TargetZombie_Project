using UnityEngine;

public class DayNight : MonoBehaviour
{
    public GameObject[] spotLight;
    private bool cekSpotLight = false;
    
    public Light FirstLight;
    public Light SecondLight;

    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime);

        if (transform.localEulerAngles.x >= 0 && transform.localEulerAngles.x < 220)
        {
            for (int i = 0; i < spotLight.Length; i++)
            {
                spotLight[i].SetActive(false);                    
            }
            SecondLight.enabled = true;
            FirstLight.enabled = true;
        }

       
        if (transform.localEulerAngles.x >= 220)
        {
            for (int i = 0; i < spotLight.Length; i++)
            {
               spotLight[i].SetActive(true);                
            }
            SecondLight.enabled = false;
            FirstLight.enabled = false;
        }
        
        if (transform.localEulerAngles.x >= 360)
        {
            Debug.Log("sini");
           
            transform.localEulerAngles = new Vector3(0, 90, 0);
            Debug.Log("Local Euler: "+transform.localEulerAngles);
        }
    }
}
