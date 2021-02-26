using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement2d : MonoBehaviour {

    bool move;

	// Use this for initialization
	void Start () {

        move = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(move)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f * Time.deltaTime, transform.position.z);
        }
        

	}


    public void moveSwitch()
    {
        move = !move;
    }
}
