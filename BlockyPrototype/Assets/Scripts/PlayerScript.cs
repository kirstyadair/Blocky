using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public Animator colourSelectorAnim;
    public Animator cameraAnim;
    public ColourSelectorScript colourSelectorScript;
    public RequirementsGeneratorScript reqGenScript;
    public GridScript gridScript;
    public float opacity;
    Color blankColor;





    void Start()
    {
        drawingPanelAnim.SetBool("openPanel", false);
        colourSelectorAnim.SetBool("show", false);
        cameraAnim.SetBool("birdseye", false);
        wallSelected = false;
        blankColor = new Color(0, 0, 0, 0.2f);
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
                    if (!gridScript.graphicalRaycasterHit)
                    {
                        if (hit.collider.gameObject.tag == "BackWall" || hit.collider.gameObject.tag == "FrontWall" || hit.collider.gameObject.tag == "RightWall" || hit.collider.gameObject.tag == "LeftWall")
                        {
                            cameraAnim.SetBool("birdseye", false);
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

                        if (hit.collider.gameObject.tag == "Floor")
                        {
                            DeselectWalls();
                            drawingPanelAnim.SetBool("openPanel", false);
                            cameraAnim.SetBool("birdseye", true);
                        }
                    }
                    
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
            if (cubeColour != blankColor) cubeColour.a = 1;
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
            Color selectedColor = cube.GetComponent<Renderer>().material.color;
            selectedColor.a = opacity;
            cube.GetComponent<Renderer>().material.color = selectedColor;
            cube.name = "not assigned";
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
        drawingPanelAnim.SetBool("openPanel", true);
        colourSelectorAnim.SetBool("show", false);
    }
}
