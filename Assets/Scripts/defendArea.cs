using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendArea : MonoBehaviour {


	public bool defend = false;
	public List<GameObject> waypoints = new List<GameObject>();

	public bool setFrontTile = false;
	public bool atFrontTile = false;

	public int currentWaypoint = 0;
	public GameObject currWaypoint;
	public bool goBack = false;

	public bool gotTarget = false;

	public float attackRange = 100f;
	public float attackSpeed = 1f;
	public float attackDamage = 10f;

	public bool inCombat = false;

	public float timer = 0;
	public GameObject currTarget;
	public bool onWayToFront = false;

	public bool flash = false;
	public GameObject shotAnim;
	public float flashTime = 0.2f;
	public float flashTimer = 0f;

	public bool scavenging = false; 

	public bool outside = false;

	void Start () {

		currWaypoint = waypoints[0];


	}


	void Update () {

		if(flash) {
			flashTimer += Time.deltaTime;

			if(flashTimer >= flashTime) {

				shotAnim.SetActive(false);
				flash = false;
				flashTimer = 0;
			}
		}

		if(GetComponent<charMove>().currentX == 2 && GetComponent<charMove>().currentY == 0) {

			if(defend == true &&  GetComponent<charMove>().hitWaypoint == true ) {
				atFrontTile = true;
				GetComponent<charMove>().toWaypoint = false;
			}
		}
		else {
			atFrontTile = false;
		}

		if(defend) {
			if(GetComponent<scavenge>().Scavenge==false && GetComponent<scavenge>().goBack == false ){ 
			DefendArea();
			}
		}

		//if inside building, leave building
		//get to front of building
		//follow waypoints


	}

	public void DefendArea() {

		if(setFrontTile == true) {
			if(GetComponent<charMove>().inBuilding == true) {

				GetComponent<charMove>().targetWaypoint = GameObject.Find("tile3");
				GetComponent<charMove>().targetX = 2;
				GetComponent<charMove>().targetY = 0;

				GetComponent<charMove>().toWaypoint = true;
				GetComponent<charMove>().moving = false;
				GetComponent<charMove>().movingLeft = false;

				onWayToFront = true;


				setFrontTile = false;


			}


		}

		if(atFrontTile) {
			onWayToFront = false;
		}

		if(atFrontTile || (onWayToFront == false && atFrontTile == false)) {
			
			if(gotTarget == false) {


				GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
				float dist = Mathf.Infinity;
			


				foreach(GameObject zombie in zombies) {
					if(Vector3.Distance(transform.position, zombie.transform.position) < dist) {

						dist = Vector3.Distance(transform.position, zombie.transform.position);
						currTarget = zombie;

					}


				}
				if(dist <= attackRange) {
				gotTarget = true;
				currTarget.GetComponent<zombieAI>().attackingMe.Add(gameObject);
				}
			}

			else if (currTarget != null) {   //gottarget

				if(outside) {
					
				AttackZombie(currTarget);
				}



			}
			if(inCombat == false) {
			if(Vector3.Distance(transform.position, currWaypoint.transform.position) <= 1f) {
				if(currentWaypoint >= waypoints.Count-1) {
					currentWaypoint = 0;
					currWaypoint = waypoints[0];
					if(goBack) {

						defend = false;
							if(GetComponent<scavenge>().Scavenge == false) {
						GetComponent<charMove>().getBackToHouse = true;
							}


						goBack = false;

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

	public void AttackZombie(GameObject target) {
		inCombat = true;
		Vector3 vectorToTarget = target.transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * GetComponent<charMove>().moveSpeed * 2);
		timer -= Time.deltaTime;
		if(timer <= 0) {
			shotAnim.SetActive(true);
			flash = true;
			target.GetComponent<zombieAI>().health -= (int)(attackDamage);

			GetComponent<charLevels>().rangedExp += 1f;

		
			timer = attackSpeed;
		}


        	
	}

	public void LevelUpCombatStats(float RangedBoost) {
		attackSpeed = transform.GetChild(2).gameObject.GetComponent<weaponStats>().attackSpeed / RangedBoost;
		attackRange = transform.GetChild(2).gameObject.GetComponent<weaponStats>().range * RangedBoost;
		attackDamage =	transform.GetChild(2).gameObject.GetComponent<weaponStats>().damage *RangedBoost;
	}

	void OnTriggerEnter(Collider coll) {

		if(coll.gameObject.name == "Outside") {

			outside = true;

		}

		if(coll.gameObject.name == "tile3") {
			outside = false;
		}

	}

}
