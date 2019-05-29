using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCubeScript : MonoBehaviour
{
    public double timeActive = 0.0f;





    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "SandCube";
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
        if (other.name == "SandCube")
        {
            if (other.GetComponent<SandCubeScript>().timeActive == timeActive)
            {
                other.GetComponent<SandCubeScript>().timeActive += 0.01f;
            }

            if (timeActive < other.GetComponent<SandCubeScript>().timeActive)
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
        }

        if (other.name == "WaterCube")
        {
            if (timeActive < other.GetComponent<WaterCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }
        
    }
}
