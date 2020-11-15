using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scavenge : MonoBehaviour {


	public bool Scavenge = false;
	public List<GameObject> waypoints = new List<GameObject>();

	public bool setFrontTile = false;
	public bool atFrontTile = false;

	public int currentWaypoint = 0;
	public GameObject currWaypoint;

	public bool goBack = false;

	public float scavengeTimer = 0f;
	public float scavengeTime = 20f;
	public GameObject scripts;

	public bool defending = false;

	void Start () {

		currWaypoint = waypoints[0];


	}


	void Update () {

		if(GetComponent<charMove>().currentX == 2 && GetComponent<charMove>().currentY == 0) {

			if(Scavenge == true &&  GetComponent<charMove>().hitWaypoint == true ) {
				atFrontTile = true;
				GetComponent<charMove>().toWaypoint = false;
			}
		}
		else {
			atFrontTile = false;
		}

		if(Scavenge) {
	

			if(defending == false) {
				

			ScavengeTime();
			}
		}

		if(GetComponent<charMove>().moveUp) {
			defending = false;
			GetComponent<charMove>().moveUp = false;
		}

		if(goBack) {

			ScavengeReverse();



		}


	}

	public void ScavengeReverse() {



		if(Vector3.Distance(transform.position, currWaypoint.transform.position) <= 1f) {
			if(currentWaypoint <= 0) {


				GetComponent<charMove>().getBackToHouse = true;
				goBack = false;
				scavengeTimer = 0;
				scripts.GetComponent<gameMechanics>().supplies += Random.Range(20, 30);
			}
			else {
				currentWaypoint--;
				currWaypoint = waypoints[currentWaypoint];
			}
		}
		if(Vector3.Distance(transform.position, currWaypoint.transform.position) > 1f) {

			Vector3 vectorToTarget = currWaypoint.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * GetComponent<charMove>().moveSpeed * 2);

			transform.Translate(Vector3.right * Time.deltaTime * GetComponent<charMove>().moveSpeed);

		}


	}


	public void ScavengeTime() {

		if(setFrontTile == true) {
			if(GetComponent<charMove>().inBuilding == true) {

				GetComponent<charMove>().targetWaypoint = GameObject.Find("tile3");
				GetComponent<charMove>().targetX = 2;
				GetComponent<charMove>().targetY = 0;

				GetComponent<charMove>().toWaypoint = true;
				GetComponent<charMove>().moving = false;
				GetComponent<charMove>().movingLeft = false;

				setFrontTile = false;


			}


		}

		if(atFrontTile || (GetComponent<charMove>().targetX != 2 && GetComponent<charMove>().targetX != 0 && atFrontTile == false)) {


			if(Vector3.Distance(transform.position, currWaypoint.transform.position) <= 1f) {
				if(currentWaypoint >= waypoints.Count-1) {
			
					if(scavengeTimer <= scavengeTime) {
					scavengeTimer += Time.deltaTime;
					}
					else {
						currentWaypoint--;
						currWaypoint = waypoints[currentWaypoint];
						goBack = true;

						Scavenge = false;
					}


				}
				else {
					currentWaypoint++;
					currWaypoint = waypoints[currentWaypoint];
				}
			}
			if(Vector3.Distance(transform.position, currWaypoint.transform.position) > 1f) {

				Vector3 vectorToTarget = currWaypoint.transform.position - transform.position;
				float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
				Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * GetComponent<charMove>().moveSpeed * 2);

				transform.Translate(Vector3.right * Time.deltaTime * GetComponent<charMove>().moveSpeed);

			}


		}

	}



}
