using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour {

    float desTime;

    void Start()
    {

        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 100;

        Physics.IgnoreCollision(GetComponent<BoxCollider>(), GetComponent<BoxCollider>(), true);

        desTime = Time.time + 10;
    }

    private void Update()
    {
        if (Time.time >= desTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider c)
    {

        if (c.tag == "player")
        {
            Destroy(gameObject);
            //print("HIT");
            //Destroy(gameObject);
            c.GetComponent<playerStats>().subtractHealth();
        }

    }

}