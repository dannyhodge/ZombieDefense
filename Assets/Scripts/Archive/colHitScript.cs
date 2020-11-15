using UnityEngine;
using System.Collections;

public class colHitScript : MonoBehaviour {


	public string type = "Col";
	public float rowNum = 1.0f;
	public float colNum = 1.0f;



	void OnTriggerStay2D(Collider2D coll) {



		if(this.type == "Col") {
	 if(coll.tag == "Movement") {

				if(coll.transform.parent.GetComponent<pathfinder>().moveAboveRight == true) {
					coll.transform.parent.GetComponent<pathfinder>().moveRight = true;
				}
				if(coll.transform.parent.GetComponent<pathfinder>().moveAboveLeft == true) {
					coll.transform.parent.GetComponent<pathfinder>().moveLeft = true;
				}

				coll.transform.parent.GetComponent<pathfinder>().currColNum = colNum;
				coll.transform.parent.GetComponent<pathfinder>().checkY = false;

		}
		else {
				coll.transform.parent.GetComponent<pathfinder>().currColNum = colNum;
	}
		}


		if(this.type == "Row") {
			if(coll.tag == "Movement") {

				coll.transform.parent.GetComponent<pathfinder>().currRowNum = rowNum;
				coll.transform.parent.GetComponent<pathfinder>().currColNum = colNum;
				coll.transform.parent.GetComponent<pathfinder>().moveAboveRight = false;
				coll.transform.parent.GetComponent<pathfinder>().moveAboveLeft = false;

				if(coll.transform.parent.GetComponent<pathfinder>().currRowNum != coll.transform.parent.GetComponent<pathfinder>().targetRowNum) {

					coll.transform.parent.GetComponent<pathfinder>().checkX = false;
					coll.transform.parent.GetComponent<pathfinder>().moveLeft = false;
					coll.transform.parent.GetComponent<pathfinder>().moveRight = false;
					coll.transform.parent.GetComponent<pathfinder>().checkY = true;
				}

				else if(coll.transform.parent.GetComponent<pathfinder>().targetRowNum == coll.transform.parent.GetComponent<pathfinder>().currRowNum) {
					coll.transform.parent.GetComponent<pathfinder>().checkX = true;
				}
				
				else if(coll.transform.parent.GetComponent<pathfinder>().targetRowNum > coll.transform.parent.GetComponent<pathfinder>().currRowNum) {
					coll.transform.parent.GetComponent<pathfinder>().checkX = true;
				}

			}
	
			if(coll.tag == "Player") {
				if(coll.transform.parent.GetComponent<pathfinder>().currRowNum == coll.transform.parent.GetComponent<pathfinder>().targetRowNum) {

					coll.transform.parent.GetComponent<pathfinder>().checkX = true;
					coll.transform.parent.GetComponent<pathfinder>().moveUp = false;
					coll.transform.parent.GetComponent<pathfinder>().moveDown = false;
				}
			}

		}

}


}