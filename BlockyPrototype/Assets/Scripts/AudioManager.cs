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
        //if (!audio.isPlaying)
        //{
            audio.PlayOneShot(cubePlacement);
        //}
        
    }

}
