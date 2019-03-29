using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsGenerationScript : MonoBehaviour
{
    public Text requiredFloorsText;
    public Text randomFeatureText;
    public string[] features;
    public int requiredFloors;
    public string feature;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomlyGenerateRequirements()
    {
        // Randomly generate the number of required floors
        requiredFloors = Mathf.RoundToInt(Random.Range(1, 4));
        requiredFloorsText.text = "The house must have " + requiredFloors + " floors.";

        // Randomly choose a feature from an array
        int randomArrayPos = Mathf.RoundToInt(Random.Range(0, features.Length));
        feature = features[randomArrayPos];
        randomFeatureText.text = "It must also have a " + feature + ".";

    }
}
