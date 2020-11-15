using UnityEngine;
using System.Collections;

public class dayMechs : MonoBehaviour {


	public float timer = 0;
	public float hourTime = 30.0f;
	public int hour = 0;
	public int day = 1;
	public float dayMult = 0.1f;
	public float multAddition = 0.05f;
	public GameObject[] zombSpawner;
	
	void Update () {

		timer += Time.deltaTime;

		if(timer >= hourTime) {
			hour += 1;
			timer = 0;
		}

		if(hour == 24) {
			day += 1;
			dayMult += multAddition;
			foreach(GameObject zombSpawn in zombSpawner) {
			zombSpawn.GetComponent<zombSpawner>().spawnTime -= dayMult;
			}
			hour = 0;
		}



	}
}
