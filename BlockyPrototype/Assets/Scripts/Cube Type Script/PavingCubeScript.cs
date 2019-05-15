using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavingCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public GameObject grassPrefab;




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
            if (timeActive < other.GetComponent<PavingCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "GrassCube")
        {
            // if the grass cube is older than this cube
            if (other.GetComponent<GrassCubeScript>().timeActive > timeActive)
            {
                // destroy the grass
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "WaterCube")
        {
            if (timeActive < other.GetComponent<WaterCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "FireCube" || other.name == "FlowerCube")
        {
            Vector3 position = this.transform.position;
            GameObject newCube = Instantiate(grassPrefab, position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
