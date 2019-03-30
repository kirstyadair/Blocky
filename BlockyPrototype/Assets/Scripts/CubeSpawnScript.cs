using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnScript : MonoBehaviour
{
    public GameObject cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            transform.Translate(Vector3.right * 0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            transform.Translate(Vector3.back * 0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            transform.Translate(Vector3.left * 0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject spawnedCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            transform.Translate(Vector3.forward * 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
