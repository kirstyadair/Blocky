using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum CubeType
{
    WATER,
    GRASS,
    WOOD,
    FIRE,
    PAVING,
    FLOWER,
    SAND,
    STONE,
    DIRT,
    FENCE,
    FENCECORNER,
    SNOW,
    LANTERN
}



public enum EditingView
{
    INTERIOR, EXTERIOR, GROUND
}



public class PlayerScript : MonoBehaviour
{
    // Variables
    public bool chosenRequirements = false;
    public float opacity;
    public string selectedWallTag;
    public EditingView editView;
    public CubeType cubeType;

    [Header("Animators")]
    public Animator drawingPanelAnim;
    public Animator colourSelectorAnim;
    public Animator cameraAnim;
    public Animator floorDrawingPanelAnim;

    [Header("Scripts")]
    public ColourSelectorScript colourSelectorScript;
    public RequirementsGeneratorScript reqGenScript;
    public GridScript gridScript;
    public FenceIndicatorScript fiScript;

    bool wallSelected;
    Color blankColor;

    [Header("Prefabs")]
    public GameObject waterCubePrefab;
    public GameObject grassPrefab;
    public GameObject woodPrefab;
    public GameObject firePrefab;
    public GameObject pavingPrefab;
    public GameObject flowerPrefab;
    public GameObject sandPrefab;
    public GameObject stonePrefab;
    public GameObject dirtPrefab;
    public GameObject fencePrefab;
    public GameObject fenceCornerPrefab;
    public GameObject snowPrefab;
    public GameObject lanternPrefab;
    GameObject currentCubePrefab;




    void Start()
    {
        drawingPanelAnim.SetBool("openPanel", false);
        colourSelectorAnim.SetBool("show", false);
        floorDrawingPanelAnim.SetBool("slideIn", false);
        AllCamAnimationsFalse();
        wallSelected = false;
        blankColor = new Color(1 / 255, 1 / 255, 1 / 255, 0.2f);
        editView = EditingView.EXTERIOR;
        cubeType = CubeType.GRASS;
    }



