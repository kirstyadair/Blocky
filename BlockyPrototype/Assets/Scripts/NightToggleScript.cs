using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightToggleScript : MonoBehaviour
{
    public Light directionalLight;
    public Toggle dayNightToggle;
    public Material nightSky;
    public Material daySky;



    // Start is called before the first frame update
    public void OnValChanged()
    {
        if (dayNightToggle.isOn)
        {
            directionalLight.intensity = 0.2f;
            directionalLight.color = new Color(0.5f, 0.5f, 1, 1);
            RenderSettings.skybox = nightSky;
            
        }
        else if (!dayNightToggle.isOn)
        {
            directionalLight.intensity = 0.4f;
            directionalLight.color = new Color(1, 0.9f, 0.9f, 1);
            RenderSettings.skybox = daySky;
        }
    }

}
