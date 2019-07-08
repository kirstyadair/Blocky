﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    GameObject gameData;

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