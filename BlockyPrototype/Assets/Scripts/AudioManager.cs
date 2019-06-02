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

    public AudioSource audio;



    public void PlayCubeSpawn(CubeType cubeType)
    {
        audio.pitch = Random.Range(-2f, 2f);
        audio.volume = 0.4f;

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
        audio.volume = 0.05f;
        audio.PlayOneShot(cubePlacement);
    }

}
