using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCubeScript : MonoBehaviour
{
    public GameObject grassPrefab;
    public double timeActive = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "StoneCube";
        //GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.FIRE);
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

        if (other.name == "StoneCube")
        {
            if (other.GetComponent<StoneCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<StoneCubeScript>().timeActive += 0.01f;
            }

            if (timeActive > other.GetComponent<StoneCubeScript>().timeActive)
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
            else
            {
                Destroy(this.gameObject);
            }
        }


        if (other.name == "FlowerCube")
        {
            if (timeActive < other.GetComponent<FlowerCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "FireCube")
        {
            if (timeActive < other.GetComponent<FireCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
