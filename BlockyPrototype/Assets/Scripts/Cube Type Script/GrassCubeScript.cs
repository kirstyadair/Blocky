using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public double timeActiveExploded = 0.0f;
    public int indexInFloorCube;
    public bool isBlackCube;
    public Material grassMaterial;
    RestartScript restartScript;
    FloorCubeSpawnerScript spawnerScript;




    private void Start()
    {
        if (!isBlackCube)
        {
            gameObject.name = "GrassCube";
            //GetComponent<MeshRenderer>().material = grassMaterial;
        }
        else
        {
            gameObject.name = "BlackFloorCube";
            GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.4f);
        }
        gameObject.tag = "Floor";
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        spawnerScript = GameObject.Find("FloorCubeSpawner").GetComponent<FloorCubeSpawnerScript>();

    }



    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;

        if (restartScript.exploding)
        {
            timeActiveExploded += Time.deltaTime;
            if (timeActiveExploded > 10)
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
        if (other.name == "GrassCube")
        {
            if (other.GetComponent<GrassCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<GrassCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<GrassCubeScript>().timeActive)
            {
                //indexInFloorCube = other.GetComponent<GrassCubeScript>().indexInFloorCube;
                //spawnerScript.floorCubes[indexInFloorCube] = gameObject.transform;
                Destroy(other.gameObject);
            }
        }


        
    }
}
