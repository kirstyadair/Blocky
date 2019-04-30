using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public string cubeTag;
    public bool cubeOnFloor = false;
    Animator cubeAnim;
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
        if (other.tag == "Floor" && gameObject.tag != "Floor")
        {
            name = "FloorCube";
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cubeOnFloor = true;
        }

        if (other.tag == "Plane" && gameObject.tag == "Floor")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (other.GetComponent<CubeScript>() != null)
        {
            if (other.GetComponent<CubeScript>().cubeOnFloor)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                name = "FloorCube";
                cubeOnFloor = true;
            }
        }
    }
}
