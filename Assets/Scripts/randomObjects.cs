using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObjects : MonoBehaviour {

    public GameObject[] objects;

    int startTime = 0;
    float spawnMinTime = 0.5f;
    float spawnMaxTime = 4.0f;
    int maxObjects = 50;
    Vector3 spawnRange = new Vector3(0, 20, 0);
    bool isOnGoing = true;
    int countObjects = 0;


    float nextSpawnTime;

	// Use this for initialization
	void Start ()
    {
        //Debug.Log("I am alive!");
        StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (countObjects <= maxObjects)
        {
            isOnGoing = true;
        } else
        {
            isOnGoing = false;
        }

        nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime);
	}

    IEnumerator Spawner ()
    {
        yield return new WaitForSeconds(startTime);

        while (isOnGoing)
        {
            int randomObject = Random.Range(0, objects.Length);
            Vector3 spawnPosition = new Vector3(spawnRange.x, Random.Range(0, spawnRange.y), spawnRange.z);

            Instantiate(objects[randomObject], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            countObjects++;
            //Debug.Log("Spawn Object! " + randomObject);

            yield return new WaitForSeconds(nextSpawnTime);
        }
    }
}
