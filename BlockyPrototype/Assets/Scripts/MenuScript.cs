using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MenuOpen
{
    PATHS, WATER, NATURAL, PLANTS, FENCES, LIGHTS, NONE
}

public class MenuScript : MonoBehaviour
{
    // Variables
    public PlayerScript playerScript;

    public GameObject pathsPanel;
    public GameObject waterPanel;
    public GameObject naturalPanel;
    public GameObject plantsPanel;
    public GameObject fencesPanel;
    public GameObject lightsPanel;

    public GameObject backButton;
    public GameObject pathsButton;
    public GameObject waterButton;
    public GameObject naturalButton;
    public GameObject fencesButton;
    public GameObject plantsButton;
    public GameObject lightsButton;

    

    public bool menuOpen = false;
    public MenuOpen currentOpenMenu;




    // Start is called before the first frame update
    void Start()
    {
        currentOpenMenu = MenuOpen.NONE;
        

    }




    // Update is called once per frame
    void Update()
    {
        if (playerScript.editView == EditingView.GROUND)
        {
            // if a button has not been selected
            if (!menuOpen)
            {
                currentOpenMenu = MenuOpen.NONE;
                backButton.SetActive(false);
                pathsButton.SetActive(true);
                waterButton.SetActive(true);
                naturalButton.SetActive(true);
                plantsButton.SetActive(true);
                fencesButton.SetActive(true);
                lightsButton.SetActive(true);

                pathsPanel.SetActive(false);
                waterPanel.SetActive(false);
                naturalPanel.SetActive(false);
                plantsPanel.SetActive(false);
                fencesPanel.SetActive(false);
                lightsPanel.SetActive(false);
            }
            
            if (menuOpen)
            {
                backButton.SetActive(true);
                pathsButton.SetActive(false);
                waterButton.SetActive(false);
                naturalButton.SetActive(false);
                plantsButton.SetActive(false);
                fencesButton.SetActive(false);
                lightsButton.SetActive(false);

                if (currentOpenMenu == MenuOpen.PATHS)
                {
                    pathsPanel.SetActive(true);
                }
                else if (currentOpenMenu == MenuOpen.NATURAL)
                {
                    naturalPanel.SetActive(true);
                }
                else if (currentOpenMenu == MenuOpen.PLANTS)
                {
                    plantsPanel.SetActive(true);
                }
                else if (currentOpenMenu == MenuOpen.FENCES)
                {
                    fencesPanel.SetActive(true);
                }
                else if (currentOpenMenu == MenuOpen.WATER)
                {
                    waterPanel.SetActive(true);
                }
                else
                {
                    lightsPanel.SetActive(true);
                }
                
            }
        }
    }




    public void BackButtonClicked()
    {
        menuOpen = false;
    }




    public void PathsButtonClicked()
    {
        currentOpenMenu = MenuOpen.PATHS;
        menuOpen = true;
    }



    public void WaterButtonClicked()
    {
        currentOpenMenu = MenuOpen.WATER;
        menuOpen = true;
    }



    public void NaturalButtonClicked()
    {
        currentOpenMenu = MenuOpen.NATURAL;
        menuOpen = true;
    }



    public void PlantsButtonClicked()
    {
        currentOpenMenu = MenuOpen.PLANTS;
        menuOpen = true;
    }



    public void FencesButtonClicked()
    {
        currentOpenMenu = MenuOpen.FENCES;
        menuOpen = true;
    }



    public void LightsButtonClicked()
    {
        currentOpenMenu = MenuOpen.LIGHTS;
        menuOpen = true;
    }



    
}
