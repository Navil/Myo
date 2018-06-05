﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjects : MonoBehaviour {

    private float initX;
    private float maxDistanceX = 50;
    private float speed;
    private float minSpeed = 1;
    private float maxSpeed = 10;

    Rigidbody body;
    float force = 800;

	// Use this for initialization
	void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
        initX = gameObject.transform.position.x;

        body = GetComponent<Rigidbody>();

        body.AddForce((transform.right + transform.up) * force);
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        if ((gameObject.transform.position.x - initX) >= maxDistanceX / 2 )
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }*/


        //if (gameObject.transform.position.x >= (initX + maxDistanceX))
        if (gameObject.transform.position.y <= -10)
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
    }
}
