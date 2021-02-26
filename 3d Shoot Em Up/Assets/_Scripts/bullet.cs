using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public int speed;

    public crosshair c;

    public ParticleSystem ps;

    Vector3 start;
    Vector3 normal;


    private void Start()
    {
        //transform.LookAt(c.transform.position);

        start = transform.position;
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 400;

        Physics.IgnoreCollision(GetComponent<SphereCollider>(), GetComponent<SphereCollider>(), true);

        

    }
    // Use this for initialization
    void Update () {

        //transform.position += transform.forward * Time.deltaTime * speed;

        if ((start - transform.position).magnitude > 90)
        {

            //Instantiate(ps, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }



    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            Instantiate(ps, transform.position, transform.rotation);
            collision.gameObject.GetComponent<Enemy>().subractHealth(20);
        }
        else
        {
            Destroy(gameObject);
            Instantiate(ps, transform.position, transform.rotation);
        }

        //Destroy(gameObject);
        //Destroy(collision.gameObject);

        /*
        var point = collision.contacts[0].point;
        //print(point.x + " " + point.y + " " + point.z);
        var dir = collision.contacts[0].normal;
        //print(dir.x + " " + dir.y + " " + dir.z);

        point -= dir;
        RaycastHit hitInfo;

        if(collision.collider.Raycast(new Ray(point, dir), out hitInfo, 2))
        {

            normal = hitInfo.normal;
            print(normal.x + " " + normal.y + " " + normal.z);

            var angle = Vector3.Angle(-transform.forward, normal);
            print(angle);

            //Instantiate(ps, transform.position,Quaternion.Euler (normal));
        }
        */


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            Instantiate(ps, transform.position, transform.rotation);
            other.gameObject.GetComponent<Enemy>().subractHealth(40);
            other.GetComponent<Enemy>().flash();
        }
        if (other.gameObject.tag == "enemyBoss")
        {
            Destroy(gameObject);
            Instantiate(ps, transform.position, transform.rotation);
            other.gameObject.GetComponent<Enemy>().subractHealth(40);
            other.GetComponent<Enemy>().flash();
        }
    }

    private void OnDestroy()
    {
        //print(gameObject.transform.position.y);
    }


}
