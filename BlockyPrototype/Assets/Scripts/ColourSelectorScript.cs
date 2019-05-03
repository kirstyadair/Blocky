using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSelectorScript : MonoBehaviour
{
    public Slider redSlider;
    public Slider blueSlider;
    public Slider greenSlider;
    public InputField redValField;
    public InputField blueValField;
    public InputField greenValField;

    public float redValue;
    public float blueValue;
    public float greenValue;

    public bool RGBInput = false;
    public bool colourPipetteSelected = false;

    public Image colourTile;

    public Color selectedColour;

    public GridScript gridScript;



    void Update()
    {
        selectedColour = colourTile.color;
        selectedColour.a = 1;

        if (RGBInput)
        {
            if (float.TryParse(redValField.text, out redValue))
            {
                if (redValue == 0)
                {
                    redValue = 1;
                }
                float convertedVal = redValue / 255;
                redSlider.value = convertedVal;
                OnRedValueChanged();
            }

            if (float.TryParse(greenValField.text, out greenValue))
            {
                if (greenValue == 0)
                {
                    greenValue = 1;
                }
                float convertedVal = greenValue / 255;
                greenSlider.value = convertedVal;
                OnGreenValueChanged();
            }

            if (float.TryParse(blueValField.text, out blueValue))
            {
                if (blueValue == 0)
                {
                    blueValue = 1;
                }
                float convertedVal = blueValue / 255;
                blueSlider.value = convertedVal;
                OnBlueValueChanged();
            }
        }
        

        
    }



    public void OnRedValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.r = redSlider.value;
        if (newColour.r == 0)
        {
            newColour.r = 0.01f;
        }
        newColour.a = 1;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;

        redValField.text = (redSlider.value * 255).ToString();
    }



    public void OnGreenValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.g = greenSlider.value;
        if (newColour.g == 0)
        {
            newColour.g = 0.01f;
        }
        newColour.a = 1;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;

        greenValField.text = (greenSlider.value * 255).ToString();
    }



    public void OnBlueValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.b = blueSlider.value;
        if (newColour.b == 0)
        {
            newColour.b = 0.01f;
        }
        newColour.a = 1;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;

        blueValField.text = (blueSlider.value * 255).ToString();
    }




    public void UpdateColour()
    {
        selectedColour = gridScript.selectedColour;
        colourTile.color = selectedColour;
        redSlider.value = selectedColour.r;
        blueSlider.value = selectedColour.b;
        greenSlider.value = selectedColour.g;
    }



    public void ColourPipetteSelected()
    {
        colourPipetteSelected = true;
    }
}
