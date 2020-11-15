using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class gameMechanics : MonoBehaviour {


	public GameObject activeChar; 

	public float supplies = 100;
	public float food = 0;
	public float itemParts = 0;
	public float buildingParts = 20f;
	public float researchPoints = 0;

	public int foodNum;
	public int suppliesNum;
	public int itemPartsNum;
	public int bpNum;
	public int rpNum;

	public bool play = true;
	public bool speedUp = false;

	public float timeTimer = 0;
	public int time = 0;
	public int day = 0;
	public int month = 0;
	public int year = 0;

	public GameObject timeUI;
	public GameObject dateUI;

	public GameObject guiFood;
	public GameObject guiItems;
	public GameObject guiSupplies;
	public GameObject guiRP;

	public GameObject guiStore;
	public float orthographicSizeMin = 5f;
	public float orthographicSizeMax = 10f;

	public GameObject buildtemp;

	public Camera camera;

	public GameObject playerName;
	public GameObject playerHealth;
	public GameObject playerHunger;
	public GameObject playerCombat;
	public GameObject playerEngineering;
	public GameObject playerCooking;
	public GameObject playerScavenging;
	public GameObject playerHealing;


	public GameObject char1Button;
	public GameObject char2Button;
	public GameObject char3Button;
	public GameObject char4Button;
	public GameObject char5Button;
	public GameObject char6Button;

	public bool weaponsShowing = false;
	public GameObject buyWeaponsUI;

	public bool techTreeShowing = false;
	public GameObject techTreeUI;


	public int activeCharNumber = 0;
	public List<GameObject> survivors = new List<GameObject>();

	public void Start() {
		survivors.Add(GameObject.Find("Char1"));
		survivors.Add(GameObject.Find("Char2"));
		survivors.Add(GameObject.Find("Char3"));
	}


	public void StoreOpen () {
		if(guiStore.activeInHierarchy == false) {
		guiStore.SetActive(true);
		}
		else {
			guiStore.SetActive(false);
		}
	}

	void Update () {

		activeCharNumber = survivors.IndexOf(activeChar);


		guiFood.GetComponent<Text>().text = "" + foodNum;
		guiItems.GetComponent<Text>().text = "" + itemPartsNum;
		guiSupplies.GetComponent<Text>().text = "" + suppliesNum;
		guiRP.GetComponent<Text>().text = "" + rpNum;

		foodNum = (int)food;
		suppliesNum = (int)supplies;
		itemPartsNum = (int)itemParts;
		bpNum = (int)buildingParts;
		rpNum = (int)researchPoints;

		timeTimer += Time.deltaTime;

		//6 mins per day

		if(timeTimer >= 33f) {
			time++;
			timeTimer = 0f;
		}
		if(time == 24) {

			day++;
			time = 0;
		}

		dateUI.GetComponent<Text>().text = day + "/09/2072";
		timeUI.GetComponent<Text>().text = time + ":00";


			playerName.GetComponent<Text>().text = survivors[activeCharNumber].GetComponent<charStats>().charName;
		playerHealth.GetComponent<Text>().text =  "Health: " + survivors[activeCharNumber].GetComponent<charStats>().health;
		playerHunger.GetComponent<Text>().text =  "Hunger: " + survivors[activeCharNumber].GetComponent<charStats>().hunger;

		playerCombat.GetComponent<Text>().text =  "Combat: " + survivors[activeCharNumber].GetComponent<charLevels>().rangedLevel;
		playerEngineering.GetComponent<Text>().text =  "Engineering: " + survivors[activeCharNumber].GetComponent<charLevels>().engineeringLevel;
		playerCooking.GetComponent<Text>().text =  "Cooking: " + survivors[activeCharNumber].GetComponent<charLevels>().cookLevel;
		playerScavenging.GetComponent<Text>().text =  "Scavenging: " + survivors[activeCharNumber].GetComponent<charLevels>().scavengingLevel;
		playerHealing.GetComponent<Text>().text =  "Healing: " + survivors[activeCharNumber].GetComponent<charLevels>().medicalLevel;
		
		if(survivors.Count == 1) {
		char1Button.GetComponent<Text>().text = survivors[0].GetComponent<charStats>().charName;
			char2Button.transform.parent.gameObject.SetActive(false);
			char3Button.transform.parent.gameObject.SetActive(false);
			char4Button.transform.parent.gameObject.SetActive(false);
			char5Button.transform.parent.gameObject.SetActive(false);
			char6Button.transform.parent.gameObject.SetActive(false);
		}
		if(survivors.Count == 2) {
			char1Button.GetComponent<Text>().text = survivors[0].GetComponent<charStats>().charName;
			char2Button.GetComponent<Text>().text = survivors[1].GetComponent<charStats>().charName;
			char3Button.transform.parent.gameObject.SetActive(false);
			char4Button.transform.parent.gameObject.SetActive(false);
			char5Button.transform.parent.gameObject.SetActive(false);
			char6Button.transform.parent.gameObject.SetActive(false);
		}
		if(survivors.Count == 3) {
			char1Button.GetComponent<Text>().text = survivors[0].GetComponent<charStats>().charName;
			char2Button.GetComponent<Text>().text = survivors[1].GetComponent<charStats>().charName;
			char3Button.GetComponent<Text>().text = survivors[2].GetComponent<charStats>().charName;
			char4Button.transform.parent.gameObject.SetActive(false);
			char5Button.transform.parent.gameObject.SetActive(false);
			char6Button.transform.parent.gameObject.SetActive(false);

		}

		if(survivors.Count == 4) {
			char1Button.GetComponent<Text>().text = survivors[0].GetComponent<charStats>().charName;
			char2Button.GetComponent<Text>().text = survivors[1].GetComponent<charStats>().charName;
			char3Button.GetComponent<Text>().text = survivors[2].GetComponent<charStats>().charName;
			char4Button.GetComponent<Text>().text = survivors[3].GetComponent<charStats>().charName;
			char5Button.transform.parent.gameObject.SetActive(false);
			char6Button.transform.parent.gameObject.SetActive(false);
		}

		if(survivors.Count == 5) {
			char1Button.GetComponent<Text>().text = survivors[0].GetComponent<charStats>().charName;
			char2Button.GetComponent<Text>().text = survivors[1].GetComponent<charStats>().charName;
			char3Button.GetComponent<Text>().text = survivors[2].GetComponent<charStats>().charName;
			char4Button.GetComponent<Text>().text = survivors[3].GetComponent<charStats>().charName;
			char5Button.GetComponent<Text>().text = survivors[4].GetComponent<charStats>().charName;
			char6Button.transform.parent.gameObject.SetActive(false);
		}

		if(survivors.Count == 6) {
			char1Button.GetComponent<Text>().text = survivors[0].GetComponent<charStats>().charName;
			char2Button.GetComponent<Text>().text = survivors[1].GetComponent<charStats>().charName;
			char3Button.GetComponent<Text>().text = survivors[2].GetComponent<charStats>().charName;
			char4Button.GetComponent<Text>().text = survivors[3].GetComponent<charStats>().charName;
			char5Button.GetComponent<Text>().text = survivors[4].GetComponent<charStats>().charName;
			char6Button.GetComponent<Text>().text = survivors[5].GetComponent<charStats>().charName;
		}
	



	


		//Left Click
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
	
			if (Physics.Raycast(ray, out hit)) {
				
				GameObject objectHit = hit.collider.gameObject;
				if(objectHit.tag == "Player") {
					if(activeChar != null) {
						activeChar.GetComponent<charStats>().thisActive = false;
					}
					activeChar = objectHit;
					objectHit.GetComponent<charStats>().thisActive = true;
				//	Debug.Log ("Player");
				}
			}
		

		}




		if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward

		{
			Camera.main.orthographicSize++;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // back
		{
			Camera.main.orthographicSize--;
		}
		
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax );


		if(Input.GetKeyDown(KeyCode.Escape)) {
			buildtemp.SetActive(false);
			buildtemp.GetComponent<SpriteRenderer>().enabled = false;
		}
			


	}


	public void HideOrShowWeapons() {
		if(weaponsShowing == true) {
			HideWeapons();
		}
		else {
			BuyWeapons();
		}
	}

	public void BuyWeapons() {
		buyWeaponsUI.SetActive(true);
		weaponsShowing = true;
	}
	public void HideWeapons() {
		buyWeaponsUI.SetActive(false);
		weaponsShowing = false;
	}

	public void HideOrShowTechTree() {
		if(techTreeShowing == true) {
			HideTechTree();
		}
		else {
			ShowTechTree();
		}
	}

	public void ShowTechTree() {
		techTreeUI.SetActive(true);
		techTreeShowing = true;
	}
	public void HideTechTree() {
		techTreeUI.SetActive(false);
		techTreeShowing = false;
	}

	public void SetActive1() {
		activeChar.GetComponent<charStats>().thisActive = false;
		activeChar = survivors[0];
		activeChar.GetComponent<charStats>().thisActive = true;

	}

	public void SetActive2() {
		activeChar.GetComponent<charStats>().thisActive = false;
		activeChar = survivors[1];
		activeChar.GetComponent<charStats>().thisActive = true;
	}

	public void SetActive3() {
		activeChar.GetComponent<charStats>().thisActive = false;
		activeChar = survivors[2];
		activeChar.GetComponent<charStats>().thisActive = true;
	}

	public void SetActive4() {
		activeChar.GetComponent<charStats>().thisActive = false;
		activeChar = survivors[3];
		activeChar.GetComponent<charStats>().thisActive = true;
	}

	public void SetActive5() {
		activeChar.GetComponent<charStats>().thisActive = false;
		activeChar = survivors[4];
		activeChar.GetComponent<charStats>().thisActive = true;
	}

	public void SetActive6() {
		activeChar.GetComponent<charStats>().thisActive = false;
		activeChar = survivors[5];
		activeChar.GetComponent<charStats>().thisActive = true;
	}




	public void Defend() {
		activeChar.GetComponent<defendArea>().defend = true;
		if(	activeChar.GetComponent<charMove>().inBuilding) {
		activeChar.GetComponent<defendArea>().setFrontTile = true;
		}
	}

	public void Scavenge() {
		activeChar.GetComponent<scavenge>().Scavenge = true;
		if(	activeChar.GetComponent<charMove>().inBuilding) {
			activeChar.GetComponent<scavenge>().setFrontTile = true;
		}
		if(activeChar.GetComponent<defendArea>().defend) {
			activeChar.GetComponent<defendArea>().goBack = true;
			activeChar.GetComponent<scavenge>().defending = true;
		}

	}



	public void playpause() {

		if(play == true) {
			play = false;
			Time.timeScale = 0.0f;
			
		}
		else {
			Time.timeScale = 1.0f;
			play = true;
		}
	}

	public void speedup() {
		
		if(speedUp == true) {
			speedUp = false;
			Time.timeScale = 1.0f;
			
		}
		else {
			Time.timeScale = 8.0f;
			speedUp = true;
		}
	}


	public void BuildArmory() {
		buildtemp.SetActive(true);
		buildtemp.GetComponent<buildMove>().typeChosen = "Armory";
	}

	public void BuildClinic() {
		buildtemp.SetActive(true);
		buildtemp.GetComponent<buildMove>().typeChosen = "Clinic";
	}

	public void BuildKitchen() {
		buildtemp.SetActive(true);
		buildtemp.GetComponent<buildMove>().typeChosen = "Kitchen";
	}

	public void BuildEngiBay() {
		buildtemp.SetActive(true);
		buildtemp.GetComponent<buildMove>().typeChosen = "Engi Bay";
	}


	public void BuildLab() {
		buildtemp.SetActive(true);
		buildtemp.GetComponent<buildMove>().typeChosen = "Lab";
	}

}




