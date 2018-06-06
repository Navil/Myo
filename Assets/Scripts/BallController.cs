using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private float initX;
    private float maxDistanceX = 50;
    private float speed;
    private float minSpeed = 1;
    private float maxSpeed = 10;

    string ballColor;

    Rigidbody body;
    float force = 450;

	// Use this for initialization
	void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
        initX = gameObject.transform.position.x;

        //Debug.Log("name!: " + gameObject.name.ToString());

        if (gameObject.name.Contains("Blue"))
            ballColor = "BLUE";
        else if (gameObject.name.Contains("Green"))
            ballColor = "GREEN";
        else if (gameObject.name.Contains("Red"))
            ballColor = "RED";

        //body = GetComponent<Rigidbody>();

        //body.AddForce((transform.right + transform.up) * force);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        /*if ((gameObject.transform.position.x - initX) >= maxDistanceX / 2 )
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }*/


        //if (gameObject.transform.position.x >= (initX + maxDistanceX))
        if (gameObject.transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
	}

    /*void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "myo_trigger")
        {
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Hit!");
        if (collision.gameObject.tag == "myo_trigger")
        {
            ColorBoxByPose color = GameObject.FindObjectOfType<ColorBoxByPose>();
            string state = color.GetMyoState();

            //Debug.Log("HIT!: " + state + " - " + ballColor);

            if(state.Equals(ballColor))
            {
                Debug.Log("HIT!");
                UpdateScoreText scoreKeeper = GameObject.FindObjectOfType<UpdateScoreText>();
                scoreKeeper.IncrementScore();
                Destroy(gameObject);
            }
        }
    }
}
