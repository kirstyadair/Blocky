using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public GameObject grassPrefab;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "SnowCube";
        //GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.SAND);
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
        if (other.name == "SnowCube")
        {
            if (other.GetComponent<SnowCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<SnowCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<SnowCubeScript>().timeActive)
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

        if (other.name == "PavingCube")
        {
            if (other.GetComponent<PavingCubeScript>().timeActive > timeActive)
            {
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
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "SandCube")
        {
            if (timeActive < other.GetComponent<SandCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (other.name == "DirtCube")
        {
            if (timeActive < other.GetComponent<DirtCubeScript>().timeActive)
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
            Vector3 position = this.transform.position;
            GameObject newCube = Instantiate(grassPrefab, position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
