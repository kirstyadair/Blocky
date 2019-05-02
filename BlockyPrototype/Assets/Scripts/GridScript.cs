using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum GridType
{
    WALL, GROUND
}



public class GridScript : MonoBehaviour
{
    GraphicRaycaster raycaster;
    EventSystem eventSystem;
    PointerEventData pointerEventData;

    public List<Transform> gridCells;

    GameObject grid;
    GameObject gridTile;

    public Color selectedColour;
    Color defaultColour;

    GridType gridType;

    public ColourSelectorScript colourSelectorScript;

    public bool graphicalRaycastHit = false;


    
    void Start()
    {
        gridType = GridType.WALL;
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        grid = GameObject.Find("Grid");
        defaultColour = new Color(0, 0, 0, 0.2f);
        selectedColour = defaultColour;
    }


    
    void Update()
    {
        if (gridType == GridType.WALL)
        {
            if (Input.GetButton("Fire1"))
            {
                graphicalRaycastHit = false;
                pointerEventData = new PointerEventData(eventSystem);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                raycaster.Raycast(pointerEventData, results);

                foreach (RaycastResult result in results)
                {
                    graphicalRaycastHit = true;
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
