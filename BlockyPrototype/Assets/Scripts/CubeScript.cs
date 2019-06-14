using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CubeMaterial
{
    STANDARD, GLASS, SNOW, WOOD, BRICK
}



public class CubeScript : MonoBehaviour
{
    public string cubeTag;
    public bool cubeOnFloor = false;
    public CubeMaterial cubeMaterial;
    public float timeActiveExploded = 0.0f;
    public RestartScript restartScript;

    public Material standardMaterial;
    public Material snowMaterial;
    public Material woodMaterial;
    public Material brickMaterial;

    PlayerScript playerScript;
    GridScript gridScript;
    Rigidbody rb;





    // Start is called before the first frame update
    void Start()
    {
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        rb = GetComponent<Rigidbody>();
        if (cubeMaterial == CubeMaterial.STANDARD)
        {
            GetComponent<Renderer>().material.color = new Color(1 / 255, 1 / 255, 1 / 255, 0.4f);
        }
        if (cubeMaterial == CubeMaterial.GLASS)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.4f);
        }
        if (cubeMaterial == CubeMaterial.SNOW)
        {
            GetComponent<Renderer>().material = snowMaterial;
        }
        if (cubeMaterial == CubeMaterial.WOOD)
        {
            GetComponent<Renderer>().material = woodMaterial;
        }
        if (cubeMaterial == CubeMaterial.BRICK)
        {
            GetComponent<Renderer>().material = brickMaterial;
        }

        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();
        gridScript = GameObject.Find("Canvas").GetComponent<GridScript>();
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cubeOnFloor && restartScript.exploding == false)
        {
            rb.MovePosition(transform.position - new Vector3(0, 0.01f, 0));
        }
        
        
        if (playerScript.editView != EditingView.EXTERIOR && cubeMaterial != CubeMaterial.GLASS)
        {
            Color colour = GetComponent<Renderer>().material.color;
            colour.a = 1;
            GetComponent<Renderer>().material.color = colour;
        }
    }



    void Update()
    {

        if (restartScript.exploding)
        {
            timeActiveExploded += Time.deltaTime;
            if (timeActiveExploded > 3)
            {
                Destroy(this.gameObject);
            }
        }

        

        if (cubeMaterial == CubeMaterial.GLASS)
        {
            Color colour = GetComponent<Renderer>().material.color;
            colour.a = 0.1f;
            GetComponent<Renderer>().material.color = colour;
        }

        if (cubeMaterial == CubeMaterial.SNOW)
        {
            GetComponent<Renderer>().material = snowMaterial;
        }
        if (cubeMaterial == CubeMaterial.BRICK)
        {
            Debug.Log(GetComponent<Renderer>().material.color.a);
        }
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor" && restartScript.exploding == false)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cubeOnFloor = true;
        }

        if (other.GetComponent<CubeScript>() != null)
        {
            if (other.GetComponent<CubeScript>().cubeOnFloor && restartScript.exploding == false)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                cubeOnFloor = true;
            }
        }
    }
    
}
