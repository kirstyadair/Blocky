using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCubeScript : MonoBehaviour
{
    public GameObject grassPrefab;
    public float timeActive = 0.0f;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "FireCube";
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
        // Don't allow fire to be put on water
        if (other.bounds.center.y < gameObject.GetComponent<Collider>().bounds.center.y)
        {
            if (other.name == "WaterCube")
            {
                Vector3 position = other.transform.position;
                Destroy(other.gameObject);
                GameObject newCube = Instantiate(grassPrefab, position, Quaternion.identity);
            }
        }

        if (other.name == "FireCube")
        {
            if (timeActive < other.GetComponent<FireCubeScript>().timeActive)
            {
                Destroy(other.gameObject);
            }
        }

    }
}
