using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenuScript : MonoBehaviour
{
    GameData gameData;
    public Slider backgroundSlider;
    public Slider cubeSlider;




    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        backgroundSlider.value = gameData.backgroundAudioLevel;
        cubeSlider.value = gameData.cubePlacementAudioLevel;
    }




    public void BackgroundSliderValue()
    {
        // Update the background music volume held in gameData
        gameData.BackgroundMusicVolChanged(backgroundSlider.value);
    }



    public void CubeSliderValue()
    {
        // Update the background music volume held in gameData
        gameData.CubePlacementMusicVolChanged(cubeSlider.value);
    }




    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
