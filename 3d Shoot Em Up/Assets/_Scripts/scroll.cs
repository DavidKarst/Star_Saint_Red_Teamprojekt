using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {

    float current;
    float max;

    Vector3 startpos;

	// Use this for initialization
	void Start () {

        max = 8.0f;
        startpos = transform.localPosition;
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.5f * Time.deltaTime, transform.localPosition.z);
        current += 0.5f * Time.deltaTime;
        
        if(current >= max)
        {
            transform.localPosition = startpos;
            current = 0;
        }
        print(current);
	}
}
