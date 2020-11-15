using UnityEngine;
using System.Collections;

public class buyItems : MonoBehaviour {

	public GameObject armory;
	public GameObject kitchen;
	public GameObject clinic;
	public GameObject engibay;
	public GameObject lab;

	public bool buildingsShowing;



	public void HideOrShow() {
		if(buildingsShowing == true) {
			HideBuildings();
		}
		else {
			ShowBuildings();
		}
	}

	public void ShowBuildings() {


			buildingsShowing = true;
			armory.SetActive(true);
			kitchen.gameObject.SetActive(true);
			clinic.gameObject.SetActive(true);
	    	engibay.SetActive(true);
	    	lab.SetActive(true);


	}

	public void HideBuildings() {

		buildingsShowing = false;
		armory.SetActive(false);
		kitchen.SetActive(false);
		clinic.SetActive(false);
		engibay.SetActive(false);
		lab.SetActive(false);
	}

}
