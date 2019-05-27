using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    public Image colourIndicator;
    public GameObject fillButton;
    public Dropdown dropDown;
    public GameObject paintToolbar;
    public GameObject materialsToolbar;




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
            colourIndicator.enabled = false;
            fillButton.SetActive(false);
        }
        else
        {
            colourIndicator.enabled = true;
            fillButton.SetActive(true);
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
