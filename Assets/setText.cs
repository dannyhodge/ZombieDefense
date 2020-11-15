using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setText : MonoBehaviour {


	void Update () {
		//MAKE SURE CHARACTERS CAN'T HAVE SAME NAME
		this.GetComponent<Text>().text = this.transform.parent.name;
	}

}
