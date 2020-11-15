using UnityEngine;
using System.Collections;

public class addRoom : MonoBehaviour {

	public GameObject food;
	public GameObject engi;
	public GameObject armi;
	public GameObject room;
	public Sprite Sfood;
	public Sprite Sengi;
	public Sprite Sarmi;
	public GameObject scripts;
	public bool allActive = false;

	public int buildingCost = 60;
 
	void Update() {
		if(allActive == true) {
		food.SetActive(true);
		engi.SetActive (true);
		armi.SetActive (true);
		}

		else {
			food.SetActive(false);
			engi.SetActive (false);
			armi.SetActive (false);
		}
	}


	public void newGUI() {
		if(allActive == false) {
		allActive = true;
		}
		else {
			allActive = false;
	
		}
	}

	public void upgradeFood() {
		room.GetComponent<roomScript>().roomType = "Kitchen";
		room.GetComponent<SpriteRenderer>().sprite = Sfood;
		scripts.GetComponent<gameMechanics>().supplies -= 10.0f;
		allActive = false;
		this.gameObject.SetActive(false);              
	//	scripts.GetComponent<gameMechanics>().suppliesNum -= buildingCost;
	//	Debug.Log("Helloooo");
	}

	public void upgradeArmor() {
		room.GetComponent<roomScript>().roomType = "Armory";
		room.GetComponent<SpriteRenderer>().sprite = Sarmi;
		scripts.GetComponent<gameMechanics>().supplies -= 10.0f;
		allActive = false;
		this.gameObject.SetActive(false);

	}

	public void upgradeBed() {
		room.GetComponent<roomScript>().roomType = "Bedroom";
		room.GetComponent<SpriteRenderer>().sprite = Sengi;
		scripts.GetComponent<gameMechanics>().supplies -= 10.0f;
		allActive = false;
		this.gameObject.SetActive(false);
	//	scripts.GetComponent<gameMechanics>().suppliesNum -= buildingCost;
	}



}
