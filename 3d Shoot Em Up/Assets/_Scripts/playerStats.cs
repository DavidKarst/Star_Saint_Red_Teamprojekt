using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class playerStats : MonoBehaviour {


    float health;
    bool hit;
    float hitTime;

	public Text textCombo;
	public Text textScore;
    public Text textHit;
    public Text textHealth;
    // Use this for initialization
    float t;
	public Transform canvas;

	public GameObject healthbar;
	public GameObject healthbarHintergrundSchwarz;
	public GameObject healthbarHintergrundRot;

	public EventSystem eventSystem;
	public Button resume;

	public int playerScore = 0;
	public int playerCombo = 0;
	public int maxCombo = 0;
	int damageReceived = 0;
	bool dead;

	PlayerData pD;


    Color colorTest;
    void Start () {


        health = 100;
        hit = false;
        t = 0;
//		DontDestroyOnLoad (this.playerScore);

        colorTest = GetComponent<MeshRenderer>().material.color;
		pD = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();
    }
	
	// Update is called once per frame
	void Update () {


        //textHealth.text = "" + health;
		textScore.text = "" + playerScore;
		textCombo.text = "" + playerCombo;

		if (playerCombo > pD.getCombo()) {
			//maxCombo = pD.getCombo();
			pD.setCombo (playerCombo);

		}
       
		if(health <= 0 && !dead)
        {
            //Destroy(gameObject);
			canvas.gameObject.SetActive (true);
			healthbar.SetActive (false);
			healthbarHintergrundSchwarz.SetActive (false);
			healthbarHintergrundRot.SetActive (false);
			eventSystem.SetSelectedGameObject (resume.gameObject);
			dead = true;



        }
        if(hit)
        {
            textHit.text = "HIT";
		
			playerCombo = 0;
        }
        if (!hit)
        {
            textHit.text = "NOT HIT";
        }

        if(hitTime < Time.time)
        {
            hit = false;
        }

    }


    public void subtractHealth()
    {
       
        if(!hit)
        {
            hit = true;
            health -= 10;
			damageReceived += 10;
			pD.setDamageReceived (damageReceived);
            print("HIT");
			healthbar.transform.localScale = new Vector3 ((health/100), 1, 1);
           

			hitTime = Time.time + 2.0f;
        }

    }


	public void Restart ()
	{
		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}



	public void Exit ()
	{
		SceneManager.LoadScene("Hauptmenü");

	}

    private void triangleWave(float x)
    {
        float y = (2 / Mathf.PI) * Mathf.Asin(Mathf.Sin(Mathf.PI * x));
        print(y);
        //return y;
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

	public void addscore( int score)
	{
		playerScore += score;
		if(playerScore > pD.getScore())
			pD.setScore (playerScore);

	}

	public void addCombo( int score)
	{
		playerCombo += score;


	}


}

