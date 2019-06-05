using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameData gameData;
    public GameObject terrainPanel;
    public Animator terrainAnim;


    private void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
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
        gameData.blankCubeType = CubeType.GRASS;
        StartSandbox();
    }



    public void SandTerrainChosen()
    {
        terrainAnim.SetBool("panelIn", false);
        gameData.blankCubeType = CubeType.SAND;
        StartSandbox();
    }



    public void DirtTerrainChosen()
    {
        terrainAnim.SetBool("panelIn", false);
        gameData.blankCubeType = CubeType.DIRT;
        StartSandbox();
    }



    public void SnowTerrainChosen()
    {
        terrainAnim.SetBool("panelIn", false);
        gameData.blankCubeType = CubeType.SNOW;
        StartSandbox();
    }
}
