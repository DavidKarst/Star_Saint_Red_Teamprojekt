using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float dist = Vector3.Distance(path[currentPoint].position, transform.position);


        transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);
        Vector3 dir = path[currentPoint].position - transform.position;
        Vector3 newLook = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime / 1, 0);

        transform.rotation = Quaternion.LookRotation(newLook);

        //transform.position += dir * Time.deltaTime * speed;

        if(dist <= reachDist)
        {
            currentPoint++;
        }

        if(currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
		
	}

    private void OnDrawGizmos()
    {
        if(path.Length > 0)
        {
            for(int i = 0; i < path.Length; i++)
            {
                if(path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachDist);
                }
            }
        }

    }
}
