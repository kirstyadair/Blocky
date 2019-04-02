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
    List<GameObject> gridCells;

    GameObject grid;
    GameObject gridTile;


    
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        gridCells = new List<GameObject>();
        grid = GameObject.Find("Grid");
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
                if (result.gameObject.tag == "Tile")
                {
                    Debug.Log(result.gameObject.name);
                    gridTile = result.gameObject;
                    SelectTile(gridTile);
                }
            }
        }
    }



    void SelectTile(GameObject tile)
    {
        Color newColor = new Color(255, 255, 0);
        tile.GetComponent<Image>().color = newColor;
    }
}
