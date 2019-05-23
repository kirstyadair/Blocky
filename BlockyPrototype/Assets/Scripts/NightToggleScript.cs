using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightToggleScript : MonoBehaviour
{
    public Light directionalLight;
    public Toggle dayNightToggle;



    // Start is called before the first frame update
    public void OnValChanged()
    {
        if (dayNightToggle.isOn)
        {
            directionalLight.intensity = 0;
        }
        else if (!dayNightToggle.isOn)
        {
            directionalLight.intensity = 0.7f;
        }
    }

}
