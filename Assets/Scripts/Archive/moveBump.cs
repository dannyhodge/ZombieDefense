using UnityEngine;
using System.Collections;

public class moveBump : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.tag == "Trigger") {
			if(this.transform.parent.GetComponent<pathfinder>().moveDown == true) {
			this.transform.parent.transform.Translate(Vector3.down * 0.2f);
			}

			if(this.transform.parent.GetComponent<pathfinder>().moveUp == true) {
				this.transform.parent.transform.Translate(Vector3.up * 0.2f);
			}


		}
	}

}
