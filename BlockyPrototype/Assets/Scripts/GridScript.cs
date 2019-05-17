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

    GameObject grid;
    GameObject gridTile;
    public Camera mainCamera;
    

    public Color selectedColour;
    Color defaultColour;

    public ColourSelectorScript colourSelectorScript;
    public PlayerScript playerScript;

    public bool graphicalRaycasterHit = false;


    
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        grid = GameObject.Find("Grid");
        defaultColour = new Color(1/255, 1/255, 1/255, 0.2f);
        selectedColour = defaultColour;
    }


    
    void Update()
    {
        currentColour.color = selectedColour;

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
                    // If the hit tile is a standard tile within the grid
                    if (result.gameObject.tag == "Tile")
                    {
                        gridTile = result.gameObject;
                        ColourTile(gridTile, selectedColour);

                        if (result.gameObject != null)
                        {
                            GameObject cubeToColour = GameObject.Find("cube" + result.gameObject.name);
                            cubeToColour.GetComponent<MeshRenderer>().material.color = selectedColour;
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
            else
            {
                graphicalRaycasterHit = true;
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.tag == "ColourTile" || result.gameObject.tag == "Tile")
                    {
                        selectedColour = new Color(0,0,0,0);
                        selectedColour = result.gameObject.GetComponent<Image>().color;
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
                    if (result.gameObject.name != "EraserTile" && result.gameObject.name != "WaterTile")
                    {
                        selectedColour = result.gameObject.GetComponent<Image>().color;
                        StartCoroutine(Pulse(result.gameObject));
                    }
                    else if (result.gameObject.name == "EraserTile")
                    {
                        selectedColour = defaultColour;
                    }
                    

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
                }
            }
        }
    }



    void ColourTile(GameObject tile, Color color)
    {
        tile.GetComponent<Image>().color = selectedColour;
    }



    public void ClearGrid()
    {
        foreach (Transform cell in gridCells)
        {
            cell.GetComponent<Image>().color = defaultColour;
            GameObject cubeToColour = GameObject.Find("cube" + cell.gameObject.name);
            cubeToColour.GetComponent<Renderer>().material.color = defaultColour;
        }
    }

    public void ClearOnlyGrid()
    {
        foreach (Transform cell in gridCells)
        {
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
