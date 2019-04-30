using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCubeSpawnerScript : MonoBehaviour
{
    public GameObject floorCubePrefab;
    public List<GameObject> floorCubes;
    public float spaceBetweenCubes;
    public float timeBetweenSpawning;



    public void SpawnPlane(Vector3 startPos, int x, int z)
    {
        transform.position = startPos;
        StartCoroutine(SpawnTheFloor(x, z));
        floorCubes = new List<GameObject>();
    }



    IEnumerator SpawnTheFloor(int x, int z)
    {
        // Parameter x symbolises the length of the plane, z symbolises the breadth on the z axis
        for (int i = 0; i < z; i++)
        {
            for (int j = 0; j < x; j++)
            {
                GameObject floorCube = Instantiate(floorCubePrefab, transform.position, Quaternion.identity);
                floorCube.tag = "Floor";
                floorCubes.Add(floorCube);
                transform.Translate(Vector3.right * spaceBetweenCubes);
            }
            transform.Translate(Vector3.back * spaceBetweenCubes);
            transform.Translate(Vector3.left * spaceBetweenCubes * x);
            yield return new WaitForSeconds(timeBetweenSpawning);
        }
        
    }

    
}
