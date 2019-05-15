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
        GetComponent<Renderer>().material.color = new Color(1 / 255, 1 / 255, 1 / 255, 0.4f);
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position - new Vector3(0, 0.01f, 0));
        
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cubeOnFloor = true;
        }

        if (other.GetComponent<CubeScript>() != null)
        {
            if (other.GetComponent<CubeScript>().cubeOnFloor)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                cubeOnFloor = true;
            }
        }
    }
    
}
