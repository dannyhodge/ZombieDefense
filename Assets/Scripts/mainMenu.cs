using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public GUISkin menuSkin;
	public bool chooseLevel = false;



	void OnGUI() {

		GUI.skin = menuSkin;

		GUILayout.BeginArea(new Rect((Screen.width/2) - 100, (Screen.height - (Screen.height - 200)), 100, 800));
	

		if(GUILayout.Button("Play")) {
			chooseLevel = true;
		}
		GUILayout.EndArea();



		GUILayout.BeginArea(new Rect((Screen.width/2) + 50, (Screen.height - (Screen.height - 200)), 100, 800));
		if(chooseLevel) {

		if(GUILayout.Button("Level 1")){ 
			Application.LoadLevel(1);
		}
		}

		GUILayout.EndArea();

	}


}
