using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    public Image colourIndicator;
    public Sprite glassIndicator;
    public Sprite tileIndicator;
    public Sprite woodIndicator;
    public GameObject fillButton;
    public GameObject colourSelectorButton;
    public Dropdown dropDown;
    public GameObject paintToolbar;
    public GameObject materialsToolbar;
    public GridScript gridScript;




    // Start is called before the first frame update
    void Start()
    {
        // for dropdown stuff
        paintToolbar.SetActive(true);
        materialsToolbar.SetActive(false);
    }





    // Update is called once per frame
    void Update()
    {
        if (dropDown.value == 1)
        {
            //fillButton.SetActive(false);
            colourSelectorButton.SetActive(false);
        }
        else
        {
            fillButton.SetActive(true);
            colourSelectorButton.SetActive(true);
            gridScript.colourPopup.SetActive(false);
        }

        if (gridScript.selectedMaterial == CubeMaterial.GLASS)
        {
            colourIndicator.sprite = glassIndicator;
            colourIndicator.color = new Color(1, 1, 1, 1);
        }
        else if (gridScript.selectedMaterial == CubeMaterial.WOOD)
        {
            colourIndicator.sprite = woodIndicator;
            colourIndicator.color = gridScript.selectedColour;
        }
        else
        {
            colourIndicator.sprite = tileIndicator;
        }
    }





    public void OnValChangedDropdown()
    {
        if (dropDown.value == 0)
        {
            // Paint colour toolbar
            paintToolbar.SetActive(true);
            materialsToolbar.SetActive(false);
        }
        else if (dropDown.value == 1)
        {
            // Materials toolbar
            paintToolbar.SetActive(false);
            materialsToolbar.SetActive(true);
        }
    }
}
