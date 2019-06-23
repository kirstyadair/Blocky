using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    public bool isBlackCube;
    public RestartScript restartScript;
    public int indexInFloorCube;
    GameObject groundPrefab;
    PlayerScript playerScript;
    FloorCubeSpawnerScript spawnerScript;
    public Material dirtMaterial;



    // Start is called before the first frame update
    void Start()
    {
        if (!isBlackCube)
        {
            gameObject.name = "DirtCube";
            //GetComponent<Renderer>().material = dirtMaterial;
        }
        else
        {
            gameObject.name = "BlackFloorCube";
            GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.4f);
        }
        gameObject.tag = "Floor";
        
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();
        spawnerScript = GameObject.Find("FloorCubeSpawner").GetComponent<FloorCubeSpawnerScript>();
        // don't play the audio clip for this cube if this cube is the default cube type
        if (playerScript.blankCubeType != CubeType.DIRT)
        {
            GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.DIRT);
        }
    }




    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;

        if (restartScript.exploding)
        {
            timeActiveExploded += Time.deltaTime;
            if (timeActiveExploded > 10)
            {
                Destroy(this.gameObject);
            }
        }

        if (transform.position.y > -0.95f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.9599f, transform.position.z);
            
        }

        //Debug.Log(indexInFloorCube);
    }



    void OnTriggerEnter(Collider other)
    {
        if (!isBlackCube)
        {
            if (other.name == "DirtCube")
            {
                if (other.GetComponent<DirtCubeScript>().timeActive == timeActive)
                {
                    other.GetComponent<DirtCubeScript>().timeActive += 0.01f;
                }
                
                // if this instance is younger than the other instance, destroy the other instance
                if (timeActive < other.GetComponent<DirtCubeScript>().timeActive)
                {
                    Destroy(other.gameObject);
                }
            }

            if (other.name == "GrassCube")
            {
                if (other.GetComponent<GrassCubeScript>().timeActive > timeActive)
                {
                    indexInFloorCube = other.GetComponent<GrassCubeScript>().indexInFloorCube;
                    spawnerScript.floorCubes[indexInFloorCube] = gameObject.transform;
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

            if (other.name == "PavingCube")
            {
                if (other.GetComponent<PavingCubeScript>().timeActive > timeActive)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

            if (other.name == "WaterCube")
            {
                if (timeActive < other.GetComponent<WaterCubeScript>().timeActive)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

            if (other.name == "SandCube")
            {
                if (timeActive < other.GetComponent<SandCubeScript>().timeActive)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

            if (other.name == "PondWaterCube")
            {
                if (timeActive < other.GetComponent<PondWaterCubeScript>().timeActive)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

            if (other.name == "NuclearCube")
            {
                if (timeActive < other.GetComponent<NuclearCubeScript>().timeActive)
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else if (other.GetComponent<CubeScript>() == null)
        {
            
            Destroy(other.gameObject);
        }
        
    }
}
