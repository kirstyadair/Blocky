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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "BackWall" || hit.collider.gameObject.tag == "FrontWall" || hit.collider.gameObject.tag == "RightWall" || hit.collider.gameObject.tag == "LeftWall")
                    {
                        // if a wall has not already been selected 
                        if (!wallSelected)
                        {
                            // Find the tag of the cube hit by the raycast
                            selectedWallTag = hit.transform.gameObject.tag;
                            // Highlight every cube with this tag
                            HighlightWall(selectedWallTag);
                        }
                        else // if a wall is selected
                        {
                            // deselect all walls
                            DeselectWalls();
                            // Find the tag of the cube hit by the raycast
                            selectedWallTag = hit.transform.gameObject.tag;
                            // Highlight every cube with this tag
                            HighlightWall(selectedWallTag);
                        }
                    }
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
            Color selectedColor = new Color(255, 0, 0);
            cube.GetComponent<Renderer>().material.color = selectedColor;
        }
    }



    void DeselectWalls()
    {
        drawingPanelAnim.SetBool("openPanel", false);
        wallSelected = false;
        GameObject[] allCubes;
        allCubes = GameObject.FindGameObjectsWithTag("BackWall");
        foreach (GameObject cube in allCubes)
        {
            Color selectedColor = new Color(0, 0, 0);
            cube.GetComponent<Renderer>().material.color = selectedColor;
        }
        allCubes = GameObject.FindGameObjectsWithTag("FrontWall");
        foreach (GameObject cube in allCubes)
        {
            Color selectedColor = new Color(0, 0, 0);
            cube.GetComponent<Renderer>().material.color = selectedColor;
        }
        allCubes = GameObject.FindGameObjectsWithTag("LeftWall");
        foreach (GameObject cube in allCubes)
        {
            Color selectedColor = new Color(0, 0, 0);
            cube.GetComponent<Renderer>().material.color = selectedColor;
        }
        allCubes = GameObject.FindGameObjectsWithTag("RightWall");
        foreach (GameObject cube in allCubes)
        {
            Color selectedColor = new Color(0, 0, 0);
            cube.GetComponent<Renderer>().material.color = selectedColor;
        }
    }
}
