using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public GameObject grassPrefab;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "FlowerCube";
        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.FLOWER);
    }




    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;
        if (transform.position.y != -0.8799995f)
        {
            transform.position = new Vector3(transform.position.x, -0.8799995f, transform.position.z);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.name == "WaterCube")
        {
            Vector3 position = other.transform.position;
            Destroy(other.gameObject);
            GameObject newCube = Instantiate(grassPrefab, position, Quaternion.identity);
        }

        if (other.name == "FireCube")
        {
            if (timeActive < other.GetComponent<FireCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "WoodCube")
        {
            if (timeActive < other.GetComponent<WoodCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "BurningCube")
        {
            if (timeActive < other.GetComponent<BurningCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.name == "FlowerCube")
        {
            if (other.GetComponent<FlowerCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<FlowerCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<FlowerCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
