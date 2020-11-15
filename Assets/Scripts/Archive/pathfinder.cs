using UnityEngine;
using System.Collections;

public class pathfinder : MonoBehaviour {


	public float currRowNum = 1.0f ;
	public float currColNum = 1.0f;
	
	public float targetRowNum = 1.0f;
	public float targetColNum = 1.0f;

	public float moveSpeed = 20.0f;

	public bool moveLeft = false;
	public bool moveRight = false;
	public bool moveUp = false;
	public bool moveDown = false;
	public bool checkX = true;
	public bool checkY = false;
	public bool moveAboveRight = false;
	public bool moveAboveLeft = false;
	public bool checkAbove = false;



	void Update () {

		if(currColNum == targetColNum && currRowNum == targetRowNum) {
			checkY = false;
		}



		
		if(moveAboveRight == true) {
			moveRight = true;
			moveLeft = false;
		}

		if(moveAboveLeft == true) {
			moveLeft = true;
			moveRight = false;
		}

		targetRowNum = this.gameObject.GetComponent<charStats>().nextPos.gameObject.GetComponent<roomScript>().rowNum;
		targetColNum = this.gameObject.GetComponent<charStats>().nextPos.gameObject.GetComponent<roomScript>().colNum;

		if((currColNum == 1 || currColNum == 2 || currColNum == 3) && (targetColNum == 1 || targetColNum == 2 || targetColNum == 3) && (currRowNum != targetRowNum)) {

			moveAboveRight = true;
		}

		if((currColNum == 4 || currColNum == 5 || currColNum == 6) && (targetColNum == 4 || targetColNum == 5 || targetColNum == 6) && (currRowNum != targetRowNum)) {
			
			moveAboveLeft = true;
		}


		if(currColNum == targetColNum) {
			if(moveAboveRight == false) {
			
			moveRight = false;
			}

			if(moveAboveLeft == false) {
				moveLeft = false;
			}

		}

		if(currRowNum == targetRowNum) {
			moveUp = false;
			moveDown = false;

		}

		if(checkX == true) {
			if(targetColNum > currColNum) {
				if(moveAboveRight == false) {
					if(moveAboveLeft == false) {
			moveRight = true;
					}
				}
				}

		else if (targetColNum < currColNum) {
				if(moveAboveLeft == false) {
					if(moveAboveRight == false) {
			moveLeft = true;
					}
				}
		}
		}

		if(checkY == true) {
			if(targetRowNum < currRowNum) {
				moveUp = true;
			}
			else if (targetRowNum > currRowNum) {
				moveDown = true;
			}
	
		}

		if(moveRight == true) {
			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		}

		if(moveLeft == true) {
			transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
		}

		if(moveUp == true) {
			transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
		}
			
		if(moveDown == true) {
			transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
		}

		//On hit rowchanger, make check false then move false
	}
}
