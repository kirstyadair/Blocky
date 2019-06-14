using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip waterClip;
    public AudioClip fireClip;
    public AudioClip woodClip;
    public AudioClip pavingClip;
    public AudioClip flowerClip;
    public AudioClip cubePlacement;
    public AudioClip stoneClip;
    public AudioClip treeClip;
    public AudioClip grassClip;
    public AudioClip sandClip;
    public AudioClip snowClip;
    public AudioClip lanternClip;
    public AudioClip dirtClip;
    public AudioClip lilypadClip;

    public AudioSource audio;



    public void PlayCubeSpawn(CubeType cubeType)
    {
        if (cubeType != CubeType.NUCLEAR)
        {
            audio.pitch = Random.Range(-2f, 1f);
        }
        else
        {
            audio.pitch = Random.Range(1.5f, 3f);
        }

        audio.volume = GameObject.Find("GameData").GetComponent<GameData>().cubePlacementAudioLevel;


        if (cubeType == CubeType.FIRE)
        {
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(fireClip);
            }
            
        }

        if (cubeType == CubeType.WOOD)
        {
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(woodClip);
            }
        }

        if (cubeType == CubeType.PAVING)
        {
            audio.PlayOneShot(pavingClip);
        }

        if (cubeType == CubeType.WATER)
        {
            audio.PlayOneShot(waterClip);
        }

        if (cubeType == CubeType.STONE)
        {
            audio.PlayOneShot(stoneClip);
        }

        if (cubeType == CubeType.TREE)
        {
            audio.PlayOneShot(treeClip);
        }

        if (cubeType == CubeType.LONGGRASS)
        {
            audio.PlayOneShot(grassClip);
        }

        if (cubeType == CubeType.SAND)
        {
            audio.PlayOneShot(sandClip);
        }

        if (cubeType == CubeType.SNOW)
        {
            audio.PlayOneShot(snowClip);
        }

        if (cubeType == CubeType.LANTERN)
        {
            audio.PlayOneShot(lanternClip);
        }

        if (cubeType == CubeType.DIRT)
        {
            audio.PlayOneShot(dirtClip);
        }

        if (cubeType == CubeType.LILYPAD)
        {
            audio.PlayOneShot(lilypadClip);
        }

        if (cubeType == CubeType.NUCLEAR)
        {
            audio.PlayOneShot(waterClip);
        }

        if (cubeType == CubeType.FLOWER)
        {
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(flowerClip);
            }
        }

    }




    public void VaryPitch()
    {
        audio.pitch = Random.Range(0.5f, 1.5f);
        audio.volume = GameObject.Find("GameData").GetComponent<GameData>().cubePlacementAudioLevel / 4;
        audio.PlayOneShot(cubePlacement);
    }

}
