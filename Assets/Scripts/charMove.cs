using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour {

	public int currentX;
	public int currentY;

	public int targetX;
	public int targetY;

	public bool moving = false;
	public bool movingLeft = true;

	public float moveSpeed = 5f;
	public GameObject targetWaypoint;
	public GameObject currentWaypoint;
	public bool toWaypoint = false;  //Is the unit at the nearest waypoint? if not, go to it before moving

	public bool inBuilding = false;
	public bool getBackToHouse = false;
	public GameObject frontOfHouse;
	public bool moveUp = false;
	GameObject tile3;
	public bool hitWaypoint = false;


	void Start() {

		tile3 = GameObject.Find("tile3");
	}

	// Update is called once per frame
	void Update () {
		

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Input.GetMouseButtonDown(1)) {
			if(GetComponent<scavenge>().Scavenge == false && GetComponent<scavenge>().goBack == false) {
			if(GetComponent<charStats>().thisActive) {
		if (Physics.Raycast(ray, out hit))
		{
			if(hit.collider.gameObject.tag == "Tile") {
						if(inBuilding == false) {

							if(GetComponent<defendArea>().defend) {
								GetComponent<defendArea>().goBack = true;
							}
							else {
								if(moveUp) {

								}
								else {
								getBackToHouse = true;
								}
							}

						}

				targetWaypoint = hit.collider.gameObject;
				targetX = hit.collider.gameObject.GetComponent<tileData>().x;
				targetY = hit.collider.gameObject.GetComponent<tileData>().y;

					toWaypoint = true;
				moving = false;
				movingLeft = false;
						if(GetComponent<defendArea>().goBack == false) {
				GetComponent<defendArea>().defend = false;
						
						}
			}

		}
		}
			}
		}

		if(targetWaypoint != null && getBackToHouse == false && moveUp == false && GetComponent<defendArea>().goBack == false) {

		ToWaypoint();
		MoveSideways();
		MoveVertically();

		}
	
		if(getBackToHouse) {
			GetBack();
		}


		if(currentX == targetX && currentY == targetY) {
			moving = false;
		
		}

		if(moveUp) {

			if(Vector3.Distance(transform.position, tile3.transform.position) > 2f) {

				Vector3 vectorToTarget = tile3.transform.position - transform.position;
				float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
				Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * moveSpeed * 2);

				transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
			}

			if(Vector3.Distance(transform.position, tile3.transform.position) <= 2f) {

				moveUp = false;
				getBackToHouse = false;


			}
		}


		}



	public void GetBack() {
		//Debug.Log("GetBack");
		if(Vector3.Distance(transform.position, frontOfHouse.transform.position) > 2f) {

			Vector3 vectorToTarget = frontOfHouse.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * moveSpeed * 2);

			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		}

		if(Vector3.Distance(transform.position, frontOfHouse.transform.position) <= 2f) {

			moveUp = true;
			if(GetComponent<scavenge>().Scavenge == false) {
			getBackToHouse = false;
				currentWaypoint = tile3;
			}
		}

	}
		

	public void ToWaypoint() {



		if(toWaypoint) {
		if(Vector3.Distance(transform.position, currentWaypoint.transform.position) > 2f) {

			Vector3 vectorToTarget = currentWaypoint.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * moveSpeed * 2);

			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		}

		if(Vector3.Distance(transform.position, currentWaypoint.transform.position) <= 2f) {
			
			//At waypoint. Now, go left/right
				hitWaypoint = true;
			if(currentX != targetX) {
				movingLeft = true;
				moving = false;
			}
			else if(currentY != targetY) {
				moving = true;
				movingLeft = false;
			}
				toWaypoint = false;


		}
		}
	}

	public void MoveSideways() {

	//	Debug.Log("MovingSidewayas");
		if(movingLeft) {
			hitWaypoint = false;
				Vector3 temp = new Vector3();
				temp.x =  targetWaypoint.transform.position.x;
				temp.y = transform.position.y;
				temp.z = 0;

				Vector3 vectorToTarget = temp - transform.position;
				float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * moveSpeed * 2);
		       	transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		}

	}


	public void MoveVertically() {
		//Debug.Log("Moving Verttically");
		if(moving) {
			hitWaypoint = false;
			Vector3 temp = new Vector3();
			temp.x = transform.position.x;
			temp.y = targetWaypoint.transform.position.y;
			temp.z = 0;

			Vector3 vectorToTarget = temp - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;


			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * moveSpeed * 2);


			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		}
	}


	void OnTriggerEnter(Collider coll) {

		if(coll.gameObject.tag == "Tile") {
			currentX = coll.gameObject.GetComponent<tileData>().x;
			currentY = coll.gameObject.GetComponent<tileData>().y;
			currentWaypoint = coll.GetComponent<Collider>().gameObject.transform.GetChild(0).gameObject;

			movingLeft = false;
			moving = false;
			toWaypoint = true;

		}

	}

	void OnTriggerStay(Collider collStay) {

		if(collStay.gameObject.tag == "Tile") {
			inBuilding = true;
		}

	}

	void OnTriggerExit(Collider collLeave) {

		if(collLeave.gameObject.tag == "Tile") {
			inBuilding = false;

		}

	}
		
}
