using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllTestSphere : MonoBehaviour {

    float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
	}
}
