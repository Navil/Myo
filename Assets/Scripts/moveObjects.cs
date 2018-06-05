using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjects : MonoBehaviour {

    private float initX;
    private float maxDistanceX = 50;
    private float speed;
    private float minSpeed = 1;
    private float maxSpeed = 5;

	// Use this for initialization
	void Start () {
        speed = Random.RandomRange(minSpeed, maxSpeed);
        initX = gameObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.forward * Time.deltaTime);
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        if (gameObject.transform.position.x >= (initX + maxDistanceX))
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision col)
    {
        // TODO not working
        //Debug.Log("Collision");
        Destroy(col.gameObject);
    }
}
