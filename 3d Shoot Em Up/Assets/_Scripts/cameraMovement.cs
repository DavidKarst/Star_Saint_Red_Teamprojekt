using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject spaceship;

    public Vector3 origin;

	void Start () {

        origin = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
		
	}
	
	// Update is called once per frame
	void Update () {

        origin = new Vector3(origin.x, origin.y, spaceship.transform.localPosition.z - 12);

        float x = Mathf.Lerp(0, spaceship.transform.localPosition.x, 0.8f);
        float y = Mathf.Lerp(0, spaceship.transform.localPosition.y, 0.8f);

       // print("x: " +x);
       // print("y: " +y);
        transform.localPosition = new Vector3(x, y, transform.localPosition.z);


        
		
	}


    public Vector3 getOrigin()
    {
        return origin;
    }

}
