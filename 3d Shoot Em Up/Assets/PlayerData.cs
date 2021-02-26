using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	private int score;
	private int combo;
	private int damageReceived;

	public int getScore()
	{
		return this.score;
	}
		
	public int getCombo () 
	{
		return this.combo;
	}

	public int getDamageReceived ()
	{
		return this.damageReceived;
	}

	public void setScore(int score)
	{
		this.score = score;
	}

	public void setCombo(int combo)
	{
		this.combo = combo;

	}

	public void setDamageReceived(int damage)
	{
		this.damageReceived += damage;
	}






	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
