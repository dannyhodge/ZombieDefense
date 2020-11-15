using UnityEngine;
using System.Collections;

public class movepointColliders : MonoBehaviour {

void OnTriggerEnter2D(Collider2D coll) {
		if(coll.tag == "Player") {
			if(this.tag == "rightbump") {
				if(coll.GetComponent<pathfinder>().moveLeft == true || coll.GetComponent<pathfinder>().moveUp == true || coll.GetComponent<pathfinder>().moveDown == true) {
				this.GetComponent<Collider2D>().enabled = false;
				}
			}

			if(this.tag == "leftbump") {
				if(coll.GetComponent<pathfinder>().moveRight == true || coll.GetComponent<pathfinder>().moveUp == true || coll.GetComponent<pathfinder>().moveDown == true) {
					this.GetComponent<Collider2D>().enabled = false;
				}
			}

			if(this.tag == "upbump") {
				if(coll.GetComponent<pathfinder>().moveLeft == true || coll.GetComponent<pathfinder>().moveRight == true || coll.GetComponent<pathfinder>().moveDown == true) {
					this.GetComponent<Collider2D>().enabled = false;
				}
			}

			if(this.tag == "downbump") {
				if(coll.GetComponent<pathfinder>().moveLeft == true || coll.GetComponent<pathfinder>().moveUp == true || coll.GetComponent<pathfinder>().moveRight == true) {
					this.GetComponent<Collider2D>().enabled = false;
				}
			}
		}
	}
}

