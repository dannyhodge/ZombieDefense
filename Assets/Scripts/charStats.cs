using UnityEngine;
using System.Collections;

public class charStats : MonoBehaviour {

	public Transform nextPos;
	public bool thisActive = false;
	public RaycastHit2D move;
	public GameObject scripts;
	public float moveSpeed = 5.0f;
	public float moveSpeedRec;
	public float maxDistance = 0.1f;
	public bool arrived = false;
	public bool keepMoving = false;
	public int maxHealth;
	public int maxHealthWithArmor;
	public int health;
	public float healthNum;
	public int hunger = 100;
	public float hungerNum;
	public string charName;
	public bool male = true;
	public float moveSpeedStore;

	public GameObject weapon;
	public GameObject weaponStart;
	public GameObject activeUI;
	public Sprite maleSprite;
	public Sprite femaleSprite;
	public Transform nextPosPoint;
	public GameObject armor;

	


	void Awake() {
		moveSpeedRec = moveSpeed;
		health = maxHealth;

		nextPos = transform;
		nextPosPoint = transform;
	//	settings = GameObject.Find("SettingScripts");
	//	if(this.gameObject.name == "Char1") {
	//	male = settings.GetComponent<gameSettings>().male1;
	//		name = settings.GetComponent<gameSettings>().name1;
	//	}
	//	if(this.gameObject.name == "Char2") {
	//		male = settings.GetComponent<gameSettings>().male2;
	//		name = settings.GetComponent<gameSettings>().name2;
	//	}
	//	if(this.gameObject.name == "Char3") {
	//		male = settings.GetComponent<gameSettings>().male3;
	//		name = settings.GetComponent<gameSettings>().name3;
	//	}
	}

	

	


	// Use this for initialization
	void Start () {
		moveSpeedStore = moveSpeed;
		healthNum = health;
		hungerNum = hunger;
		if(male) {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = maleSprite;
		}
		if(male==false) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = femaleSprite;
		}
	}





	// Update is called once per frame
	void Update () {

	

		if(thisActive) {
			activeUI.SetActive(true);
		
		}
				else {
					activeUI.SetActive(false);
		
				}
		if(armor != null) {
		maxHealthWithArmor = maxHealth + armor.GetComponent<armorStats>().addedHealth;
		}
		      
				


		if(nextPos.tag == "Room" ) {
		if(nextPos.gameObject.GetComponent<roomScript>().thisActive == true) {
			nextPos = null;
		}
		}


		hungerNum -= (Time.deltaTime * 0.1f);
		hunger = (int)hungerNum;
		health = (int)healthNum;




			
	
				if(Vector3.Distance(this.transform.position, nextPosPoint.position) <= maxDistance) {
					arrived = true;
					nextPos = transform;
					if(nextPosPoint != transform) {
					nextPosPoint.parent.GetComponent<roomScript>().thisActive = true;
					//INSERT ANIMATION
					}
				}
				
				else {
					arrived = false;
				}
			}
			
		}
	
	


	



