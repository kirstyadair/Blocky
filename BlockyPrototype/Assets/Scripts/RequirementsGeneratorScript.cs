using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsGeneratorScript : MonoBehaviour
{
    // Variables
    public PlayerScript playerScript;
    public Animator chooseReqAnim;
    public Animator savedReqAnim;
    public GameObject chooseRequirementsPanel;
    public GameObject requirementsPanel;
    public GameObject cubePrefab;
    public Text requiredFloorsText;
    public Text randomFeatureText;
    public Text floorsText;
    public Text featureText;
    public string[] features;
    public string feature;
    public int requiredFloors;
    public int speed;
    public bool canSelectWalls = false;

    [Header("Cube Spawning")]
    public float spaceBetweenCubes;
    public float timeBetweenSpawning;

    bool panelSlide = false;
    bool requirementsSaved = false;
    



    // Start is called before the first frame update
    void Start()
    {
        playerScript.gameState = GameState.CHOOSEREQUIREMENTS;
        chooseReqAnim.SetBool("panelSlide", false);
        savedReqAnim.SetBool("slideIn", false);
        RandomlyGenerateRequirements();
        requirementsSaved = false;
    }



    void Update()
    {
        if (playerScript.gameState == GameState.CHOSENREQUIREMENTS)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                StartCoroutine(SpawnRoom());
            }
        }
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
            chooseReqAnim.SetBool("panelSlide", true);
            savedReqAnim.SetBool("slideIn", true);
            floorsText.text = "Required floors: " + requiredFloors;
            featureText.text = "Required feature: " + feature;
            StartCoroutine(SpawnRoom());
            playerScript.gameState = GameState.CHOSENREQUIREMENTS;
        }
    }



    IEnumerator SpawnRoom()
    {
        canSelectWalls = false;

        // Spawn the back wall of cubes
        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            spawnedCube.tag = "BackWall";
            spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
            transform.Translate(Vector3.right * spaceBetweenCubes);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }

        // Spawn the right wall of cubes
        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            spawnedCube.tag = "RightWall";
            spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
            transform.Translate(Vector3.back * spaceBetweenCubes);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }

        // Spawn the front wall of cubes
        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            spawnedCube.tag = "FrontWall";
            spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
            transform.Translate(Vector3.left * spaceBetweenCubes);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }

        // Spawn the left wall of cubes
        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            spawnedCube.tag = "LeftWall";
            spawnedCube.GetComponent<CubeScript>().cubeTag = spawnedCube.tag;
            transform.Translate(Vector3.forward * spaceBetweenCubes);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }
        canSelectWalls = true;
    }
}
