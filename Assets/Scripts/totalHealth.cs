using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class totalHealth : MonoBehaviour {

	public double maxHealth = 48.0;
	public double health;
	public Sprite[] healthSprites = new Sprite[ 24 ]; 

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {


		GameObject hpBar = GameObject.FindGameObjectWithTag("hp");
		
		double hpDiff = maxHealth / healthSprites.Length;
		Debug.Log(hpDiff);
		double tempArrayVal = (health / hpDiff) - 1.0;
		Debug.Log(tempArrayVal);
		int arrayVal = Convert.ToInt32(tempArrayVal);
		Debug.Log(arrayVal);
		hpBar.GetComponent<Image>().sprite = healthSprites[arrayVal];

	}
}
