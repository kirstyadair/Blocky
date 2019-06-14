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
    Renderer ren;





    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        restartScript = GameObject.Find("RestartObject").GetComponent<RestartScript>();
        rb = GetComponent<Rigidbody>();
        if (cubeMaterial == CubeMaterial.STANDARD)
        {
            ren.material.color = new Color(1 / 255, 1 / 255, 1 / 255, 0.4f);
        }
        if (cubeMaterial == CubeMaterial.GLASS)
        {
            ren.material.color = new Color(1, 1, 1, 0.4f);
        }
        if (cubeMaterial == CubeMaterial.SNOW)
        {
            ren.material = snowMaterial;
        }
        if (cubeMaterial == CubeMaterial.WOOD)
        {
            ren.material = woodMaterial;
        }
        if (cubeMaterial == CubeMaterial.BRICK)
        {
            ren.material = brickMaterial;
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
        
        // if not editing the walls and not glass, or if F is pressed, make the walls opaque
        if ((playerScript.editView != EditingView.EXTERIOR && cubeMaterial != CubeMaterial.GLASS) || Input.GetKey(KeyCode.F))
        {
            Color colour = ren.material.color;
            colour.a = 1f;
            ren.material.color = colour;
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
            Color colour = ren.material.color;
            colour.a = 0.1f;
            ren.material.color = colour;
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
