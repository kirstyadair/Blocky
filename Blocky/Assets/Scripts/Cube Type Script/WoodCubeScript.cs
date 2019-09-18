using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCubeScript : MonoBehaviour
{
    public GameObject grassPrefab;
    public GameObject dirtPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject groundPrefab;
    public GameObject burningWoodPrefab;
    public RestartScript restartScript;
    PlayerScript playerScript;
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "WoodCube";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();

        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.WOOD);

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
        if (other.name == "WaterCube")
        {
            Vector3 position = other.transform.position;
            Destroy(other.gameObject);
            GameObject newCube = Instantiate(groundPrefab, position, Quaternion.identity);
        }

        if (other.name == "WoodCube")
        {
            if (other.GetComponent<WoodCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<WoodCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<WoodCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "FireCube")
        {
            Vector3 pos = this.transform.position;
            GameObject newcube = Instantiate(burningWoodPrefab, pos, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.name == "BurningCube")
        {
            Destroy(gameObject);
        }

        if (other.name == "FlowerCube")
        {
            if (timeActive < other.GetComponent<FlowerCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
