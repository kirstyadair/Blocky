using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject gameData;
    public GameObject terrainPanel;
    public Animator terrainAnim;
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
    }



    public void StartSandbox()
    {
        StartCoroutine(DelayStartSandbox());
    }



    IEnumerator DelayStartSandbox()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("BlockySandbox");
    }



    public void ChooseTerrain()
    {
        terrainPanel.SetActive(true);
        terrainAnim.SetBool("panelIn", true);
        GetComponent<AudioSource>().Play();
    }



    public void GrassTerrainChosen()
    {
        terrainAnim.SetBool("panelIn", false);
        gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;
        StartSandbox();
    }



    public void SandTerrainChosen()
    {
        terrainAnim.SetBool("panelIn", false);
        gameData.GetComponent<GameData>().blankCubeType = CubeType.SAND;
        StartSandbox();
    }



    public void DirtTerrainChosen()
    {
        terrainAnim.SetBool("panelIn", false);
        gameData.GetComponent<GameData>().blankCubeType = CubeType.DIRT;
        StartSandbox();
    }



    public void SnowTerrainChosen()
    {
        terrainAnim.SetBool("panelIn", false);
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
}
