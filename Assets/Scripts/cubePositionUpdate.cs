using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubePositionUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        gameObject.transform.position.Set(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        Debug.Log("Pos! " + newPos.ToString());
	}
}
