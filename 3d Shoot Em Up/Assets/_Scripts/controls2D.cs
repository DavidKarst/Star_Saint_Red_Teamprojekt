using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls2D : MonoBehaviour {


    public bool controlsOn;

	// Use this for initialization
	void Start () {

        controlsOn = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(controlsOn)
        {
            if(Input.GetAxis("Left Stick Y") < -0.75f)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * 9000 * Time.deltaTime);
            }
            else if (Input.GetAxis("Left Stick Y") > 0.75f)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * -9000 * Time.deltaTime);
            }
            else if(Input.GetAxis("Left Stick X") < -0.75f)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * -9000 * Time.deltaTime);
            }
            else if(Input.GetAxis("Left Stick X") > 0.75f)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * 9000 * Time.deltaTime);
            }
        }
    }

    public void controlSwitch()
    {
        controlsOn = !controlsOn;
    }
}
