using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCubeSpawnerScript : MonoBehaviour
{
    public GameObject floorCubePrefab;
    public List<GameObject> floorCubes;
    public float spaceBetweenCubes;
    public float timeBetweenSpawning;



    public void Start()
    {
        floorCubes = new List<GameObject>();
    }



    public void SpawnPlane(Vector3 startPos, int x, int z, Material chosenTerrain)
    {
        transform.position = startPos;
        StartCoroutine(SpawnTheFloor(x, z, chosenTerrain));
    }



    IEnumerator SpawnTheFloor(int x, int z, Material chosenTerrain)
    {
        // Parameter x symbolises the length of the plane, z symbolises the breadth on the z axis
        for (int i = 0; i < z; i++)
        {
            for (int j = 0; j < x; j++)
            {
                GameObject floorCube = Instantiate(floorCubePrefab, transform.position, Quaternion.identity);
                floorCube.GetComponent<FloorCubeScript>().texture = chosenTerrain;
                floorCube.tag = "Floor";
                floorCubes.Add(floorCube);
                floorCube.name = "FloorCube" + floorCubes.Count;
                transform.Translate(Vector3.right * spaceBetweenCubes);
            }
            transform.Translate(Vector3.back * spaceBetweenCubes);
            transform.Translate(Vector3.left * spaceBetweenCubes * x);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }
    }
}
