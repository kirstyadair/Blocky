using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    public GameObject groundPrefab;
    public GameObject grassPrefab;
    public GameObject dirtPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public RestartScript restartScript;






    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "FenceCube";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.WOOD);
    }




    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;


        if (restartScript.exploding)
        {
            timeActiveExploded += Time.deltaTime;
            if (timeActiveExploded > 3)
            {
                Destroy(this.gameObject);
            }
        }



        if (transform.position.y != -0.8799995f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.8799995f, transform.position.z);
        }



        if (GameObject.Find("PlayerObject").GetComponent<PlayerScript>().blankCubeType == CubeType.DIRT)
        {
            groundPrefab = dirtPrefab;
        }
        else if (GameObject.Find("PlayerObject").GetComponent<PlayerScript>().blankCubeType == CubeType.SAND)
        {
            groundPrefab = sandPrefab;
        }
        else if (GameObject.Find("PlayerObject").GetComponent<PlayerScript>().blankCubeType == CubeType.SNOW)
        {
            groundPrefab = snowPrefab;
        }
        else if (GameObject.Find("PlayerObject").GetComponent<PlayerScript>().blankCubeType == CubeType.GRASS)
        {
            groundPrefab = grassPrefab;
        }
    }




    void OnTriggerEnter(Collider other)
    {
        // if placed on water, replace it with grass
        if (other.name == "WaterCube")
        {
            Vector3 position = other.transform.position;
            Destroy(other.gameObject);
            GameObject newCube = Instantiate(groundPrefab, position, Quaternion.identity);
        }

        // if duplicates are placed, destroy one
        if (other.name == "FenceCube")
        {
            if (other.GetComponent<FenceCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<FenceCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<FenceCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        // if colliding with another cube 
        if (other.name == "FireCube")
        {
            if (timeActive > other.GetComponent<FireCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "WoodCube")
        {
            if (timeActive < other.GetComponent<WoodCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "StoneCube")
        {
            if (timeActive < other.GetComponent<StoneCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "FlowerCube")
        {
            if (timeActive < other.GetComponent<FlowerCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "BurningCube")
        {
            if (timeActive < other.GetComponent<BurningCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "LanternCube")
        {
            if (timeActive < other.GetComponent<LanternCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "Tree")
        {
            if (timeActive < other.GetComponent<TreeCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "LongGrassCube")
        {
            if (timeActive < other.GetComponent<LongGrassCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        
    }
}
