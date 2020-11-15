using UnityEngine;
using System.Collections;

public class weaponStats : MonoBehaviour {

	public float damage = 5;
	public float range = 1;
	public float attackSpeed = 1;
	public string weapon;
	public GameObject Char;
	//Its own animation


	void Start () {
		Char = this.transform.parent.gameObject;
	}

	public void UpdateStats() {
		Debug.Log("Hello");
		transform.parent.gameObject.GetComponent<defendArea>().attackDamage = damage;
		transform.parent.gameObject.GetComponent<defendArea>().attackSpeed = attackSpeed;
		transform.parent.gameObject.GetComponent<defendArea>().attackRange = range;
	}

}
