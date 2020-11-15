using UnityEngine;
using System.Collections;

public class scoutArea : MonoBehaviour {

	public float scoutTime = 60.0f;
	public float timer = 0.0f;
	public bool scoutNow = false;
	public bool scouting = false;
	public bool firstPoint = false;
	public bool secondPoint = false;
	public GameObject script;
	public GameObject scout;
	public GameObject scoutreturn;
	public GameObject firstpoint;
	public float maxDistance = 0.10f;
	public float scoutBuffer = 0.20f;
	public float moveSpeed = 5.0f;

	void Start() {
		timer = scoutTime;
	}

	void Update () {
	if(scouting == true) {
			if(scoutNow == true) {
				if(firstPoint == false) {
				Vector3 direction = firstpoint.transform.position - this.transform.position;
				
				float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
				
				this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				
				if(Vector3.Distance(this.transform.position, firstpoint.transform.position) > maxDistance) {
					transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
				}

					if(Vector3.Distance(this.transform.position, firstpoint.transform.position) <= maxDistance) {
						firstPoint = true;
					}


				}

			}
		}

		if(scouting == true) {
			if(scoutNow == true) {
				if(firstPoint == true) {
					if(secondPoint == false) {
					Vector3 direction = scoutreturn.transform.position - this.transform.position;
					
					float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
					
					this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
					
					if(Vector3.Distance(this.transform.position, scoutreturn.transform.position) > maxDistance) {
						transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
					}
					
					if(Vector3.Distance(this.transform.position, scoutreturn.transform.position) <= maxDistance) {
					secondPoint = true;
					}

				}
				}
			}
		}

		if(scouting==true) {
		if(scoutNow == true) {
			if(firstPoint == true) {
					if(secondPoint == true) {
			timer -= Time.deltaTime;

			Vector3 direction = scout.transform.position - this.transform.position;
			
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
			
			this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			if(Vector3.Distance(this.transform.position, scout.transform.position) > maxDistance) {
				transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
			}


	    	if(Vector3.Distance(this.transform.position, scout.transform.position) <= maxDistance) {
				if(timer <= 0) {
				
		
			


			}
			}

		}
		}
			}



		if(timer <= 0) {
			scoutNow = false;
			
		}

			if(scoutNow == false) {

				if(secondPoint == true) {
					Vector3 direction = scoutreturn.transform.position - this.transform.position;
					
					float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
					
					this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
					
					if(Vector3.Distance(this.transform.position, scoutreturn.transform.position) > maxDistance) {
						transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
					}
					
					if(Vector3.Distance(this.transform.position, scoutreturn.transform.position) <= maxDistance) {
						
						secondPoint = false;

				}
			}
			


				if(secondPoint == false) {

				if(firstPoint == true) {
						Vector3 direction = firstpoint.transform.position - this.transform.position;
						
						float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
						
						this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
						
						if(Vector3.Distance(this.transform.position, firstpoint.transform.position) > maxDistance) {
							transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
						}
						
						if(Vector3.Distance(this.transform.position, firstpoint.transform.position) <= scoutBuffer) {
							
							script.GetComponent<gameMechanics>().supplies += (50.0f * Random.Range(0.5f, 1.0f));
							this.GetComponent<charStats>().health -= (int)(30 * Random.value);
							
							timer = scoutTime;
							scouting = false;
							firstPoint = false;
						}

				
			}
	}
	}
		}



}
}
