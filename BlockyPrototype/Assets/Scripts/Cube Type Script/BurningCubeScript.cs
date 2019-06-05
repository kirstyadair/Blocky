using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningCubeScript : MonoBehaviour
{
    Animator anim;
    public RestartScript restartScript;
    PlayerScript playerScript;
    public GameObject groundPrefab;
    public GameObject dirtPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject grassPrefab;
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();
        gameObject.name = "BurningCube";
        gameObject.tag = "Floor";


        if (playerScript.blankCubeType == CubeType.DIRT)
        {
            groundPrefab = dirtPrefab;
        }
        else if (playerScript.blankCubeType == CubeType.SAND)
        {
            groundPrefab = sandPrefab;
        }
        else if (playerScript.blankCubeType == CubeType.SNOW)
        {
            groundPrefab = snowPrefab;
        }
        else if (playerScript.blankCubeType == CubeType.GRASS)
        {
            groundPrefab = grassPrefab;
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

        
        if (transform.position.y != -0.8799995f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.8799995f, transform.position.z);
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
        if (other.name == "BurningCube")
        {
            if (timeActive == other.GetComponent<BurningCubeScript>().timeActive)
            {
                timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<BurningCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        // if colliding with another cube 
        if (other.name == "WoodCube" || other.name == "FireCube")
        {
            Destroy(other.gameObject);
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

        if (other.name == "FenceCube")
        {
            if (timeActive < other.GetComponent<FenceCubeScript>().timeActive)
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
