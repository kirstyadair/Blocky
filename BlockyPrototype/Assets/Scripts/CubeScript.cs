using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public string cubeTag;
    public bool cubeOnFloor = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position - new Vector3(0, 0.01f, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            name = "FloorCube";
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cubeOnFloor = true;
        }

        if (other.GetComponent<CubeScript>() != null)
        {
            if (other.GetComponent<CubeScript>().cubeOnFloor)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                name = "FloorCube";
                Debug.Log("Non-floor cube hit");
                cubeOnFloor = true;
            }
        }
    }
}
