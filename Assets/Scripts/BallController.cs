using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private float initX;
    private float maxDistanceX = 50;
    private float speed;
    private float minSpeed = 20;
    private float maxSpeed = 50;

    string ballColor;

    Rigidbody body;
    //float force = 250;

    Vector3 startPos, targetPos;
    float arcMin = 10;
    float arcMax = 30;
    float arcHeight;

	// Use this for initialization
	void Start () {

        startPos = transform.position;
        targetPos = new Vector3(startPos.x + 150, transform.position.y, transform.position.z);

        speed = Random.Range(minSpeed, maxSpeed);
        arcHeight = Random.Range(arcMin, arcMax);
        initX = gameObject.transform.position.x;

        //Debug.Log("name!: " + gameObject.name.ToString());

        if (gameObject.name.Contains("Blue"))
            ballColor = "BLUE";
        else if (gameObject.name.Contains("Green"))
            ballColor = "GREEN";
        else if (gameObject.name.Contains("Red"))
            ballColor = "RED";

        body = GetComponent<Rigidbody>();

        //body.AddForce((transform.right + transform.up) * force);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // http://luminaryapps.com/blog/arcing-projectiles-in-unity/
        // Compute the next position, with arc added in
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

        transform.position = nextPos;

        if (nextPos == targetPos) Destroy(gameObject);


        //transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        /*if ((gameObject.transform.position.x - initX) >= maxDistanceX / 2 )
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }*/


        //if (gameObject.transform.position.x >= (initX + maxDistanceX))
        /*if (gameObject.transform.position.y <= -10)
        {
            Destroy(gameObject);
        }*/
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
