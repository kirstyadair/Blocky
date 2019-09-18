using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject gameData;
    public Animator canvasAnim;
    public AudioClip backgroundMusic;

    public Material grass;
    public Material snow;
    public Material sand;
    public Material dirt;


    private void Start()
    {
        
        gameData = GameObject.Find("GameData");
        
        if (gameData == null)
        {
            CreateGameData();
            
        }
        
        gameData.GetComponent<GameData>().hasLoaded = false;
        canvasAnim.SetBool("startSandbox", false);
    }



    public void StartSandbox()
    {
        StartCoroutine(DelayStartSandbox());
    }



    public void StartChallenge()
    {
        StartCoroutine(DelayStartChallenge());
    }



    public void TwitterButton()
    {
        Application.OpenURL("https://twitter.com/KirstyAdair2");
    }



    public void MusicButton()
    {
        Application.OpenURL("https://freesound.org/people/Airwolf89/sounds/346454/");
    }



    IEnumerator DelayStartSandbox()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("BlockySandbox");
    }


    IEnumerator DelayStartChallenge()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("ChallengeModeScene");
    }



    public void ChooseTerrain()
    {
        canvasAnim.SetBool("startSandbox", true);
        GetComponent<AudioSource>().Play();
    }



    public void GrassTerrainChosen()
    {
        gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;
        StartSandbox();
    }



    public void SandTerrainChosen()
    {
        gameData.GetComponent<GameData>().blankCubeType = CubeType.SAND;
        StartSandbox();
    }



    public void DirtTerrainChosen()
    {
        gameData.GetComponent<GameData>().blankCubeType = CubeType.DIRT;
        StartSandbox();
    }



    public void SnowTerrainChosen()
    {
        gameData.GetComponent<GameData>().blankCubeType = CubeType.SNOW;
        StartSandbox();
    }



    public void OptionsMenu()
    {
        StartCoroutine(DelayStartOptions());
    }



    IEnumerator DelayStartOptions()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Options");
    }



    public void CreateGameData()
    {
        gameData = new GameObject("GameData");
        gameData.AddComponent<GameData>();
        gameData.AddComponent<AudioSource>();

        gameData.GetComponent<AudioSource>().clip = backgroundMusic;
        gameData.GetComponent<AudioSource>().loop = true;
        gameData.GetComponent<AudioSource>().Play();
        gameData.GetComponent<AudioSource>().volume = gameData.GetComponent<GameData>().backgroundAudioLevel;

        gameData.GetComponent<GameData>().sand = sand;
        gameData.GetComponent<GameData>().snow = snow;
        gameData.GetComponent<GameData>().dirt = dirt;
        gameData.GetComponent<GameData>().grass = grass;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
