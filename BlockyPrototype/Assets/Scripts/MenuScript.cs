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
    public RestartScript restartScript;
    public RequirementsGeneratorScript reqGenScript;

    public GameObject textField;
    public GameObject button;

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

    public GameObject dotdotMenu;
    

    public bool menuOpen = false;
    public bool dotdotOpen = false;
    public MenuOpen currentOpenMenu;




    // Start is called before the first frame update
    void Start()
    {
        currentOpenMenu = MenuOpen.NONE;
        
        dotdotMenu.SetActive(false);
    }




    // Update is called once per frame
    void Update()
    {
        if (playerScript.editView == EditingView.GROUND)
        {
            // if a button has not been selected
            if (!menuOpen)
            {
                textField.SetActive(true);
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
                textField.SetActive(false);
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

        if (playerScript.savingOrLoading || restartScript.exploding || reqGenScript.loadingPanel.activeInHierarchy)
        {
            button.SetActive(false);
        }
        else
        {
            button.SetActive(true);
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



    public void OpenCloseMenu()
    {
        if (dotdotOpen)
        {
            dotdotMenu.SetActive(false);
            dotdotOpen = false;
        }
        else
        {
            dotdotMenu.SetActive(true);
            dotdotOpen = true;
        }
    }



    public void QuitToMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    


    public void QuitToLevelMenu()
    {
        Application.LoadLevel("ChallengeModeScene");
    }
    
}
