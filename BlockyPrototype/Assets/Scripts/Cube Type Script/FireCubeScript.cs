using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCubeScript : MonoBehaviour
{
    public GameObject grassPrefab;
    public GameObject burningCubePrefab;
    public double timeActive = 0.0f;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "FireCube";
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

        if (other.name == "FireCube")
        {
            if (other.GetComponent<FireCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<FireCubeScript>().timeActive += 0.01f;
            }

            if (timeActive > other.GetComponent<FireCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }

        }

        if (other.name == "WoodCube")
        {
            Vector3 position = this.transform.position;
            GameObject newCube = Instantiate(burningCubePrefab, position, Quaternion.identity);
            newCube.GetComponent<BurningCubeScript>().timeActive += Random.Range(0, 0.01f);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        

        if (other.name == "FlowerCube")
        {
            if (timeActive < other.GetComponent<FlowerCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
