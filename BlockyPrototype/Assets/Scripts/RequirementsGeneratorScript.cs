using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsGeneratorScript : MonoBehaviour
{
    // Variables
    [Header("Scripts")]
    public PlayerScript playerScript;
    public FloorCubeSpawnerScript floorSpawner;

    [Header("Animators")]
    public Animator chooseReqAnim;
    public Animator savedReqAnim;

    [Header("GameObjects")]
   
    public GameObject chooseRequirementsPanel;
    public GameObject requirementsPanel;
    public GameObject cubePrefab;
    public GameObject loadingPanel;
    public Transform cubesObject;

    [Header("UI")]
    public Text requiredFloorsText;
    public Text randomFeatureText;
    public Text floorsText;
    public Text featureText;
    public Text percentageText;

    [Header("Materials")]
    public Material grass;
    public Material sand;
    public Material dirt;
    public Material snow;
    public Sprite tile;
    public Sprite snowTile;
    public Sprite glassTile;
    public Sprite woodTile;
    public string[] features;
    public string feature;
    public int requiredFloors;
    public int speed;
    public bool canSelectWalls = false;

    [Header("Cube Spawning")]
    public float spaceBetweenCubes;
    public float timeBetweenSpawning;

    public List<GameObject> allCubes;
    public GameData gameData;
    
    bool requirementsSaved = false;
    float percentageLoaded = 0;


    private void Awake()
    {
        allCubes = new List<GameObject>();
    }


    // Start is called before the first frame update
    public void Start()
    {
        loadingPanel.SetActive(false);
        playerScript.chosenRequirements = false;
        //chooseReqAnim.SetBool("panelSlide", false);
        savedReqAnim.SetBool("slideIn", false);
        SaveRequirements();
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        
    }



    void Update()
    {
        percentageLoaded = allCubes.Count / 4;
        percentageText.text = percentageLoaded.ToString() + "%";
    }



    public void RandomlyGenerateRequirements()
    {
        // Randomly generate the number of required floors
        requiredFloors = Mathf.RoundToInt(Random.Range(1, 4));
        requiredFloorsText.text = "The house must have " + requiredFloors + " floors.";

        // Randomly choose a feature from an array
        int randomArrayPos = Mathf.RoundToInt(Random.Range(0, features.Length));
        feature = features[randomArrayPos];
        randomFeatureText.text = "It must also have a " + feature + ".";
    }



    



    



    public void SaveRequirements()
    {
        if (!requirementsSaved)
        {
            requirementsSaved = true;
            //chooseReqAnim.SetBool("panelSlide", true);
            //savedReqAnim.SetBool("slideIn", true);
            floorsText.text = "Required floors: " + requiredFloors;
            featureText.text = "Required feature: " + feature;
            StartCoroutine(SpawnRoom());
            floorSpawner.SpawnPlane(new Vector3(-2.5f, -0.5f, 4), 30, 20);
            playerScript.chosenRequirements = true;
        }
    }



    IEnumerator SpawnRoom()
    {
        loadingPanel.SetActive(true);
        canSelectWalls = false;

        for (int j = 0; j < 10; j++)
        {
            // Spawn the back wall of cubes
            for (int i = 0; i < 10; i++)
            {
                GameObject.Find("AudioObject").GetComponent<AudioManager>().VaryPitch();

                GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
                spawnedCube.transform.SetParent(GameObject.Find("HouseCubeObject").transform);
                spawnedCube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
                spawnedCube.tag = "BackWall";
                allCubes.Add(spawnedCube);
                spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
                transform.Translate(Vector3.right * spaceBetweenCubes);
                yield return new WaitForSeconds(timeBetweenSpawning);
            }

            // Spawn the right wall of cubes
            for (int i = 0; i < 10; i++)
            {
                GameObject.Find("AudioObject").GetComponent<AudioManager>().VaryPitch();

                GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
                spawnedCube.transform.SetParent(GameObject.Find("HouseCubeObject").transform);
                spawnedCube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
                spawnedCube.tag = "RightWall";
                allCubes.Add(spawnedCube);
                spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
                transform.Translate(Vector3.back * spaceBetweenCubes);
                yield return new WaitForSeconds(timeBetweenSpawning);
            }

            // Spawn the front wall of cubes
            for (int i = 0; i < 10; i++)
            {
                GameObject.Find("AudioObject").GetComponent<AudioManager>().VaryPitch();

                GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
                spawnedCube.transform.SetParent(GameObject.Find("HouseCubeObject").transform);
                spawnedCube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
                spawnedCube.tag = "FrontWall";
                allCubes.Add(spawnedCube);
                spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
                transform.Translate(Vector3.left * spaceBetweenCubes);
                yield return new WaitForSeconds(timeBetweenSpawning);
            }

            // Spawn the left wall of cubes
            for (int i = 0; i < 10; i++)
            {
                GameObject.Find("AudioObject").GetComponent<AudioManager>().VaryPitch();

                GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
                spawnedCube.transform.SetParent(GameObject.Find("HouseCubeObject").transform);
                spawnedCube.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
                spawnedCube.tag = "LeftWall";
                allCubes.Add(spawnedCube);
                spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
                transform.Translate(Vector3.forward * spaceBetweenCubes);
                yield return new WaitForSeconds(timeBetweenSpawning);
            }
        }
        
        canSelectWalls = true;
        loadingPanel.SetActive(false);
    }



    public void FillWall()
    {
        GridScript gridScript = GameObject.Find("Canvas").GetComponent<GridScript>();
        foreach (GameObject cube in allCubes)
        {
            // only fill the cubes in one wall
            if (cube.gameObject.tag == playerScript.selectedWallTag)
            {
                Color colour = gridScript.selectedColour;
                
                if (gridScript.selectedMaterial == CubeMaterial.GLASS)
                {
                    colour = Color.white;
                }
                else if (gridScript.selectedMaterial == CubeMaterial.SNOW)
                {
                    colour = Color.white;
                    Material material = cube.GetComponent<CubeScript>().snowMaterial;
                    cube.GetComponent<Renderer>().material = material;
                }
                else if (gridScript.selectedMaterial == CubeMaterial.WOOD)
                {
                    Material material = cube.GetComponent<CubeScript>().woodMaterial;
                    cube.GetComponent<Renderer>().material = material;
                }
                cube.GetComponent<Renderer>().material.color = colour;
                
                foreach (Transform cell in gridScript.gridCells)
                {
                    if ("cube" + cell.gameObject.name == cube.gameObject.name)
                    {
                        if (cube.gameObject.GetComponent<CubeScript>().cubeMaterial != gridScript.selectedMaterial)
                        {
                            cube.gameObject.GetComponent<CubeScript>().cubeMaterial = gridScript.selectedMaterial;
                        }


                        if (gridScript.selectedMaterial == CubeMaterial.SNOW)
                        {
                            cell.GetComponent<Image>().color = Color.white;
                            cell.GetComponent<Image>().sprite = snowTile;
                        }
                        else if (gridScript.selectedMaterial == CubeMaterial.STANDARD)
                        {
                            cell.GetComponent<Image>().color = gridScript.selectedColour;
                            cell.GetComponent<Image>().sprite = tile;
                        }
                        else if (gridScript.selectedMaterial == CubeMaterial.GLASS)
                        {
                            cell.GetComponent<Image>().color = new Color(0.8f, 1, 1, 1);
                            cell.GetComponent<Image>().sprite = glassTile;
                        }
                        else if (gridScript.selectedMaterial == CubeMaterial.WOOD)
                        {
                            cell.GetComponent<Image>().color = gridScript.selectedColour;
                            cell.GetComponent<Image>().sprite = woodTile;
                        }



                    }
                }
            }
        }
    }
}
