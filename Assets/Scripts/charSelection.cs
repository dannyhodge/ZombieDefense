using UnityEngine;
using System.Collections;

public class charSelection : MonoBehaviour {

	public bool male = true;
	public Sprite maleSprite;
	public Sprite femaleSprite;
	public int ID = 1;
	public string Name;
	

	// Update is called once per frame
	void Update () {

		this.transform.name = "Char" + ID;

	if(male) {
			this.GetComponent<SpriteRenderer>().sprite = maleSprite;

		}
		else {

			this.GetComponent<SpriteRenderer>().sprite = femaleSprite;
		}


	}

	void OnGUI() {
		if(ID==1){
		Name = GUI.TextField(new Rect(450, Screen.height - 50, 100, 20), Name);
		}
		if(ID==2){
		Name = GUI.TextField(new Rect(650, Screen.height - 50, 100, 20), Name);
		}
		if(ID==3){
		Name = GUI.TextField(new Rect(850, Screen.height - 50, 100, 20), Name);
		}
		if(ID==4){
		Name = GUI.TextField(new Rect(1050, Screen.height - 50, 100, 20), Name);
		}

	}
}
