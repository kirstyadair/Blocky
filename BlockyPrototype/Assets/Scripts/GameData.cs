using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public CubeType blankCubeType;
    public Material terrain;
    public Material grass;
    public Material snow;
    public Material sand;
    public Material dirt;
    public float backgroundAudioLevel = 0.4f;
    public float cubePlacementAudioLevel = 0.4f;




    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }




    // Update is called once per frame
    void Update()
    {
        if (blankCubeType == CubeType.DIRT)
        {
            terrain = dirt;
        }
        else if (blankCubeType == CubeType.SAND)
        {
            terrain = sand;
        }
        else if (blankCubeType == CubeType.SNOW)
        {
            terrain = snow;
        }
        else if (blankCubeType == CubeType.GRASS)
        {
            terrain = grass;
        }
        
    }




    public void BackgroundMusicVolChanged(float value)
    {
        backgroundAudioLevel = value;
        GetComponent<AudioSource>().volume = backgroundAudioLevel;
    }




    public void CubePlacementMusicVolChanged(float value)
    {
        cubePlacementAudioLevel = value;
        // Audio manager uses this value in AudioManager - don't touch it
    }
}
