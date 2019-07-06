using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCubeScript : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject burningCubePrefab;
    public GameObject dirtPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject grassPrefab;
    public GameObject waterPrefab;
    public RestartScript restartScript;
    PlayerScript playerScript;
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "FireCube";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();
        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.FIRE);

        

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

        if (restartScript.loading)
        {
            Destroy(this.gameObject);
        }

    }




    void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterCube" || other.name == "PondWaterCube")
        {
            Destroy(this.gameObject);
        }

        if (other.name == "FireCube")
        {
            if (other.GetComponent<FireCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<FireCubeScript>().timeActive += 0.01f;
            }

            if (timeActive > other.GetComponent<FireCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }

        }

        

        if (other.name == "WoodCube")
        {
            Vector3 pos = this.transform.position;
            GameObject newcube = Instantiate(burningCubePrefab, pos, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
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

        if (other.name == "TreeCube")
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

        if (other.name == "IceCube")
        {
            GameObject newCube = Instantiate(waterPrefab, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
