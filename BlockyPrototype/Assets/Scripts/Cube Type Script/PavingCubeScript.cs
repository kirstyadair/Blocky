using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavingCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "PavingCube";
        //gameObject.tag = "Floor";
    }




    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;
        if (transform.position.y > -0.95f)
        {
            transform.position = new Vector3(transform.position.x, -0.9599f, transform.position.z);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PavingCube")
        {
            Debug.Log("Destroying paving");
            if (timeActive < other.GetComponent<PavingCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "GrassCube")
        {
            Debug.Log("Grass Hit");
            // if the grass cube is older than this cube
            if (other.GetComponent<GrassCubeScript>().timeActive > timeActive)
            {
                // destroy the grass
                Debug.Log("Destroying grass");
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
