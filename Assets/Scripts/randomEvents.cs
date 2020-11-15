using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class randomEvents : MonoBehaviour {



	public bool runEvent = false;
	public bool eventStart = false;
	public string eventType;
	public string eventDescription;
	public float timer = 0;
	public float eventTime = 10.0f;
	public float randomness = 0;
	public GameObject zombieSpawn1;
	public GameObject zombieSpawn2;
	public GameObject zombieSpawn3;
	public GameObject zombieSpawn4;
	public GameObject eventGUI;
	public GameObject eventNameGUI;
	public GameObject eventDescGUI;

	// Use this for initialization
	void Start () {
		timer = eventTime;
	}


	public void Play() {
		eventStart = false;
		runEvent = false;
		Time.timeScale = 1.0f;

	}


	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0) {
			runEvent = true;
		}

		if(eventStart == true) {
			timer = eventTime;
			Time.timeScale = 0f;
		}

		if(runEvent == true) {

			eventGUI.SetActive(true);
			eventNameGUI.GetComponent<Text>().text = eventType;
			eventDescGUI.GetComponent<Text>().text = eventDescription;

			randomness = Random.value;

			if(randomness <= 0.5f) {
				eventType = "Zombie Hoard";
				eventDescription = "A zombie Horde has arrived at your gates. Prepare to defend yourself!";

				zombieSpawn1.GetComponent<zombSpawner>().horde = true;
				eventStart = true;
				runEvent = false;


			}

			if(randomness > 0.5f) {
				eventType = "Disease";
				eventDescription = "A disease has plagued your people. Try to find a cure, and keep your people alive!";
				
				eventStart = true;
				runEvent = false;
			}

				}


	}

}
