using UnityEngine;
using System.Collections;

public class zombSpawner : MonoBehaviour {

	public float timer = 0;
	public float spawnTime = 10.0f;
	public GameObject zombie;
	public float maxSpawnTime = 20f;
	public bool horde = false;


	void Start() {
		spawnTime *= Random.Range(0.5f, 2f);
	}

	void Update() {

		if(horde == true) {
			spawnTime = 5f;
		}
		timer += Time.deltaTime;
		if(timer >= spawnTime) {

			GameObject newZombie = Instantiate(zombie, transform.position, zombie.transform.rotation) as GameObject;

			timer = 0;
			spawnTime = maxSpawnTime;
			spawnTime *= Random.Range(0.4f, 2f);
		}
	}
}
