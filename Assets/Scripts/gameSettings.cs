using UnityEngine;
using System.Collections;

public class gameSettings : MonoBehaviour {
	

	public GameObject[] chars;
	public GameObject char1;
	public string name1;
	public bool male1;

	public GameObject char2;
	public string name2;
	public bool male2;

	public GameObject char3;
	public string name3;
	public bool male3;
	

	void Awake() {
	
	}
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);

		chars = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

			name1 = char1.GetComponent<charSelection>().name;
			if(char1.GetComponent<charSelection>().male == true) {
				male1 = true;
			}
			else {
				male1 = false;
			}

		
		
			name2 = char2.GetComponent<charSelection>().name;
			if(char2.GetComponent<charSelection>().male == true) {
				male2 = true;
			}
			else {
				male2 = false;
			}

		
	
			name3 = char3.GetComponent<charSelection>().name;
			if(char3.GetComponent<charSelection>().male == true) {
				male3 = true;
			}
			else {
				male3 = false;
			}


	



	}

	void OnGUI() {

		int x = 400;
		int i = 1;

		foreach(GameObject Char in chars) {


			GUILayout.BeginArea(new Rect((Char.transform.position.x * 85) + 850, Screen.height - 140, 70, 100));
			if(GUILayout.Button("Next")) {

				if(Char.GetComponent<charSelection>().male) {
				Char.GetComponent<charSelection>().male = false;
				}
				else{
					Char.GetComponent<charSelection>().male = true;
				}

		

			}
			i += 1;
			x += 120;
			GUILayout.EndArea();
		}


		if(GUILayout.Button("GO!")) {
			Application.LoadLevel(2);
		}

	}
}
