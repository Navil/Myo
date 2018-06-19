using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GenerateRandomObjects : MonoBehaviour {

    public GameObject[] objects;
    //public int scale = 1;
    //public Text textScore;

    int startTime = 0;
    float spawnMinTime = 2.0f;
    float spawnMaxTime = 5.0f;
    int maxObjects = 50;
    Vector3 spawnRange = new Vector3(0, 5, 0);
    bool isOnGoing = true;
    //int countObjects = 0;

    float nextSpawnTime;
    int currentScore;
    int objectsOnce = 1;
    int objectsDiff = 1;

	// Use this for initialization
	void Start ()
    {
        //Debug.Log("I am alive!");
        StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update ()
    {
        nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime);
        
        UpdateScoreText scoreKeeper = GameObject.FindObjectOfType<UpdateScoreText>();
        currentScore = scoreKeeper.GetScore();

        // 1 ball 1 farbe
        if (currentScore <= 5)
        {
            objectsOnce = 1;
            objectsDiff = 1;
        }
        // 1 ball 2 moegliche farben usw
        else if (currentScore <= 10)
        {
            objectsOnce = 1;
            objectsDiff = 2;
        }
        else if (currentScore <= 15)
        {
            objectsOnce = 2;
            objectsDiff = 2;
        }
        else if (currentScore <= 20)
        {
            objectsOnce = 3;
            objectsDiff = 2;
        }
        else if (currentScore <= 25)
        {
            objectsOnce = 3;
            objectsDiff = 3;
        }
        else
        {
            objectsOnce = 5;
            objectsDiff = 3;
        }

        //if (objectsDiff >= objects.Length) objectsDiff = objects.Length - 1;

        //Debug.Log("Score: " + currentScore);

	}

    IEnumerator Spawner ()
    {
        yield return new WaitForSeconds(startTime);

        while (isOnGoing)
        {
            
            for (int i = 0; i < objectsOnce; i++)
            {
                int randomObject = Random.Range(0, objectsDiff);
                Vector3 spawnPosition = new Vector3(spawnRange.x, Random.Range(0, spawnRange.y), spawnRange.z);

                //Debug.Log("randomObject: " + randomObject);

                Instantiate(objects[randomObject], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            }
           

            //countObjects++;
            //Debug.Log("Spawn Object! " + randomObject);

            yield return new WaitForSeconds(nextSpawnTime);
        }
    }

}
