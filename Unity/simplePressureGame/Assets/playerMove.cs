using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    public Rigidbody playerBody;
    public float forwardForce = 2000f;
    public float sidewayForce = 500f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Add a forward force to the player
        playerBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        //Make cube move right with keypress
        if (Input.GetKey("d"))
        {
            playerBody.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Make cube move left with keypress
        if (Input.GetKey("a"))
        {
            playerBody.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

    }
}
