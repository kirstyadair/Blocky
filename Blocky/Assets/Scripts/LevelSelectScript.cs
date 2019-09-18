using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    GameObject gameData;

    public void Start()
    {
        gameData = GameObject.Find("GameData");
        gameData.GetComponent<GameData>().hasLoaded = false;
        
        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 0; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.NULL;

        }
    }

    public void Level1Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 1; 
            gameData.GetComponent<GameData>().groundChosen = "Grass"; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    

    public void Level2Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 2; 
            gameData.GetComponent<GameData>().groundChosen = "Sand"; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.SAND;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level3Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 3; 
            gameData.GetComponent<GameData>().groundChosen = "Dirt"; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.DIRT;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level4Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 4; 
            gameData.GetComponent<GameData>().groundChosen = "Grass"; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level5Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 5; 
            gameData.GetComponent<GameData>().groundChosen = "Sand"; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.SAND;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level6Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 6; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level7Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 7; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level8Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 8; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level9Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 9; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;

        }
        

        StartCoroutine(DelayLevelLoad());
    }

    public void Level10Selected()
    {
        gameData = GameObject.Find("GameData");

        if (gameData == null)
        {
            GameObject gameData = new GameObject();
            gameData.name = "GameData";
            gameData.AddComponent<GameData>();
        }

        if (gameData != null)
        {
            gameData.GetComponent<GameData>().levelChosen = 10; 
            gameData.GetComponent<GameData>().blankCubeType = CubeType.GRASS;

        }
        

        StartCoroutine(DelayLevelLoad());
    }


    IEnumerator DelayLevelLoad()
    {
        AudioSource aud = GetComponent<AudioSource>();
        aud.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("ChallengeLevel");
    }
}
