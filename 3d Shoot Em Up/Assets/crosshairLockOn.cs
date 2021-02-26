using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshairLockOn : MonoBehaviour {

    Enemy e;
    public Texture2D tex;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {

        //print(Screen.height);
        // print(Screen.width);
        //Vector3 screeposition = Camera.main.WorldToScreenPoint(transform.position);
        if(e != null)
        {
            Vector3 screeposition = Camera.main.WorldToScreenPoint(e.transform.position);
            screeposition.y = Screen.height - screeposition.y;
            GUI.DrawTexture(new Rect(screeposition.x - 8, screeposition.y - 8, 16, 16), tex);
            GUI.depth = 1;
   
        }



    }

    public void setEnemy(Enemy e)
    {
        this.e = e;
    }

    public Enemy getEnemy()
    {
        return e;
    }
}
