using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    CHOOSEREQUIREMENTS, CHOSENREQUIREMENTS
}

public class PlayerScript : MonoBehaviour
{
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit");
            }
            else
            {
                Debug.Log("no hit");
            }
        }
    }
}
