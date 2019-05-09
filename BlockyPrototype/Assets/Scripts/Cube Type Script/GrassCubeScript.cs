using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCubeScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -0.95f)
        {
            transform.position = new Vector3(transform.position.x, -0.9599f, transform.position.z);
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrassCubeScript>() != null || (other.tag == "Floor" && other.name != "BlackFloorCube"))
        {
            Debug.Log("another grass cube hit");
            Destroy(other.gameObject);
        }
    }
}
