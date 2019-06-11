using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class GridScript : MonoBehaviour
{
    GraphicRaycaster raycaster;
    EventSystem eventSystem;
    PointerEventData pointerEventData;

    public List<Transform> gridCells;

    public Image currentColour;
    public Toggle orthoToggle;

    public Sprite standardSprite;
    public Sprite snowSprite;
    public Sprite glassSprite;
    public Sprite woodSprite;

    GameObject grid;
    GameObject gridTile;
    public GameObject colourPopup;
    public Camera mainCamera;
    

    public Color selectedColour;
    public CubeMaterial selectedMaterial;
    Color defaultColour;
    public Dropdown dropdown;

    public ColourSelectorScript colourSelectorScript;
    public PlayerScript playerScript;

    public bool graphicalRaycasterHit = false;
    bool hitDropdown = false;


    
    public void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        grid = GameObject.Find("Grid");
        defaultColour = new Color(1/255, 1/255, 1/255, 0.2f);
        selectedColour = defaultColour;
    }


    
    void Update()
    {
        Color currentColourIndicator = selectedColour;
        currentColourIndicator.a = 1;
        currentColour.color = currentColourIndicator;
        
        if (selectedMaterial != CubeMaterial.STANDARD && selectedMaterial != CubeMaterial.WOOD)
        {
            currentColourIndicator = Color.white;
            currentColour.color = currentColourIndicator;
        }


        // don't change this to get button down. that's further down.
        if (Input.GetButton("Fire1"))
        {
            graphicalRaycasterHit = false;
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);

            if (!colourSelectorScript.colourPipetteSelected)
            {
                foreach (RaycastResult result in results)
                {
                    graphicalRaycasterHit = true;
                   


                    if (result.gameObject.tag == "Tile")
                    {
                        gridTile = result.gameObject;
                        ColourTile(gridTile, selectedColour);

                        if (result.gameObject != null)
                        {
                            GameObject cubeToColour = GameObject.Find("cube" + result.gameObject.name);
                            if (selectedMaterial == CubeMaterial.STANDARD)
                            {
                                
                                cubeToColour.GetComponent<MeshRenderer>().material.color = selectedColour;
                                gridTile.GetComponent<Image>().sprite = standardSprite;
                            }
                            else if (selectedMaterial == CubeMaterial.GLASS)
                            {
                                cubeToColour.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 0.1f);
                                cubeToColour.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.GLASS;
                                selectedColour = new Color(0.8f, 1, 1, 1);
                                gridTile.GetComponent<Image>().sprite = glassSprite;
                            }
                            else if (selectedMaterial == CubeMaterial.SNOW)
                            {
                                cubeToColour.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.SNOW;
                                selectedColour = Color.white;
                                gridTile.GetComponent<Image>().sprite = snowSprite;
                            }
                            else if (selectedMaterial == CubeMaterial.WOOD)
                            {
                                cubeToColour.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.WOOD;
                                cubeToColour.GetComponent<MeshRenderer>().material = cubeToColour.GetComponent<CubeScript>().woodMaterial;
                                cubeToColour.GetComponent<MeshRenderer>().material.color = selectedColour;
                                gridTile.GetComponent<Image>().sprite = woodSprite;
                            }

                        }
                        else
                        {
                            Debug.Log("No gameobject");
                        }

                    }
                    
                    // The colour tile stuff is in GetButtonDown

                    if (result.gameObject.name == "SliderPanel")
                    {
                        colourSelectorScript.RGBInput = false;
                    }

                    if (result.gameObject.name == "RGBPanel")
                    {
                        colourSelectorScript.RGBInput = true;
                    }
                }
            }
            else // if the colour dropper is selected
            {
                graphicalRaycasterHit = true;
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.tag == "ColourTile" || result.gameObject.tag == "Tile" || result.gameObject.tag == "MaterialColourTile")
                    {
                        if (result.gameObject.tag == "Tile")
                        {
                            GameObject cubeToColour = GameObject.Find("cube" + result.gameObject.name);
                            if (cubeToColour.GetComponent<CubeScript>().cubeMaterial == CubeMaterial.STANDARD)
                            {
                                selectedColour = new Color(0, 0, 0, 0);
                                selectedColour = result.gameObject.GetComponent<Image>().color;
                                selectedMaterial = CubeMaterial.STANDARD;
                            }
                            else if (cubeToColour.GetComponent<CubeScript>().cubeMaterial == CubeMaterial.GLASS)
                            {
                                selectedColour = new Color(0.8f, 1, 1, 1);
                                selectedMaterial = CubeMaterial.GLASS;
                            }
                            else if (cubeToColour.GetComponent<CubeScript>().cubeMaterial == CubeMaterial.SNOW)
                            {
                                selectedColour = new Color(1, 1, 1, 1f);
                                selectedMaterial = CubeMaterial.SNOW;
                            }
                            else if (cubeToColour.GetComponent<CubeScript>().cubeMaterial == CubeMaterial.WOOD)
                            {
                                selectedColour = result.gameObject.GetComponent<Image>().color;
                                selectedMaterial = CubeMaterial.WOOD;
                            }
                        }
                        else if (result.gameObject.tag == "ColourTile")
                        {
                            selectedColour = new Color(0, 0, 0, 0);
                            selectedColour = result.gameObject.GetComponent<Image>().color;
                            selectedMaterial = CubeMaterial.STANDARD;
                        }
                        else if (result.gameObject.tag == "MaterialColourTile")
                        {
                            selectedColour = new Color(0, 0, 0, 0);
                            selectedColour = result.gameObject.GetComponent<Image>().color;
                        }
                        
                    }

                }

                colourSelectorScript.colourPipetteSelected = false;
            }
            
        }

        if (Input.GetButton("Fire2"))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                // If the hit tile is a standard tile within the grid
                if (result.gameObject.tag == "Tile")
                {
                    result.gameObject.GetComponent<Image>().color = defaultColour;
                    GameObject cubeToColour = GameObject.Find("cube" + result.gameObject.name);
                    cubeToColour.GetComponent<MeshRenderer>().material.color = defaultColour;
                    cubeToColour.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            raycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                // If the hit tile is a colour selection tile
                if (result.gameObject.tag == "ColourTile")
                {
                    if (result.gameObject.name != "EraserTile")
                    {
                        selectedMaterial = CubeMaterial.STANDARD;
                        selectedColour = result.gameObject.GetComponent<Image>().color;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    else if (result.gameObject.name == "EraserTile")
                    {
                        selectedMaterial = CubeMaterial.STANDARD;
                        selectedColour = defaultColour;
                    }
                    
                }
                else if (result.gameObject.tag == "MaterialTile")
                {
                    if (result.gameObject.name == "GlassTile")
                    {
                        selectedMaterial = CubeMaterial.GLASS;
                        StartCoroutine(Pulse(result.gameObject));
                        colourPopup.SetActive(false);
                    }
                    if (result.gameObject.name == "SnowTile")
                    {
                        selectedMaterial = CubeMaterial.SNOW;
                        StartCoroutine(Pulse(result.gameObject));
                        colourPopup.SetActive(false);
                    }
                    if (result.gameObject.name == "WoodTile")
                    {
                        selectedMaterial = CubeMaterial.WOOD;
                        StartCoroutine(Pulse(result.gameObject));
                        colourPopup.SetActive(true);
                    }
                }
                else if (result.gameObject.tag == "MaterialColourTile")
                {
                    selectedColour = result.gameObject.GetComponent<Image>().color;
                    StartCoroutine(Pulse(result.gameObject));
                }


                else if (result.gameObject.tag == "FloorTile")
                {
                    if (result.gameObject.name == "WaterTile")
                    {
                        playerScript.cubeType = CubeType.WATER;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "GrassTile")
                    {
                        playerScript.cubeType = CubeType.GRASS;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "WoodTile")
                    {
                        playerScript.cubeType = CubeType.WOOD;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "FireTile")
                    {
                        playerScript.cubeType = CubeType.FIRE;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "PavingTile")
                    {
                        playerScript.cubeType = CubeType.PAVING;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "FlowerTile")
                    {
                        playerScript.cubeType = CubeType.FLOWER;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "SandTile")
                    {
                        playerScript.cubeType = CubeType.SAND;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "StoneTile")
                    {
                        playerScript.cubeType = CubeType.STONE;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "DirtTile")
                    {
                        playerScript.cubeType = CubeType.DIRT;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "FenceTile")
                    {
                        playerScript.cubeType = CubeType.FENCE;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "FenceCornerTile")
                    {
                        playerScript.cubeType = CubeType.FENCECORNER;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "SnowTile")
                    {
                        playerScript.cubeType = CubeType.SNOW;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "LanternTile")
                    {
                        playerScript.cubeType = CubeType.LANTERN;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "TreeTile")
                    {
                        playerScript.cubeType = CubeType.TREE;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "LongGrassTile")
                    {
                        playerScript.cubeType = CubeType.LONGGRASS;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "PondWaterTile")
                    {
                        playerScript.cubeType = CubeType.PONDWATER;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "NuclearTile")
                    {
                        playerScript.cubeType = CubeType.NUCLEAR;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "LilypadTile")
                    {
                        playerScript.cubeType = CubeType.LILYPAD;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "LavaTile")
                    {
                        playerScript.cubeType = CubeType.LAVA;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    if (result.gameObject.name == "LamppostTile")
                    {
                        playerScript.cubeType = CubeType.LAMPPOST;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                }
            }
        }
    }



    void ColourTile(GameObject tile, Color color)
    {
        GameObject cubeToColour = GameObject.Find("cube" + tile.name);
        if (cubeToColour.GetComponent<CubeScript>().cubeMaterial != CubeMaterial.STANDARD && selectedMaterial == CubeMaterial.STANDARD)
        {
            Debug.Log("not standard material, changing");
            cubeToColour.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
            cubeToColour.GetComponent<Renderer>().material = cubeToColour.GetComponent<CubeScript>().standardMaterial;
        }
        tile.GetComponent<Image>().color = selectedColour;
    }


    public void ClearGrid()
    {
        foreach (Transform cell in gridCells)
        {
            cell.GetComponent<Image>().color = defaultColour;
            GameObject cubeToColour = GameObject.Find("cube" + cell.gameObject.name);
            if (cubeToColour.GetComponent<CubeScript>().cubeMaterial != CubeMaterial.STANDARD) cubeToColour.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
            cubeToColour.GetComponent<Renderer>().material = cubeToColour.GetComponent<CubeScript>().standardMaterial;
            cubeToColour.GetComponent<Renderer>().material.color = defaultColour;
        }
    }



    public void ClearOnlyGrid()
    {
        foreach (Transform cell in gridCells)
        {
            GameObject cubeToColour = GameObject.Find("cube" + cell.gameObject.name);
            if (cubeToColour != null)
            {
                if (cubeToColour.GetComponent<CubeScript>().cubeMaterial != CubeMaterial.STANDARD)
                {
                    cubeToColour.GetComponent<CubeScript>().cubeMaterial = CubeMaterial.STANDARD;
                    cell.GetComponent<Image>().sprite = standardSprite;
                }
            }
            cell.GetComponent<Image>().color = defaultColour;
        }
    }

    public void ToggleOrthographicCamera()
    {
        if (orthoToggle.isOn)
        {
            mainCamera.orthographic = true;
            mainCamera.orthographicSize = 1.2f;
        }
        else
        {
            mainCamera.orthographic = false;
        }
    }


    

    IEnumerator Pulse(GameObject tile)
    {
        while (tile.transform.localScale.x < 1.5)
        {
            tile.transform.localScale = new Vector2(tile.transform.localScale.x + 0.1f, tile.transform.localScale.y + 0.1f);
            yield return new WaitForSeconds(0.01f);
        }

        while (tile.transform.localScale.x > 1)
        {
            tile.transform.localScale = new Vector2(tile.transform.localScale.x - 0.1f, tile.transform.localScale.y - 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    
}
