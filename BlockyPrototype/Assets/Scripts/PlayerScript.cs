using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    CHOOSEREQUIREMENTS, CHOSENREQUIREMENTS
}



public class PlayerScript : MonoBehaviour
{
    // Variables
    public GameState gameState;
    public string selectedWallTag;
    bool wallSelected;
    public Animator drawingPanelAnim;



    void Start()
    {
        drawingPanelAnim.SetBool("openPanel", false);
        wallSelected = false;
    }



    void Update()
    {
        if (gameState != GameState.CHOOSEREQUIREMENTS)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!wallSelected)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        // Find the tag of the cube hit by the raycast
                        selectedWallTag = hit.transform.gameObject.tag;
                        // Highlight every cube with this tag
                        HighlightWall(selectedWallTag);
                    }
                }
                else
                {
                    DeselectAllWalls();
                }
            }
        }
    }



    void HighlightWall(string wallTag)
    {
        drawingPanelAnim.SetBool("openPanel", true);
        wallSelected = true;
        // Make an array of cubes with the selected tag
        GameObject[] selectedCubes;
        selectedCubes = GameObject.FindGameObjectsWithTag(wallTag);
        // For each cube with the selected tag, change the colour to red
        foreach(GameObject cube in selectedCubes)
        {
            Color selectedColor = new Color(255, 0, 0, 0);
            cube.GetComponent<Renderer>().material.color = selectedColor;
        }
    }



    void DeselectAllWalls()
    {
        drawingPanelAnim.SetBool("openPanel", false);
        wallSelected = false;
        GameObject[] allCubes;
        //allCubes = GameObject.
    }
}
