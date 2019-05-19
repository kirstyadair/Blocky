using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeScript : MonoBehaviour
{
    public string cubeTag;
    public bool cubeOnFloor = false;
    PlayerScript playerScript;
    GridScript gridScript;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material.color = new Color(1 / 255, 1 / 255, 1 / 255, 0.4f);
        playerScript = GameObject.Find("PlayerObject").GetComponent<PlayerScript>();
        gridScript = GameObject.Find("Canvas").GetComponent<GridScript>();
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cubeOnFloor)
        {
            rb.MovePosition(transform.position - new Vector3(0, 0.01f, 0));
        }
        
        
        if (playerScript.editView != EditingView.EXTERIOR)
        {
            Color colour = GetComponent<Renderer>().material.color;
            colour.a = 1;
            GetComponent<Renderer>().material.color = colour;
        }
    }



    void Update()
    {
        
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            cubeOnFloor = true;
        }

        if (other.GetComponent<CubeScript>() != null)
        {
            if (other.GetComponent<CubeScript>().cubeOnFloor)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                cubeOnFloor = true;
            }
        }
    }



    /*public void Fill()
    {
        if (GetComponent<Renderer>().material.color.a == 0.2f)
        {
            Color colour = gridScript.selectedColour;
            GetComponent<Renderer>().material.color = colour;
        }
    }*/
    
}
