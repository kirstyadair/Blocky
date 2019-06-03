using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondWaterCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    public GameObject groundPrefab;
    public GameObject dirtPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject grassPrefab;
    public RestartScript restartScript;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "PondWaterCube";
        gameObject.tag = "Floor";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.WATER);

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

        if (transform.position.y > -0.95f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.9599f, transform.position.z);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PondWaterCube")
        {
            if (other.GetComponent<PondWaterCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<PondWaterCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<PondWaterCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "GrassCube")
        {
            if (other.GetComponent<GrassCubeScript>().timeActive > timeActive)
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
            if (other.GetComponent<WaterCubeScript>().timeActive > timeActive)
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
            if (other.GetComponent<SandCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "FireCube" || other.name == "WoodCube" || other.name == "FlowerCube" || other.name == "BurningCube" || other.name == "StoneCube" || other.name == "TreeCube" || other.name == "LongGrassCube" || other.name == "LanternCube")
        {
            Vector3 position = this.transform.position;
            GameObject newCube = Instantiate(groundPrefab, position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (other.name == "PavingCube")
        {
            if (timeActive < other.GetComponent<PavingCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
