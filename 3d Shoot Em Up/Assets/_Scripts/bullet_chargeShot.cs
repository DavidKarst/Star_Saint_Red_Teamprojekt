using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_chargeShot : MonoBehaviour {

    public int speed;

    public crosshair c;

    public ParticleSystem ps;

    Vector3 start;
    Vector3 normal;
    Vector3 targetDir;

    public Enemy e;

    // Use this for initialization
    void Start () {

        start = transform.position;
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 200;

        Physics.IgnoreCollision(GetComponent<SphereCollider>(), GetComponent<SphereCollider>(), true);

    }
	
	// Update is called once per frame
	void Update () {

        if ((start - transform.position).magnitude > 180)
        {

            //Instantiate(ps, transform.position, transform.rotation);
            //Destroy(gameObject);

        }


        targetDir = new Vector3(e.transform.position.x, e.transform.position.y, e.transform.position.z);

        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 200;

        transform.LookAt(e.transform.position);



    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
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
            other.gameObject.GetComponent<Enemy>().subractHealth(200);
            other.GetComponent<Enemy>().flash();
        }
        if (other.gameObject.tag == "enemyBoss")
        {
            Destroy(gameObject);
            Instantiate(ps, transform.position, transform.rotation);
            other.gameObject.GetComponent<Enemy>().subractHealth(200);
            other.GetComponent<Enemy>().flash();
        }
    }

    public void setEnemy(Enemy e)
    {
        this.e = e;
    }

}
