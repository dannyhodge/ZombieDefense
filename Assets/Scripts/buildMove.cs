using UnityEngine;
using System.Collections;

public class buildMove : MonoBehaviour {

	public bool canPlace = true;
	Vector3 newPosition;
	public Sprite red;
	public Sprite green;
	public string typeChosen = "Armory";
	public GameObject armory;
	public GameObject kitchen;
	public GameObject clinic;
	public GameObject engibay;
	public GameObject lab;
	public GameObject scripts;

	public int buildingCost = 60;

	public bool freeSpace = true;
	public bool onTile = true;

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		freeSpace = true;
		onTile = false;

		RaycastHit[] hits;
		hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity);
		RaycastHit hit = hits[0];


		for (int i = 0; i < hits.Length; i++)
		{
			
			Debug.Log(hit.collider.name);
			if(hits.Length > 0) {
		
				if(hits[i].collider.gameObject.tag == "Room") {
				
					freeSpace = false;

	
				}

				if(hits[i].collider.tag == "Tile") {
					onTile = true;
					hit = hits[i];
				}



			}
		


		}

	
		if(freeSpace && onTile) {
			GetComponent<SpriteRenderer>().enabled = true;
			canPlace = true;
			newPosition = hit.transform.position;
			newPosition.z = -0.01f;
			transform.position = newPosition;

		}
		else {
			canPlace = false;
			GetComponent<SpriteRenderer>().enabled = false;
		}


		if(Input.GetMouseButtonDown(0)) {
			if(scripts.GetComponent<gameMechanics>().supplies >= buildingCost) {
			if(canPlace) {
				GetComponent<SpriteRenderer>().enabled = false;
				gameObject.SetActive(false);
	        	if(typeChosen == "Kitchen") {
				GameObject building = Instantiate(kitchen, transform.position, transform.rotation) as GameObject;
				}
				if(typeChosen == "Clinic") {
					GameObject building = Instantiate(clinic, transform.position, transform.rotation) as GameObject;
				}
				if(typeChosen == "Armory") {
					GameObject building = Instantiate(armory, transform.position, transform.rotation) as GameObject;
				}
				if(typeChosen == "Engi Bay") {
					GameObject building = Instantiate(engibay, transform.position, transform.rotation) as GameObject;
				}
				if(typeChosen == "Lab") {
					GameObject building = Instantiate(lab, transform.position, transform.rotation) as GameObject;
				}

					scripts.GetComponent<gameMechanics>().buildingParts -= buildingCost;
			}
		}
		}
			
	}


	void OnTriggerStay2D(Collider2D coll) {
		
		if(coll.gameObject.tag == "Bound" || coll.gameObject.tag == "Room") {
		//	Debug.Log(coll.name);
	//		GetComponent<SpriteRenderer>().sprite = red;

	//		canPlace = false;
		}


	}

	void OnTriggerExit2D(Collider2D col) {

		if(col.gameObject.tag == "Bound" || col.gameObject.tag == "Room") {
	//			GetComponent<SpriteRenderer>().sprite = green;
	//		canPlace = true;
			}

	}
}
