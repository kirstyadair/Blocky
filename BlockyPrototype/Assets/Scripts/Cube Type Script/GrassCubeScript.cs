using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;
    public bool isBlackCube;




    private void Start()
    {
        if (!isBlackCube)
        {
            gameObject.name = "GrassCube";
            gameObject.tag = "Floor";
        }
        else
        {
            gameObject.name = "BlackFloorCube";
            gameObject.tag = "Floor";
            GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.4f);
        }
        
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
        if (other.name == "GrassCube")
        {
            if (other.GetComponent<GrassCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<GrassCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<GrassCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }
        
    }
}
