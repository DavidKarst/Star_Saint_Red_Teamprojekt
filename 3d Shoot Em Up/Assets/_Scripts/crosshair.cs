using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshair : MonoBehaviour {

    public Transform spaceship;
    public Texture2D tex;
    public Camera cam;

    public GameObject worldob;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // Vector3 mouseopostiob = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(1000);
        //transform.position = new Vector3(mouseopostiob.x, mouseopostiob.y, mouseopostiob.z);

        //RectTransform CanvasRect = Canvas.GetCom
    }

    private void OnGUI()
    {

        //print(Screen.height);
        // print(Screen.width);
        //Vector3 screeposition = Camera.main.WorldToScreenPoint(transform.position);

        if(cam.enabled)
        {
            Vector3 screeposition = Camera.main.WorldToScreenPoint(transform.position);
            screeposition.y = Screen.height - screeposition.y;
            GUI.DrawTexture(new Rect(screeposition.x -8, screeposition.y -8, 16, 16), tex);
            GUI.depth = 1;
        }
        


    }
}
