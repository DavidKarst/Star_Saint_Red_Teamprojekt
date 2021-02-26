using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour {

    public float health;
    public float period;

    float startX;
    float startY;

    public int magnitude;

    float t;
    // Use this for initialization
    void Start () {

        startX = transform.position.x;
        startY = transform.position.y;

    }
	
	// Update is called once per frame
	void Update () {
        float x = triangleWave(t);
        t += 1f * Time.deltaTime;

        transform.position = new Vector3(startX + magnitude * x,transform.position.y, 0);

    }

    private float triangleWave(float x)
    {
        float y = (period / Mathf.PI) * Mathf.Asin(Mathf.Sin(Mathf.PI * x));
        return y;
    }
}
