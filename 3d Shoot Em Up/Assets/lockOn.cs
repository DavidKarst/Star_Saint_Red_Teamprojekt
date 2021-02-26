using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockOn : MonoBehaviour {


    public Enemy e;
    public control player;

    public bool on;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider c)
    {

        if (c.tag == "enemy" && on )
        {
            //print("HIT");
            //Destroy(gameObject);
            e = c.gameObject.GetComponent<Enemy>();
        }

    }

    public Enemy getEnemy()
    {
        if(e != null)
        {
            return e;
        }
        else
        {
            return null;
        }
    }

    public void setOn(bool b)
    {
        on = b;   
    }
    public bool getOn()
    {
        return on;
    }

    public void setEnemy()
    {
        e = null;
    }
}
