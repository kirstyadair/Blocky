using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public GameObject grenadePrefab;
    public GameObject plane;
    GameData gameData;
    public PlayerScript playerScript;
    public GridScript gridScript;
    public RequirementsGeneratorScript requirementsGeneratorScript;
    public FloorCubeSpawnerScript floorCubeSpawnerScript;
    public Animator chooseTerrainPanel;
    public Animator drawingPanelAnim;
    public float radius;
    public float force;
    public bool exploding = false;
    bool showMenu = false;


    private void Start()
    {
        chooseTerrainPanel.SetBool("in", false);
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        exploding = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerScript.AllCamAnimationsFalse();
            if (playerScript.editView == EditingView.GROUND)
            {
                playerScript.cameraAnim.SetBool("BirdsEyeToFront", true);
            }
            else if (playerScript.editView == EditingView.INTERIOR)
            {
                playerScript.cameraAnim.SetBool("ZoomToFront", true);
            }
            Explode();
        }

        if (showMenu)
        {
            chooseTerrainPanel.SetBool("in", true);
            
        }
    }




    public void Explode()
    {
        exploding = true;
        GameObject grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
        if (grenade.GetComponent<Rigidbody>().velocity.y == 0)
        {
            if (drawingPanelAnim.GetBool("openPanel"))
            {
                drawingPanelAnim.SetBool("openPanel", false);
            }

            StartCoroutine(DelayExplosion(grenade));
            
        }
        
    }




    IEnumerator DelayExplosion(GameObject grenade)
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().fieldOfView++;
            yield return new WaitForSeconds(0.01f);
        }
        
        yield return new WaitForSeconds(2);
        

        Collider[] colliders = Physics.OverlapSphere(grenade.transform.position, radius);
        Destroy(grenade);
        foreach (Collider hitCollider in colliders)
        {
            if (hitCollider.name == "Plane")
            {
                plane.SetActive(false);
            }
            if (hitCollider.GetComponent<Rigidbody>() != null)
            {
                Vector3 direction = hitCollider.transform.position - transform.position;
                if (direction.y < 0)
                {
                    direction = new Vector3(direction.x, -direction.y, direction.z);
                }
                direction.Normalize();

                hitCollider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                hitCollider.GetComponent<Rigidbody>().useGravity = true;

                Vector3 forceVect = new Vector3(Random.Range(0, direction.x), Random.Range(0, direction.y), Random.Range(0, direction.z));  
                forceVect *= Random.Range(force - 100, force + 100);
                hitCollider.GetComponent<Rigidbody>().AddForce(forceVect);
            }

        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < 10; i++)
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().fieldOfView--;
            yield return new WaitForSeconds(0.01f);
        }

        showMenu = true;
    }




    public void GrassTerrain()
    {
        gameData.blankCubeType = CubeType.GRASS;
        SceneManager.LoadScene("BlockySandbox");
    }



    public void SandTerrain()
    {
        gameData.blankCubeType = CubeType.SAND;
        SceneManager.LoadScene("BlockySandbox");
    }



    public void SnowTerrain()
    {
        gameData.blankCubeType = CubeType.SNOW;
        SceneManager.LoadScene("BlockySandbox");
    }




    public void DirtTerrain()
    {
        gameData.blankCubeType = CubeType.DIRT;
        SceneManager.LoadScene("BlockySandbox");
    }
}
