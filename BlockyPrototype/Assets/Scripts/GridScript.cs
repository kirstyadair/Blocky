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

    GameObject grid;
    GameObject gridTile;

    Color selectedColour;
    Color defaultColour;


    
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        grid = GameObject.Find("Grid");
        defaultColour = new Color(1, 1, 1);
        selectedColour = defaultColour;
    }


    
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
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
                    gridTile = result.gameObject;
                    ColourTile(gridTile, selectedColour);
                }

                // If the hit tile is a colour selection tile
                if (result.gameObject.tag == "ColourTile")
                {
                    selectedColour = result.gameObject.GetComponent<Image>().color;
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
        }
    }
}
