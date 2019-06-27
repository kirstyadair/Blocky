using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    bool hasLilypad = false;
    bool transitioning = false;
    public GameObject groundPrefab;
    public GameObject dirtPrefab;
    public GameObject sandPrefab;
    public GameObject snowPrefab;
    public GameObject grassPrefab;
    public Material nuclear1;
    public Material nuclear2;
    public Material nuclear3;
    public Material nuclear4;
    public Material nuclearOuter;
    public RestartScript restartScript;
    PlayerScript playerScript;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "WaterCube";
        gameObject.tag = "Floor";

        
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();

        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.WATER);

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

        if (transform.position.y > -0.95f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.9599f, transform.position.z);
        }


        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
        foreach (Collider col in colliders)
        {
            if (col.name == "NuclearCube")
            {
                
                if (!transitioning)
                {
                    Renderer[] innerCubes = gameObject.GetComponentsInChildren<Renderer>();
                    StartCoroutine(NuclearCubeTransition(innerCubes));
                }
                
            }
        }


        if (restartScript.loading)
        {
            SaveToXMLScript saveScript = GameObject.Find("SaveObject").GetComponent<SaveToXMLScript>();
            if (saveScript.readBlankCubeType == "GRASS")
            {
                GameObject newCube = Instantiate(grassPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (saveScript.readBlankCubeType == "SNOW")
            {
                GameObject newCube = Instantiate(snowPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (saveScript.readBlankCubeType == "SAND")
            {
                GameObject newCube = Instantiate(sandPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            if (saveScript.readBlankCubeType == "DIRT")
            {
                GameObject newCube = Instantiate(dirtPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterCube")
        {
            if (other.GetComponent<WaterCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<WaterCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<WaterCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "PondWaterCube")
        {
            if (other.GetComponent<PondWaterCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "GrassCube")
        {
            if (other.GetComponent<GrassCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            if (other.GetComponent<GrassCubeScript>().timeActive == timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "SandCube")
        {
            if (other.GetComponent<SandCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }

            if (other.GetComponent<SandCubeScript>().timeActive == timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "DirtCube")
        {
            if (other.GetComponent<DirtCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            if (other.GetComponent<DirtCubeScript>().timeActive == timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "SnowCube")
        {
            if (other.GetComponent<SnowCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }

            if (other.GetComponent<SnowCubeScript>().timeActive == timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "WoodCube" || other.name == "FlowerCube" || other.name == "BurningCube" || other.name == "StoneCube" || other.name == "TreeCube" || other.name == "LongGrassCube" || other.name == "LanternCube")
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

        if (other.name == "LilypadCube")
        {
            hasLilypad = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "LilypadCube")
        {
            Destroy(this.gameObject);
        }
    }



    IEnumerator NuclearCubeTransition(Renderer[] innerCubes)
    {
        transitioning = true;

        for (int i = 1; i < innerCubes.Length; i++)
        {
            int materialNo = Mathf.RoundToInt(Random.Range(0, 3));
            Material mat;
            switch (materialNo)
            {
                case 0:
                    mat = nuclear1;
                    break;
                case 1:
                    mat = nuclear2;
                    break;
                case 2:
                    mat = nuclear3;
                    break;
                case 3:
                    mat = nuclear4;
                    break;
                default:
                    mat = nuclear1;
                    break;
            }

            innerCubes[i].material = mat;
            yield return new WaitForSeconds(0.5f);
        }

        innerCubes[0].material = nuclearOuter;
        
        innerCubes[0].gameObject.AddComponent<NuclearCubeScript>();
        innerCubes[0].gameObject.GetComponent<NuclearCubeScript>().dirtPrefab = dirtPrefab;
        innerCubes[0].gameObject.GetComponent<NuclearCubeScript>().sandPrefab = sandPrefab;
        innerCubes[0].gameObject.GetComponent<NuclearCubeScript>().snowPrefab = snowPrefab;
        innerCubes[0].gameObject.GetComponent<NuclearCubeScript>().grassPrefab = grassPrefab;
        innerCubes[0].gameObject.GetComponent<NuclearCubeScript>().groundPrefab = groundPrefab;

        Destroy(this);

    }
}