    void Update()
    {
        if (cubeType == CubeType.GRASS)
        {
            currentCubePrefab = grassPrefab;
        }
        else if (cubeType == CubeType.WATER)
        {
            currentCubePrefab = waterCubePrefab;
        }
        else if (cubeType == CubeType.WOOD)
        {
            currentCubePrefab = woodPrefab;
        }
        else if (cubeType == CubeType.FIRE)
        {
            currentCubePrefab = firePrefab;
        }
        else if (cubeType == CubeType.PAVING)
        {
            currentCubePrefab = pavingPrefab;
        }
        else if (cubeType == CubeType.FLOWER)
        {
            currentCubePrefab = flowerPrefab;
        }
        else if (cubeType == CubeType.SAND)
        {
            currentCubePrefab = sandPrefab;
        }
        else if (cubeType == CubeType.STONE)
        {
            currentCubePrefab = stonePrefab;
        }
        else if (cubeType == CubeType.DIRT)
        {
            currentCubePrefab = dirtPrefab;
        }
        else if (cubeType == CubeType.FENCE)
        {
            currentCubePrefab = fencePrefab;
        }
        else if (cubeType == CubeType.FENCECORNER)
        {
            currentCubePrefab = fenceCornerPrefab;
        }
        else if (cubeType == CubeType.SNOW)
        {
            currentCubePrefab = snowPrefab;
        }
        else if (cubeType == CubeType.LANTERN)
        {
            currentCubePrefab = lanternPrefab;
        }

        if (chosenRequirements && reqGenScript.canSelectWalls)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (!colourSelectorScript.colourPipetteSelected)
                    {
                        if (!gridScript.graphicalRaycasterHit)
                        {

                            if (hit.collider.gameObject.tag == "BackWall" || hit.collider.gameObject.tag == "FrontWall" || hit.collider.gameObject.tag == "RightWall" || hit.collider.gameObject.tag == "LeftWall")
                            {
                                // if the camera is in birds eye position
                                if (cameraAnim.GetBool("FrontToBirdsEye") || cameraAnim.GetBool("ZoomToBirdsEye"))
                                {
                                    AllCamAnimationsFalse();
                                    cameraAnim.SetBool("BirdsEyeToFront", true);
                                }
                                // else is the camera is zoomed on the room
                                else if (cameraAnim.GetBool("BirdsEyeToZoom"))
                                {
                                    AllCamAnimationsFalse();
                                    cameraAnim.SetBool("ZoomToFront", true);
                                }


                                // if a wall has not already been selected 
                                if (!wallSelected && reqGenScript.canSelectWalls)
                                {
                                    // Find the tag of the cube hit by the raycast
                                    selectedWallTag = hit.transform.gameObject.tag;
                                    // Highlight every cube with this tag
                                    HighlightWall(selectedWallTag);
                                }
                                else if (wallSelected && reqGenScript.canSelectWalls) // if a wall is selected
                                {
                                    // deselect all walls
                                    DeselectWalls();
                                    // Find the tag of the cube hit by the raycast
                                    selectedWallTag = hit.transform.gameObject.tag;
                                    // Highlight every cube with this tag
                                    HighlightWall(selectedWallTag);
                                }

                            }

                            // If hit the grass
                            if (hit.collider.gameObject.tag == "Floor" && hit.collider.gameObject.name != "BlackFloorCube")
                            {
                                DeselectWalls();

                                drawingPanelAnim.SetBool("openPanel", false);
                                if (cameraAnim.GetBool("BirdsEyeToZoom"))
                                {
                                    AllCamAnimationsFalse();
                                    cameraAnim.SetBool("ZoomToBirdsEye", true);
                                }
                                else
                                {
                                    AllCamAnimationsFalse();
                                    cameraAnim.SetBool("FrontToBirdsEye", true);
                                }

                                //Vector3 cubePos = hit.collider.gameObject.transform.position;

                                
                                
                            }

                            if (hit.collider.gameObject.name == "BlackFloorCube")
                            {
                                if (cameraAnim.GetBool("FrontToBirdsEye") || cameraAnim.GetBool("ZoomToBirdsEye"))
                                {
                                    AllCamAnimationsFalse();
                                    cameraAnim.SetBool("BirdsEyeToZoom", true);

                                }

                                drawingPanelAnim.SetBool("openPanel", false);
                            }
                        }
                    }


                }
            }



            // Floor editing
            if (Input.GetButton("Fire1"))
            {
                if (editView == EditingView.GROUND)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "Floor" && hit.collider.gameObject.name != "BlackFloorCube")
                        {
                            StartCoroutine(SpawnInCube(hit));
                            
                        }
                    }
                }
                
            }

            if (Input.GetButton("Fire2"))
            {
                if (editView == EditingView.GROUND)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "Floor" && hit.collider.gameObject.name != "BlackFloorCube")
                        {
                            Vector3 position = hit.collider.transform.position;
                            Destroy(hit.collider.gameObject);
                            GameObject newCube = Instantiate(grassPrefab, position, Quaternion.identity);
                            newCube.tag = "Floor";
                        }
                    }
                }

            }



            // if the current camera animation focuses on the front
            if (cameraAnim.GetBool("BirdsEyeToFront") || cameraAnim.GetBool("ZoomToFront"))
            {
                editView = EditingView.EXTERIOR;
                if (floorDrawingPanelAnim.GetBool("slideIn"))
                {
                    floorDrawingPanelAnim.SetBool("slideIn", false);
                }
                gridScript.mainCamera.orthographic = false;
                gridScript.orthoToggle.isOn = false;

            }
            // else if the current camera animation focuses on the zoom
            else if (cameraAnim.GetBool("BirdsEyeToZoom"))
            {
                editView = EditingView.INTERIOR;
                if (floorDrawingPanelAnim.GetBool("slideIn"))
                {
                    floorDrawingPanelAnim.SetBool("slideIn", false);
                }
                gridScript.mainCamera.orthographic = false;
                gridScript.orthoToggle.isOn = false;
            }
            else if (cameraAnim.GetBool("ZoomToBirdsEye") || cameraAnim.GetBool("FrontToBirdsEye"))
            {
                editView = EditingView.GROUND;
                if (!floorDrawingPanelAnim.GetBool("slideIn"))
                {
                    floorDrawingPanelAnim.SetBool("slideIn", true);
                    cubeType = CubeType.GRASS;
                }
                
            }
        }
        
    }



    void HighlightWall(string wallTag)
    {
        int numberOfCubes = 0;
        if (colourSelectorAnim.GetBool("show") == false)
        {
            drawingPanelAnim.SetBool("openPanel", true);
        }
        
        wallSelected = true;
        // Make an array of cubes with the selected tag
        GameObject[] selectedCubes;
        selectedCubes = GameObject.FindGameObjectsWithTag(wallTag);
        // For each cube with the selected tag, change the colour to red
        foreach(GameObject cube in selectedCubes)
        {
            numberOfCubes++;
            if (numberOfCubes < 11)
            {
                cube.name = "cubeJ" + numberOfCubes.ToString();
            }
            else if (numberOfCubes < 21 && numberOfCubes > 10)
            {
                cube.name = "cubeI" + (numberOfCubes - 10).ToString();
            }
            else if (numberOfCubes < 31 && numberOfCubes > 20)
            {
                cube.name = "cubeH" + (numberOfCubes - 20).ToString();
            }
            else if (numberOfCubes < 41 && numberOfCubes > 30)
            {
                cube.name = "cubeG" + (numberOfCubes - 30).ToString();
            }
            else if (numberOfCubes < 51 && numberOfCubes > 40)
            {
                cube.name = "cubeF" + (numberOfCubes - 40).ToString();
            }
            else if (numberOfCubes < 61 && numberOfCubes > 50)
            {
                cube.name = "cubeE" + (numberOfCubes - 50).ToString();
            }
            else if (numberOfCubes < 71 && numberOfCubes > 60)
            {
                cube.name = "cubeD" + (numberOfCubes - 60).ToString();
            }
            else if (numberOfCubes < 81 && numberOfCubes > 70)
            {
                cube.name = "cubeC" + (numberOfCubes - 70).ToString();
            }
            else if (numberOfCubes < 91 && numberOfCubes > 80)
            {
                cube.name = "cubeB" + (numberOfCubes - 80).ToString();
            }
            else if (numberOfCubes < 101 && numberOfCubes > 90)
            {
                cube.name = "cubeA" + (numberOfCubes - 90).ToString();
            }

            Color selectedColor = cube.GetComponent<Renderer>().material.color;
            selectedColor.a = 0.2f;
            cube.GetComponent<Renderer>().material.color = selectedColor;

            
        }

        foreach (Transform gridCell in gridScript.gridCells)
        {
            GameObject requiredCube = GameObject.Find("cube" + gridCell.gameObject.name);
            Color cubeColour = requiredCube.GetComponent<MeshRenderer>().material.color;
            if (cubeColour != blankColor)
            {
                cubeColour.a = 1;
            }
            requiredCube.GetComponent<MeshRenderer>().material.color = cubeColour;
            gridCell.GetComponent<Image>().color = cubeColour;
        }

    }



    void DeselectWalls()
    {
        drawingPanelAnim.SetBool("openPanel", false);
        wallSelected = false;

        foreach (GameObject cube in reqGenScript.allCubes)
        {
            if (cube != null)
            {
                Color selectedColor = cube.GetComponent<Renderer>().material.color;
                selectedColor.a = opacity;

                cube.GetComponent<Renderer>().material.color = selectedColor;
                cube.name = "not assigned";
            }
            
        }
        
        gridScript.ClearOnlyGrid();
    }



    public void ColourPickerMenuOpen()
    {
        drawingPanelAnim.SetBool("openPanel", false);
        colourSelectorAnim.SetBool("show", true);
        colourSelectorScript.UpdateColour();
    }



    public void ColourPickerMenuClose()
    {
        colourSelectorScript.RGBInput = false;
        drawingPanelAnim.SetBool("openPanel", true);
        colourSelectorAnim.SetBool("show", false);
    }



    public void AllCamAnimationsFalse()
    {
        cameraAnim.SetBool("BirdsEyeToFront", false);
        cameraAnim.SetBool("FrontToBirdsEye", false);
        cameraAnim.SetBool("ZoomToFront", false);
        cameraAnim.SetBool("ZoomToBirdsEye", false);
        cameraAnim.SetBool("BirdsEyeToZoom", false);
    }


    IEnumerator SpawnInCube(RaycastHit hit)
    {
        Vector3 cubePos = hit.collider.gameObject.transform.position;
        if (cubeType != CubeType.WOOD && cubeType != CubeType.FIRE && cubeType!= CubeType.FLOWER  && cubeType != CubeType.STONE && cubeType != CubeType.FENCE && cubeType != CubeType.FENCECORNER && cubeType != CubeType.LANTERN)
        {
            if (cubeType != CubeType.GRASS)
            {
                yield return new WaitForSeconds(0.1f);
            }
            GameObject newCube = Instantiate(currentCubePrefab, cubePos, Quaternion.identity);
            newCube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            newCube.tag = "Floor";
        }

        if (cubeType == CubeType.WOOD || cubeType == CubeType.FIRE || cubeType == CubeType.FLOWER || cubeType == CubeType.STONE || cubeType == CubeType.FENCE || cubeType == CubeType.FENCECORNER || cubeType == CubeType.LANTERN)
        {
            yield return new WaitForSeconds(0.1f);
            if (cubeType == CubeType.FENCE || cubeType == CubeType.FENCECORNER)
            {
                GameObject newCube = Instantiate(currentCubePrefab, new Vector3(cubePos.x, -0.8799995f, cubePos.z), Quaternion.identity);
                newCube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                newCube.transform.Rotate(transform.rotation.x, fiScript.woodRotation, transform.rotation.z);
                newCube.tag = "Floor";
            }
            else
            {
                GameObject newCube = Instantiate(currentCubePrefab, new Vector3(cubePos.x, -0.8799995f, cubePos.z), Quaternion.identity);
                newCube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                newCube.tag = "Floor";
            }
            
            
        }
    }
}
