using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSelectorScript : MonoBehaviour
{
    public Slider redSlider;
    public Slider blueSlider;
    public Slider greenSlider;
    public Image colourTile;
    public GameObject panel;

    public Color selectedColour;

    public GridScript gridScript;


    private void Start()
    {
        //colourTile.color = new Color(0, 0, 0, 0);
    }



    void Update()
    {
        selectedColour = colourTile.color;
        //selectedColour.a = 1;

        if (selectedColour == new Color(0, 0, 0, 1))
        {
            selectedColour = new Color(0, 0.5f, 0);
            colourTile.color = selectedColour;
            gridScript.selectedColour = selectedColour;
        }
    }



    public void OnRedValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.a = 1;
        newColour.r = redSlider.value;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;
    }



    public void OnGreenValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.a = 1;
        newColour.g = greenSlider.value;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;
    }



    public void OnBlueValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.a = 1;
        newColour.b = blueSlider.value;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;
    }
}
