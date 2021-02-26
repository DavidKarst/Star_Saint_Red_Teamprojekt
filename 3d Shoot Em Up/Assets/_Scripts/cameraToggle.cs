using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraToggle : MonoBehaviour {

    public Camera cam1;
    Camera cam2;

	// Use this for initialization
	void Start () {

        cam2 = GetComponent<Camera>();

        cam1.enabled = true;
        cam2.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.P))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
		
	}

    public void switchCamera()
    {
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }
}
