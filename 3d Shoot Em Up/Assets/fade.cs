using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour {

    public bool fadein;
    public Texture2D tex;
    float a;

    Image test;

    public enum Mode {fadeIN, fadeOUT};

    public Mode fadeMode;

	// Use this for initialization
	void Start () {

        // test = GetComponent<UI>();

        //test = GetComponent<Image>();
        

        if(fadeMode == Mode.fadeIN)
        {
            a = 0;
        }
        else if(fadeMode == Mode.fadeOUT)
        {
            a = 1;
        }
  
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if(a >= 0 && fadeMode == Mode.fadeOUT)
        {
            a -= 0.01f;
            //test.color = new Color(test.color.r, test.color.g, test.color.b, a);
        }
        if (a <= 1 && fadeMode == Mode.fadeIN)
        {
            a += 0.01f;
            //test.color = new Color(test.color.r, test.color.g, test.color.b, a);
        }


    }


    public void setFadeOut()
    {
        fadeMode = Mode.fadeOUT;
        a = 1;
    }
    public void setFadeIn()
    {
        fadeMode = Mode.fadeIN;
        a = 0;
    }

    private void OnGUI()
    {
        GUI.color = new Color(0, 0, 0, a);
        GUI.DrawTexture(new Rect(0, 0, 320, 240), tex);
        
        GUI.depth = 0;
    }


}
