using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class zombieAI : MonoBehaviour {


	public float maxDistance = 5.0f;
	public float moveSpeed = 1.0f;
	public bool follow = false;
	public GameObject closestFence;
	public GameObject[] fences;
	public bool moveToWaypoint = true;
	public int health = 10;
	public bool dead = false;
	public int attackDamage = 5;
	public float timer = 0;
	public float attackSpeed = 5.0f;
	public float attackRange = 4.0f;

	public float Distance;
	public bool gotTarget = false;

	public GameObject behindMe;
	public bool hasBehind = false;

	public int thisQueueLength = 0;



	public int point1Length;
	public int point2Length;
	public int point3Length;
	public int point4Length;

	public List<GameObject> attackingMe = new List<GameObject>();

	void Awake() {
		timer = attackSpeed;
	}

	void AttackFence() {
		timer -= Time.deltaTime;
		if(timer <= 0) {
			GameObject.Find("_hp").GetComponent<totalHealth>().health -= attackDamage;
			timer = attackSpeed;
		}

	}

	// Update is called once per frame
	void Update () {

		if(dead == true) {
			this.tag = "Dead";
		}

		if(Distance < 1.8 && gotTarget) {
			AttackFence();
		}

		if(health <= 0) {
			if(dead==false) {
			moveSpeed = 0;
			foreach(GameObject Char in attackingMe) {
				Char.GetComponent<defendArea>().currTarget = null;
				Char.GetComponent<defendArea>().gotTarget = false;
				Char.GetComponent<defendArea>().inCombat = false;
			}
	
			if(closestFence.name == "attackpoint1") {
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point1zombie = null;
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point1taken = false;

			}
				if(closestFence.name == "attackpoint1 (1)") {
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point2zombie = null;
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point2taken = false;
			}
				if(closestFence.name == "attackpoint1 (2)") {
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point3zombie = null;
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point3taken = false;
			}
				if(closestFence.name == "attackpoint1 (3)") {
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point4zombie = null;
				closestFence.transform.parent.gameObject.GetComponent<fenceStats>().point4taken = false;
			}
			if(closestFence.tag == "AttackPoint") {
				closestFence.GetComponent<queueLength>().length--;
			}
			dead = true;

				if(hasBehind) {
					behindMe.GetComponent<zombieAI>().closestFence = closestFence;
					behindMe.GetComponent<zombieAI>().gotTarget = false;
				}
		}
		}

		if(dead){
			Destroy (this.gameObject);
		}

		if(follow == true) {

			fences = GameObject.FindGameObjectsWithTag("Fence");
			GameObject closest;
			float distance = Mathf.Infinity;
			Vector3 position = transform.position;

			if(closestFence == null) {
			foreach (GameObject fence in fences) {
				Vector3 diff = fence.transform.position - position;
				float curDistance = diff.sqrMagnitude;
				if (curDistance < distance) {
					closest = fence;
					distance = curDistance;
					closestFence = closest;

				}

			}
			}

			if(gotTarget == false) {

		
				if(closestFence.tag == "Fence"){ 

			if(closestFence.GetComponent<fenceStats>().point1taken == false) {
				closestFence.GetComponent<fenceStats>().point1zombie = gameObject;
				closestFence.GetComponent<fenceStats>().point1taken = true;
				closestFence = closestFence.GetComponent<fenceStats>().attackpoint1;
					gotTarget = true;
						thisQueueLength = 1;
						closestFence.GetComponent<queueLength>().length += 1;
			}
			else if(closestFence.GetComponent<fenceStats>().point2taken == false) {
				closestFence.GetComponent<fenceStats>().point2zombie = gameObject;
				closestFence.GetComponent<fenceStats>().point2taken = true;
				closestFence = closestFence.GetComponent<fenceStats>().attackpoint2;
					gotTarget = true;
						thisQueueLength = 1;
						closestFence.GetComponent<queueLength>().length += 1;
			}
			else if(closestFence.GetComponent<fenceStats>().point3taken == false) {
				closestFence.GetComponent<fenceStats>().point3zombie = gameObject;
				closestFence.GetComponent<fenceStats>().point3taken = true;
				closestFence = closestFence.GetComponent<fenceStats>().attackpoint3;
					gotTarget = true;
						thisQueueLength = 1;
						closestFence.GetComponent<queueLength>().length += 1;
			}
			else if(closestFence.GetComponent<fenceStats>().point4taken == false) {
				closestFence.GetComponent<fenceStats>().point4zombie = gameObject;
				closestFence.GetComponent<fenceStats>().point4taken = true;
				closestFence = closestFence.GetComponent<fenceStats>().attackpoint4; 
					gotTarget = true;
						closestFence.GetComponent<queueLength>().length += 1;
			}

				else {
						int temp = 1;

						 point1Length = closestFence.GetComponent<fenceStats>().attackpoint1.GetComponent<queueLength>().length;
						 point2Length =	closestFence.GetComponent<fenceStats>().attackpoint2.GetComponent<queueLength>().length;
						 point3Length = closestFence.GetComponent<fenceStats>().attackpoint3.GetComponent<queueLength>().length;
						 point4Length = closestFence.GetComponent<fenceStats>().attackpoint4.GetComponent<queueLength>().length;

						if(	point2Length < point1Length) {
							temp = 2;
						}
						if(	point3Length < point2Length) {
							temp = 3;
						}
						if(	point4Length < point3Length) {
							temp = 4;
						}
				


					if(temp==1) {
							closestFence.GetComponent<fenceStats>().attackpoint1.GetComponent<queueLength>().length += 1;
						closestFence = closestFence.GetComponent<fenceStats>().point1zombie;

					}
					if(temp==2) {
							closestFence.GetComponent<fenceStats>().attackpoint2.GetComponent<queueLength>().length += 1;
						closestFence = closestFence.GetComponent<fenceStats>().point2zombie;
				
					}
					if(temp==3) {
							closestFence.GetComponent<fenceStats>().attackpoint3.GetComponent<queueLength>().length += 1;
						closestFence = closestFence.GetComponent<fenceStats>().point3zombie;
						
					}
					if(temp==4) {
							closestFence.GetComponent<fenceStats>().attackpoint4.GetComponent<queueLength>().length += 1;
						closestFence = closestFence.GetComponent<fenceStats>().point4zombie;
						
					}

				}
				}

				if(closestFence.tag == "Zombie") {
		
			
				if(closestFence.GetComponent<zombieAI>().hasBehind == false) {  //We got it! Go to this!
			
						closestFence.GetComponent<zombieAI>().BehindMe(gameObject);
					    closestFence.GetComponent<zombieAI>().hasBehind = true;
						gotTarget = true; 
						thisQueueLength = closestFence.GetComponent<zombieAI>().thisQueueLength + 1;
					}

				else {
						if(gotTarget == false) {
					closestFence = closestFence.GetComponent<zombieAI>().behindMe;

						}
				}

				}

				else {



				}
	


	
	
					

				}
						
					




		   //Move towards closest player
	
			Vector3 direction = closestFence.transform.position - this.transform.position;
			
			// Calculate the angle for that direction
			
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //* Mathf.Atan2;
			
			// Rotate towards position

			this.transform.rotation = Quaternion.AngleAxis((angle), Vector3.forward);
			
			
			if(Vector3.Distance(this.transform.position, closestFence.transform.position) > attackRange) {
				transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);			
				Distance = Vector3.Distance(this.transform.position, closestFence.transform.position);
			}

			else {

				//AttackPlayer();			
			}

		}


	}
	public void BehindMe(GameObject zomb) {
		behindMe = zomb;
	}

		

	
}
