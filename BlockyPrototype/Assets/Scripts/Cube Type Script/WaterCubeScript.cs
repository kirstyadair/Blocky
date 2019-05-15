using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public GameObject grassPrefab;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "WaterCube";
        gameObject.tag = "Floor";
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
        if (other.name == "WaterCube")
        {
            if (other.GetComponent<WaterCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<WaterCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<WaterCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "GrassCube")
        {
            if (other.GetComponent<GrassCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "FireCube" || other.name == "WoodCube" || other.name == "FlowerCube" || other.name == "BurningCube")
        {
            Vector3 position = this.transform.position;
            GameObject newCube = Instantiate(grassPrefab, position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (other.name == "PavingCube")
        {
            if (timeActive < other.GetComponent<PavingCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
