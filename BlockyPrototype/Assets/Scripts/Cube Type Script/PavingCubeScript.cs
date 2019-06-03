using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavingCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    public RestartScript restartScript;
    public GameObject grassPrefab;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "PavingCube";
        GameObject.Find("AudioObject").GetComponent<AudioManager>().PlayCubeSpawn(CubeType.PAVING);
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
    }




    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;

        if (restartScript.exploding)
        {
            timeActiveExploded += Time.deltaTime;
            if (timeActiveExploded > 3)
            {
                Destroy(this.gameObject);
            }
        }


        if (transform.position.y > -0.95f && restartScript.exploding == false)
        {
            transform.position = new Vector3(transform.position.x, -0.9599f, transform.position.z);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PavingCube")
        {
            if (other.GetComponent<PavingCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<PavingCubeScript>().timeActive += 0.01f;
            }

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
        

        if (other.name == "SandCube")
        {
            if (other.GetComponent<SandCubeScript>().timeActive > timeActive)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
