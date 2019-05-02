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

    public Color selectedColour;

    public GridScript gridScript;



    void Update()
    {
        selectedColour = colourTile.color;
    }



    public void OnRedValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.r = redSlider.value;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;
    }



    public void OnGreenValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.g = greenSlider.value;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;
    }



    public void OnBlueValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.b = blueSlider.value;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;
    }
}
