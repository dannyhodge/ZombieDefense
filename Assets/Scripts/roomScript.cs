using UnityEngine;
using System.Collections;

public class roomScript : MonoBehaviour {

	public bool thisActive = false;
	public GameObject scripts;
	public string roomType; 
	public float roomLevel = 1;
	public float levelBoostRate;
	public GameObject activeChar;
	public GameObject activeChar2;
	public GameObject activeChar3;
	public GameObject activeChar4;
	public GameObject activeChar5;
	public GameObject leavingChar;

	public int numInRoom = 0;

	public int rowNum = 1;
	public int colNum = 1;

	void Start() {
		scripts = GameObject.Find("_Scripts");
	}

	void Update () {

		levelBoostRate = 1 + (roomLevel/10);


	if(thisActive==true) {
			if(this.roomType == "Kitchen"){
			RunKitchen();
			}

			if(this.roomType == "Armory"){
				RunArmoury();
			}

			if(this.roomType == "Clinic"){
				RunClinic();
			}

		}
	}


	void OnTriggerEnter(Collider collEnter) {
		thisActive = true;
		if(numInRoom == 0) {
		activeChar = collEnter.gameObject;
		}
		else if(numInRoom == 1) {
			activeChar2 = collEnter.gameObject;
		}
		else if(numInRoom == 2) {
			activeChar3 = collEnter.gameObject;
		}
		else if(numInRoom == 3) {
			activeChar4 = collEnter.gameObject;
		}
		else if(numInRoom == 4) {
			activeChar5 = collEnter.gameObject;
		}
		numInRoom++;

	}



	void OnTriggerExit(Collider leaveColl) {
		leavingChar = leaveColl.gameObject;
		numInRoom--;

		if(numInRoom == 0) {
			activeChar = null;
			thisActive = false;
		}
		else if(numInRoom == 1) {
			activeChar2 = null;
		}
		else if(numInRoom == 2) {
			activeChar3 = null;
		}
		else if(numInRoom == 3) {
			activeChar4 = null;
		}
		else if(numInRoom == 4) {
			activeChar5 = null;
		}
	}


	
	void RunKitchen() {
		float boost = 0;
		if(scripts.GetComponent<gameMechanics>().supplies > 0) {

		if(activeChar.tag != "Player") {
		boost = activeChar.transform.parent.GetComponent<charLevels>().cookBoost;
			activeChar.transform.parent.GetComponent<charLevels>().cookExp += (Time.deltaTime / 3);
		}
		if(activeChar.tag == "Player") {
			boost = activeChar.GetComponent<charLevels>().cookBoost;
			activeChar.transform.GetComponent<charLevels>().cookExp += (Time.deltaTime / 3);
		}

		scripts.GetComponent<gameMechanics>().food += ((Time.deltaTime / 10) * levelBoostRate * boost);
		scripts.GetComponent<gameMechanics>().supplies -= (Time.deltaTime / 10);
		}
	}

	void RunArmoury() {
		if(scripts.GetComponent<gameMechanics>().supplies > 0) {
		float boost = 0;
		
		if(activeChar.tag != "Player") {
			boost = activeChar.transform.parent.GetComponent<charLevels>().engineeringBoost;
			activeChar.transform.parent.GetComponent<charLevels>().engineeringExp += (Time.deltaTime / 3);
		}
		if(activeChar.tag == "Player") {
			boost = activeChar.GetComponent<charLevels>().engineeringBoost;
			activeChar.transform.GetComponent<charLevels>().engineeringExp += (Time.deltaTime / 3);
		}
		scripts.GetComponent<gameMechanics>().itemParts += ((Time.deltaTime / 10) * levelBoostRate * boost);
		scripts.GetComponent<gameMechanics>().supplies -= (Time.deltaTime / 10);
		}
	}

	void RunEngiBay() {
		if(scripts.GetComponent<gameMechanics>().supplies > 0) {
			float boost = 0;

	  	boost = activeChar.GetComponent<charLevels>().engineeringBoost;
		activeChar.transform.GetComponent<charLevels>().engineeringExp += (Time.deltaTime / 2);
		
			scripts.GetComponent<gameMechanics>().itemParts += ((Time.deltaTime / 8) * levelBoostRate * boost);
			scripts.GetComponent<gameMechanics>().supplies -= (Time.deltaTime / 10);
		}
	}

	void RunLab() {
		if(scripts.GetComponent<gameMechanics>().supplies > 0) {
			float boost = 0;

			boost = activeChar.GetComponent<charLevels>().engineeringBoost;
			activeChar.transform.GetComponent<charLevels>().engineeringExp += (Time.deltaTime / 1.5f);

			scripts.GetComponent<gameMechanics>().itemParts += ((Time.deltaTime / 7) * levelBoostRate * boost);
			scripts.GetComponent<gameMechanics>().supplies -= (Time.deltaTime / 10);
		}
	}

	void RunClinic() {
		
		float boost = 0;
		if(numInRoom == 1) {
		
		
	
			boost = activeChar.GetComponent<charLevels>().medicalBoost / 2;
			if(activeChar.GetComponent<charStats>().health < activeChar.GetComponent<charStats>().maxHealthWithArmor) {
			activeChar.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
		

		}

		else if(numInRoom == 2)  {
			boost = activeChar.GetComponent<charLevels>().medicalBoost;
			if(activeChar2.GetComponent<charStats>().health < activeChar2.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar2.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
		}
		else if(numInRoom == 3)  {
			Debug.Log("helloo");
			boost = activeChar.GetComponent<charLevels>().medicalBoost;
			if(activeChar2.GetComponent<charStats>().health < activeChar2.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar2.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
			if(activeChar3.GetComponent<charStats>().health < activeChar3.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar3.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
		}
		else if(numInRoom == 4)  {
			boost = activeChar.GetComponent<charLevels>().medicalBoost;
			if(activeChar2.GetComponent<charStats>().health < activeChar2.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar2.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
			if(activeChar3.GetComponent<charStats>().health < activeChar3.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar3.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
			if(activeChar4.GetComponent<charStats>().health < activeChar4.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar4.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
		}
		else if(numInRoom == 5)  {
			boost = activeChar.GetComponent<charLevels>().medicalBoost;
			if(activeChar2.GetComponent<charStats>().health < activeChar2.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar2.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
			if(activeChar3.GetComponent<charStats>().health < activeChar3.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar3.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
			if(activeChar4.GetComponent<charStats>().health < activeChar4.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar4.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
			if(activeChar5.GetComponent<charStats>().health < activeChar5.GetComponent<charStats>().maxHealthWithArmor) {
				activeChar5.gameObject.GetComponent<charStats>().healthNum += ((Time.deltaTime / 5) * boost);
			}
		
		}

	}


}
