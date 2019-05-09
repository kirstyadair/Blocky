using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCubeScript : MonoBehaviour
{
    public GameObject grassPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Don't allow wood to be put on water
        if (other.bounds.center.y < gameObject.GetComponent<Collider>().bounds.center.y)
        {
            if (other.name.Substring(0, 9) == "WaterCube")
            {
                Vector3 position = other.transform.position;
                Destroy(other.gameObject);
                GameObject newCube = Instantiate(grassPrefab, position, Quaternion.identity);
            }
        }
        
    }
}
