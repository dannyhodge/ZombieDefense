﻿using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	public float camSpeed = 0.2f;
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.up * camSpeed);
		}

		if(Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector3.down * camSpeed);
		}

		if(Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.left * camSpeed);
		}

		if(Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.right * camSpeed);
		}
	}
}