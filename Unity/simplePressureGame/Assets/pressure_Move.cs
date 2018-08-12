using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class pressure_Move : MonoBehaviour {

    public Rigidbody playerBody;
    public float forwardForce = 2000f;
    public float sidewayForce = 500f;

    //Setup the variables that are going to control movement and render it
    public float speed;
    private float amountToMove;

    //Setup serial communication don´t forget System.IO.Ports in the using list
    SerialPort sp = new SerialPort("COM3", 9600); //two arguments (Baudrate, Port) check the port bottom right of Arduino GUI
	
    // Use this for initialization
	void Start () {
        sp.Open(); //open the serial port COM3
        sp.ReadTimeout = 1; //wait for incomming information
	}
	
	// Update is called once per frame so we use Time.deltaTime to avoid lagging
	void Update () {
        //move the object according to the frame rate to make sure it adapts to computer's capabilities
        //amountToMove = speed * Time.deltaTime;

        //manage the exception that may happen if the sp port is not open
        if (sp.IsOpen)
        {
            try
            {
                pressObject(sp.ReadByte());
                print(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
	}

    //The function that is going to apply the serial messages from the Arduino into the game Object
    void pressObject (int Direction)
    {
        //Add a forward force to the player
        playerBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Direction == 1)
        {
            playerBody.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Direction == 2)
        {
            playerBody.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
