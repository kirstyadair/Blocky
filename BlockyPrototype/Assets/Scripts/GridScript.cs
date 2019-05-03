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

    GameObject grid;
    GameObject gridTile;

    public Color selectedColour;
    Color defaultColour;

    public ColourSelectorScript colourSelectorScript;

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

                    // If the hit tile is a colour selection tile
                    if (result.gameObject.tag == "ColourTile")
                    {
                        if (result.gameObject.name != "EraserTile")
                        {
                            selectedColour = result.gameObject.GetComponent<Image>().color;
                        }
                        else
                        {
                            selectedColour = defaultColour;
                        }

                    }

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
}
