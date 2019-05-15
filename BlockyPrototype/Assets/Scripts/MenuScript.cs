using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // Variables
    public PlayerScript playerScript;
    public GameObject terrainPanel;
    public GameObject materialPanel;
    public GameObject backButton;
    public GameObject terrainButton;
    public GameObject materialButton;
    public bool menuOpen = false;
    public bool terrainPanelOpen = false;




    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        if (playerScript.editView == EditingView.GROUND)
        {
            // if a button has not been selected
            if (!menuOpen)
            {
                backButton.SetActive(false);
                terrainButton.SetActive(true);
                materialButton.SetActive(true);
                terrainPanel.SetActive(false);
                materialPanel.SetActive(false);
            }
            
            if (menuOpen)
            {
                backButton.SetActive(true);
                terrainButton.SetActive(false);
                materialButton.SetActive(false);
                if (terrainPanelOpen)
                {
                    terrainPanel.SetActive(true);
                }
                else
                {
                    materialPanel.SetActive(true);
                }
                
            }
        }
    }




    public void BackButtonClicked()
    {
        menuOpen = false;
    }




    public void TerrainButtonClicked()
    {
        terrainPanelOpen = true;
        menuOpen = true;
    }



    public void MaterialButtonClicked()
    {
        terrainPanelOpen = false;
        menuOpen = true;
    }
}
