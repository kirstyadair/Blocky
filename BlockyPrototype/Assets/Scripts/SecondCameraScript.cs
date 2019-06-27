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

        if (GetComponent<Camera>().enabled)
        {
            if (Input.GetKey(KeyCode.W))
            {
                float zVal = transform.position.z;
                transform.position = new Vector3(transform.position.x, transform.position.y, zVal += 0.01f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                float zVal = transform.position.z;
                transform.position = new Vector3(transform.position.x, transform.position.y, zVal -= 0.01f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                float xVal = transform.position.x;
                transform.position = new Vector3(xVal += 0.01f, transform.position.y, transform.position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                float xVal = transform.position.x;
                transform.position = new Vector3(xVal -= 0.01f, transform.position.y, transform.position.z);
            }


            if (Input.GetKey(KeyCode.F1))
            {
                GetComponent<Camera>().fieldOfView += 0.1f;
            }
            if (Input.GetKey(KeyCode.F2))
            {
                GetComponent<Camera>().fieldOfView -= 0.1f;
            }
            
        }
    }
}
