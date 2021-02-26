using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;






public class Enemy : MonoBehaviour {

    public playerStats player;

    public float health;

    public enemyBullet eb;

    bool shoot;

    float timeWait;

    public int shootMode;

    int move;

    public float shootWhen;


    public int limit;
    public int limitMax;
    public int distanceMax;
    public float distanceMoved;

    public float t;

    public bool autoMoveX;
    public bool autoMoveY;
    public bool autoMoveZ;
    // Use this for initialization

    float startX;
    float startY;
    float startZ;

    public int speed;

    public int magnitude;
    public float period;

    public float progressShoot;

    float timeCounter = 0;

    Color colorTest;

    public string nextScene;

    public bool rotate;
    public bool rotateY;

    public bool notVisible;

    public triggerNextStage f;

	public Transform canvas;
	public GameObject healthbar;
	public GameObject healthbarSchwarz;
	public GameObject healthbarRot;

	public int enemyScore;
	//public int playerScore = 0;

    void Start()
    {
        shoot = false;
        limit = 0;
		enemyScore = 1000;
        if(shootMode == 2 || shootMode == 3 || shootMode == 4)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        //t = Random.value;


        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;

        if(shootMode != 101)
        {
            colorTest = GetComponent<MeshRenderer>().material.color;
        }

        if(shootMode == 666)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        if (notVisible)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        if (t == 1)
        {
            t = Random.value;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && gameObject.tag == "enemyBoss")
        {
			f.goNext();		
			healthbar.SetActive (false);
			healthbarSchwarz.SetActive (false);
			healthbarRot.SetActive (false);
        }

        if (health <= 0)
        {
			
			player.addCombo (1);
			player.addscore (enemyScore);
            Destroy(gameObject);
        }

        //float dis = Vector3.Distance(gameObject.transform.position, player.transform.position);

        float dis = Mathf.Abs((gameObject.transform.position - player.transform.position).z);

        
        if (dis <= distanceMax && limit < limitMax && shootMode != 99 && shootMode != 33)
        {
            if(timeWait < Time.time)
            {
                if(shootMode == 0)
                    Instantiate(eb, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
                if (shootMode == 1)
                    Instantiate(eb, transform.position, Quaternion.LookRotation(transform.forward));
            
                timeWait = Time.time + 0.2f;
                limit++;
           }


        }
        if (dis <= distanceMax && shootMode == 666)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 28;
            distanceMoved++;

            if(!GetComponent<MeshRenderer>().enabled)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            if (timeWait < Time.time)
            {

                Instantiate(eb, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
                timeWait = Time.time + 2f;
                limit++;

            }
        }

        if(distanceMoved >= 256)
        {
            Destroy(gameObject);
        }


        if (shootMode == 33)
        {
            timeCounter += Time.deltaTime * 2;
            transform.position = new Vector3(Mathf.Cos(timeCounter) * 32 + startX, Mathf.Sin(timeCounter) *16 + startY, transform.position.z);

            if (timeWait < Time.time)
            {
                Instantiate(eb, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
                timeWait = Time.time + 0.05f;
                limit++;
            }
            if(limit >= limitMax)
            {
                timeWait = Time.time + 0.5f;
                limit = 0;
            }
        }
        
        if (dis <= 360 && shootMode == 2 && move == 0)
        {
            move = 1;
            GetComponent<MeshRenderer>().enabled = true;


        }

        if (dis <= 50 && shootMode == 3 && move == 0)
        {
            move = 2;
            GetComponent<MeshRenderer>().enabled = true;


        }
        if (dis <= 50 && shootMode == 4 && move == 0)
        {
            move = 3;
            GetComponent<MeshRenderer>().enabled = true;

        }

        if (move == 1)
        {

            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
        if (move == 2)
        {

            gameObject.GetComponent<Rigidbody>().velocity = -transform.right * 30 + transform.forward * 28;
            if (timeWait < Time.time)
            {

                Instantiate(eb, transform.position, transform.rotation * Quaternion.Euler(0, -180, 0));
                timeWait = Time.time + 0.5f;
                
            }
           
        }

        if (move == 3)
        {

            gameObject.GetComponent<Rigidbody>().velocity = transform.right * 30;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z + 50);
        }

        if(GetComponentInParent<SplineWalker>())
        {
            if(GetComponentInParent<SplineWalker>().getProgress() >= progressShoot && limit < limitMax)
            {
                //Instantiate(eb, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
                if (timeWait < Time.time)
                {
                    if(shootMode == 67)
                    {
                        Instantiate(eb, transform.position, Quaternion.LookRotation(transform.forward));
                    }
                    if(shootMode == 68)
                    {
                        Instantiate(eb, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
                    }

                    limit++;
                    timeWait = Time.time + 0.2f;
                }
            }
        }



        if(autoMoveX)
        {
            float x = triangleWave(t);
            t += 1f * Time.deltaTime;

            transform.position = new Vector3(startX + magnitude*x, transform.position.y, transform.position.z);
        }
        if (autoMoveY)
        {
            float x = triangleWave(t);
            t += 1f * Time.deltaTime;

            transform.position = new Vector3(transform.position.x,startY + magnitude * x, transform.position.z);
        }
        if (autoMoveZ)
        {
            float x = triangleWave(t);
            t += 1f * Time.deltaTime;

            transform.position = new Vector3(transform.position.x, transform.position.y, startZ + magnitude * x);
        }

        if(rotate)
        {
            transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
        }
        if (rotateY)
        {
            transform.Rotate(new Vector3(0, 100 * Time.deltaTime, 0));
        }



    }

    private void OnTriggerEnter(Collider c)
    {

        if (c.tag == "player")
        {
            //print("HIT");
            //Destroy(gameObject);
            c.GetComponent<playerStats>().subtractHealth();
        }

    }


    public void subractHealth(float h)
    {
        health -= h;
		if (gameObject.tag == "enemyBoss")
			healthbar.transform.localScale = new Vector3 ((health/6000), 1, 1);

	
    }

    private float triangleWave(float x)
    {
        float y = (period / Mathf.PI) * Mathf.Asin(Mathf.Sin(Mathf.PI * x));
        return y;
    }

    public void flash()
    {

        GetComponent<MeshRenderer>().material.color = Color.white;
        Invoke("resetColor", 0.1f);

    }

    private void resetColor()
    {
        GetComponent<MeshRenderer>().material.color = colorTest;
    }

    void next()
    {
        SceneManager.LoadScene(nextScene);
    }

}
