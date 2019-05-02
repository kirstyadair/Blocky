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
                float convertedVal = redValue / 255;
                Debug.Log(convertedVal);
                redSlider.value = convertedVal;
                OnRedValueChanged();
            }

            if (float.TryParse(greenValField.text, out greenValue))
            {
                float convertedVal = greenValue / 255;
                Debug.Log(convertedVal);
                greenSlider.value = convertedVal;
                OnGreenValueChanged();
            }

            if (float.TryParse(blueValField.text, out blueValue))
            {
                float convertedVal = blueValue / 255;
                Debug.Log(convertedVal);
                blueSlider.value = convertedVal;
                OnBlueValueChanged();
            }
        }
        

        
    }



    public void OnRedValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.r = redSlider.value;
        newColour.a = 1;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;

        redValField.text = (redSlider.value * 255).ToString();
    }



    public void OnGreenValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.g = greenSlider.value;
        newColour.a = 1;
        colourTile.color = newColour;
        gridScript.selectedColour = colourTile.color;

        greenValField.text = (greenSlider.value * 255).ToString();
    }



    public void OnBlueValueChanged()
    {
        Color newColour = colourTile.color;
        newColour.b = blueSlider.value;
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
}
