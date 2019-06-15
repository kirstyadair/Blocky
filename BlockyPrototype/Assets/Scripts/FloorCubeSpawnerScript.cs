using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCubeSpawnerScript : MonoBehaviour
{
    public GameObject floorCubePrefab;
    public List<GameObject> floorCubes;
    public float spaceBetweenCubes;
    public float timeBetweenSpawning;
    int numOfCubes = 0;



    public void Start()
    {
        floorCubes = new List<GameObject>();
    }



    public void SpawnPlane(Vector3 startPos, int x, int z)
    {
        transform.position = startPos;
        StartCoroutine(SpawnTheFloor(x, z));
    }



    IEnumerator SpawnTheFloor(int x, int z)
    {
        Material chosenTerrain = GameObject.Find("GameData").GetComponent<GameData>().terrain;
        // Parameter x symbolises the length of the plane, z symbolises the breadth on the z axis
        for (int i = 0; i < z; i++)
        {
            for (int j = 0; j < x; j++)
            {
                GameObject floorCube = Instantiate(floorCubePrefab, transform.position, Quaternion.identity);
                numOfCubes++;
                floorCube.GetComponent<FloorCubeScript>().texture = chosenTerrain;
                floorCube.tag = "Floor";
                floorCube.name = "FloorCube" + numOfCubes.ToString();
                transform.Translate(Vector3.right * spaceBetweenCubes);
            }
            transform.Translate(Vector3.back * spaceBetweenCubes);
            transform.Translate(Vector3.left * spaceBetweenCubes * x);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }
    }
}
