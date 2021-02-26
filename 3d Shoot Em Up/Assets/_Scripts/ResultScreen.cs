using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class ResultScreen : MonoBehaviour {
	PlayerData pD;

	public Text textCombo;
	public Text textScore;
	public Text textDamage;

	// Use this for initialization
	void Start () {

		pD = GameObject.Find ("PlayerData").GetComponent<PlayerData> ();

		textCombo.text = "" + pD.getCombo ();
		textScore.text = "" + pD.getScore ();
		textDamage.text = "" + pD.getDamageReceived();


		
	}
	
	// Update is called once per frame
	void Update () {



		
	}
}
