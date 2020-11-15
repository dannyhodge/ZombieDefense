using UnityEngine;
using System.Collections;

public class textPos : MonoBehaviour {

	public string name = "John";
	public Transform Char;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Char.position;
		this.transform.rotation = Char.rotation;
	}
}
