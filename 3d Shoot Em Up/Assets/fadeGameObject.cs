using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeGameObject : MonoBehaviour {

    Color colorTest;

    public GameObject player;


    // Use this for initialization
    void Start () {
        //colorTest = GetComponent<MeshRenderer>().material.color;

        GetComponent<MeshRenderer>().enabled = false;

        //GetComponent<MeshRenderer>().material.SetColor("_TintColor", new Color(0, 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {

        float dis = Mathf.Abs((gameObject.transform.position - player.transform.position).z);

        if (dis <= 80 && GetComponent<MeshRenderer>().enabled == false)
        {
            GetComponent<MeshRenderer>().enabled = true;

        }
    }
}
