using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceStats : MonoBehaviour {

	public GameObject attackpoint1;
	public GameObject attackpoint2;
	public GameObject attackpoint3;
	public GameObject attackpoint4;

	public bool point1taken = false;
	public bool point2taken = false;
	public bool point3taken = false;
	public bool point4taken = false;

	public GameObject point1zombie;
	public GameObject point2zombie;
	public GameObject point3zombie;
	public GameObject point4zombie;

	// Use this for initialization
	void Start () {
		attackpoint1 = transform.GetChild(0).gameObject;
		attackpoint2 = transform.GetChild(1).gameObject;
		attackpoint3 = transform.GetChild(2).gameObject;
		attackpoint4 = transform.GetChild(3).gameObject;
	}

}
