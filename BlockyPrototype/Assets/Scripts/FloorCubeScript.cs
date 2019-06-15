using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCubeScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject grassPrefab;
    FloorCubeSpawnerScript fcsScript;
    Transform blackCubeObject;
    Transform grassCubeObject;
    public Material texture;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fcsScript = GameObject.Find("FloorCubeSpawner").GetComponent<FloorCubeSpawnerScript>();
        ColourCube();
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position - new Vector3(0, 0.01f, 0));
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Vector3 pos = transform.position;
            gameObject.SetActive(false);
            GameObject grassCube = Instantiate(grassPrefab, pos, Quaternion.identity);

            fcsScript.floorCubes.Add(grassCube);

            grassCube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (gameObject.name == "BlackFloorCube")
            {
                grassCube.GetComponent<GrassCubeScript>().isBlackCube = true;
                blackCubeObject = GameObject.Find("BlackFloorCubeObject").transform;
                grassCube.transform.SetParent(blackCubeObject);
            }
            else
            {
                grassCube.GetComponent<GrassCubeScript>().isBlackCube = false;
                grassCube.GetComponent<Renderer>().material = texture;
                grassCubeObject = GameObject.Find("GrassCubeObject").transform;
                grassCube.transform.SetParent(grassCubeObject);
            }

            Destroy(gameObject);
        }
        
    }

    

    public void ColourCube()
    {
        int cubeID = int.Parse(gameObject.name.Substring(9));
        // find a way to make this more efficient
        if (cubeID > 5 && cubeID < 17 || cubeID > 35 && cubeID < 47 || cubeID > 65 && cubeID < 77 || cubeID > 95 && cubeID < 107 || cubeID > 125 && cubeID < 137 || cubeID > 155 && cubeID < 167 || cubeID > 185 && cubeID < 197 || cubeID > 215 && cubeID < 227 || cubeID > 245 && cubeID < 257 || cubeID > 275 && cubeID < 287 || cubeID > 305 && cubeID < 317)
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0.4f);
            gameObject.name = "BlackFloorCube";
            
        }
    }
}
