using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GetComponent<Camera>().enabled == true)
            {
                GetComponent<Camera>().enabled = false;
            }
            else
            {
                GetComponent<Camera>().enabled = true;
            }
            
        }
    }
}
