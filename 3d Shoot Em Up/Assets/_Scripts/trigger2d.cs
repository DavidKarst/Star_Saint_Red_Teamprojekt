using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger2d : MonoBehaviour {

    public cameraToggle ct;

    public SplineWalker s;

    public control c;

    public controls2D c2d;

    public cameraMovement2d cM2d;

    // Use this for initialization
    void Start () {

        if(GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print("3d");
        if (other.gameObject.tag == "player")
        {
            Destroy(gameObject);
            ct.switchCamera();
            s.deactivate();
            c.controlSwitch();
            c2d.controlSwitch();
            cM2d.moveSwitch();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("2d");
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
            ct.switchCamera();
            s.deactivate();
            c.controlSwitch();
            c2d.controlSwitch();
            cM2d.moveSwitch();
        }
    }

}
