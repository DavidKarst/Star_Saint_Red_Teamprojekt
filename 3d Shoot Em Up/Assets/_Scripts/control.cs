using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class control : MonoBehaviour
{
    //public lockOn lo;

    public float speedSides;
    public float speedfront;

    public float max;
    public float rotValueVert;
    public float rotValueHor;

    public float rotMax;

    public cameraMovement cam;

    public GameObject rail;

    public GameObject ch;


    bool moveLeft;
    bool moveRight;

    bool moveUp;
    bool moveDown;


    public bullet b;

    float speedh;
    float speedv;

    public Texture2D tex;

    int fireLimit;

    float timeStart;

    float timeWait;

    bool pressed;

    public crosshair c;
    public crosshairLockOn clo;

    public bool controlsOn;

    float chargeShot;
    public Text textChargeShot;

    public bullet_chargeShot b_Cs;

    // Use this for initialization

    float k = 10.02030f;

    public float maxdown;

    public GameObject model;

    float rot = 0;
    bool special;

    float bgn;
    float d;
    float t;
    float chn;

    public Enemy eLock;

	public Transform canvas;
	bool pause = false;

	public EventSystem eventSystem;
	public Button resume;


    void Start()
    {
		//resume.Select();
        moveLeft = false;
        moveRight = false;

        moveUp = true;
        moveDown = true;

        GetComponent<MeshRenderer>().enabled = false;

    }

    // Update is called once per frame






    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + speedv, transform.localPosition.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition = new Vector3(transform.localPosition.x - speedh, transform.localPosition.y, transform.localPosition.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speedv, transform.localPosition.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition = new Vector3(transform.localPosition.x+ speedh, transform.localPosition.y , transform.localPosition.z);
        }
        */


        if (controlsOn)
        {
            float test = transform.localRotation.x / -0.35f;



            float speedv = speedfront * test;

            float test2 = transform.localRotation.y / 0.35f;

            float speedh = speedfront * test2;




            if (transform.localPosition.y >= rail.transform.position.y - maxdown && transform.localPosition.y <= 24)
            {
                transform.localPosition += new Vector3(0, 4, 0) * Time.unscaledDeltaTime * speedv;
            }
            if (transform.localPosition.y <= rail.transform.position.y - maxdown)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, rail.transform.position.y - maxdown, transform.localPosition.z);
            }
            if (transform.localPosition.y >= 24)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 24, transform.localPosition.z);
            }


            if (transform.localPosition.x >= -32 && transform.localPosition.x <= 32)
            {
                transform.localPosition += new Vector3(4, 0, 0) * Time.unscaledDeltaTime * speedh;
            }
            if (transform.localPosition.x > 32)
            {
                transform.localPosition = new Vector3(32, transform.localPosition.y, transform.localPosition.z);
            }
            if (transform.localPosition.x < -32)
            {
                transform.localPosition = new Vector3(-32, transform.localPosition.y, transform.localPosition.z);
            }



            //transform.localPosition += new Vector3(0, 4, 0) * Time.deltaTime * speedv;
            //transform.localPosition += new Vector3(4, 0, 0) * Time.deltaTime * speedh;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotValueVert, rotValueHor, 0), 3 * Time.unscaledDeltaTime);

            if (Input.GetAxis("Left Stick Y") < 0)
            {
                Quaternion originalRot = transform.localRotation;

                rotValueVert = -rotMax * Input.GetAxis("Left Stick Y");
                moveDown = true;
            }
            else
            {
                moveDown = false;
            }
            if (Input.GetAxis("Left Stick Y") > 0)
            {
                Quaternion originalRot = transform.localRotation;

                rotValueVert = rotMax * -Input.GetAxis("Left Stick Y");
                moveUp = true;
            }
            else
            {
                moveUp = false;
            }

            if (!moveUp && !moveDown)
            {
                //rotValueVert = Mathf.Lerp(rotValueVert, 0, 6 * Time.deltaTime);
                rotValueVert = 0;
            }
            if (Input.GetAxis("Left Stick X") < 0)
            {
                Quaternion originalRot = transform.localRotation;

                rotValueHor = -rotMax * -Input.GetAxis("Left Stick X");
                moveLeft = true;
            }
            else
            {
                moveLeft = false;
            }
            if (Input.GetAxis("Left Stick X") > 0)
            {
                Quaternion originalRot = transform.localRotation;

                rotValueHor = rotMax * Input.GetAxis("Left Stick X");
                moveRight = true;
            }
            else
            {
                moveRight = false;
            }

            if (moveLeft == false && moveRight == false)
            {
                //rotValueHor = Mathf.Lerp(rotValueHor, 0, 6 * Time.deltaTime);
                rotValueHor = 0;
            }

            if (Input.GetButtonDown("A") && Time.time > timeWait)
            {
                if (pressed != true)
                {
                    pressed = true;
                }
            }

            if (Input.GetAxis("Left Trigger") >= 0.5 && !special)
            {
                special = true;
                bgn = 0;
                d = 0.4f;
                t = 0;
                chn = 360 - bgn;
                //print(d);
               // print(Time.time);
                model.transform.localRotation = Quaternion.Euler(0, 0, 0);

            }


			if (Input.GetButtonDown ("Start")&& !pause) 
			{

				canvas.gameObject.SetActive (true);
				pause = true;
				//yield return null;
				eventSystem.SetSelectedGameObject (null);
				eventSystem.SetSelectedGameObject (resume.gameObject);
				//SelectContinueButtonLater ();	
				//resume.Select();
				//resume.OnSubmit ();
				Time.timeScale = 0.0f;
	

			}
			else if (Input.GetButtonDown("Start") && pause)
			{
				Time.timeScale = 1.0f;
				pause = false;
				canvas.gameObject.SetActive (false);
			}




            if(t < d && special)
            {
                //model.transform.Rotate(0,0,tweenTest(Time.time, bgn, chn, d));

                model.transform.localRotation = Quaternion.Euler(0, 0, tweenTest(t, bgn, chn, d));
                //print(tweenTest(Time.time, b, c, d));
                //print("test");
                t = t + Time.unscaledDeltaTime;
            }
            if(t >= d && special)
            {
                //print("END");
                //print(d);
                model.transform.localRotation = Quaternion.Euler(0, 0, 0);
                print(Time.time);
                special = false;
            }
           // model.transform.Rotate(0, 0, rot);


            if(Input.GetButton("A") && clo.getEnemy() == null && chargeShot == 100)
            {
                Physics.Raycast(transform.position, transform.forward, 64.0f);
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    // print(hit.point);

                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    
                    if(hit.transform.gameObject.tag == "enemy")
                    {
                        clo.setEnemy(hit.transform.gameObject.GetComponent<Enemy>());
                    }
                    
                }
            }
            else if(!Input.GetButton("A") && clo.getEnemy() != null)
            {
                
                bullet_chargeShot cn = Instantiate(b_Cs, transform.position, transform.rotation);
                cn.setEnemy(clo.getEnemy());
                clo.setEnemy(null);
            }

            if(Input.GetButton("A") && chargeShot < 100)
            {
                chargeShot += 2.5f;
            }
            if(Input.GetButtonUp("A"))
            {
                chargeShot = 0;
            }

            textChargeShot.text = "CS: " + chargeShot;



            if (pressed == true && fireLimit < 4)
            {
                bullet bn = Instantiate(b, transform.position, transform.rotation);
                fireLimit++;
            }


            if (Time.time > timeWait && fireLimit >= 4)
            {
                timeWait = Time.time + 0.05f;
                fireLimit = 0;
                pressed = false;
            }
        }



        //bn.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * 250;
        // bn.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(bn.GetComponent<Rigidbody>().velocity);


        //print((c.transform.position - transform.position).magnitude);


    }
	public void Pause ()
	{
		Time.timeScale = 1.0f;
		pause = false;
		canvas.gameObject.SetActive (false);
	}

	IEnumerator SelectContinueButtonLater(){
		eventSystem.SetSelectedGameObject (null);
		yield return null;
		eventSystem.SetSelectedGameObject (resume.gameObject);
	}

	public void Exit ()
	{
		SceneManager.LoadScene("Hauptmenü");
		Time.timeScale = 1.0f;
	}




    public void controlSwitch()
    {
        controlsOn = !controlsOn;
    }

    void resetSpeed()
    {
        speedfront = 8;
    }


    float tweenTest(float t, float b, float c, float d)
    {
        return c*t/d +b;
    }

    public Enemy getEnemy()
    {
        return eLock;
    }


}
