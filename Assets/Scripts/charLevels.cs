using UnityEngine;
using System.Collections;

public class charLevels : MonoBehaviour {

	public float rangedLevel = 1;
	public float rangedLevelReq = 100;
	public float rangedExp = 0;
	public float rangedBoost = 1;

	public float medicalLevel = 1;
	public float medicalLevelReq = 100;
	public float medicalExp = 0;
	public float medicalBoost = 1;

	public float engineeringLevel = 1;
	public float engineeringLevelReq = 100;
	public float engineeringExp = 0;
	public float engineeringBoost = 1;

	public float scavengingLevel = 1;
	public float scavengingLevelReq = 100;
	public float scavengingExp = 0;
	public float scavengingBoost = 1;

	public float cookLevel = 1;
	public float cookLevelReq = 100;
	public float cookExp = 0;
	public float cookBoost = 1;


	void Start () {

		this.GetComponent<charStats>().enabled = true;

	}

	void Update () {
	

		if(cookExp >= cookLevelReq) {
			cookLevel += 1;
			cookExp = 0;
			cookLevelReq += (cookLevelReq * 0.2f);
			cookBoost += (cookLevel/10);
		}

		if(scavengingExp >= scavengingLevelReq) {
			scavengingLevel += 1;
			scavengingExp = 0;
			scavengingLevelReq += (scavengingLevelReq * 0.2f);
			scavengingBoost += (scavengingLevel/10);
		}
			

		if(engineeringExp >= engineeringLevelReq) {
			engineeringLevel += 1;
			engineeringExp = 0;
			engineeringLevelReq += (engineeringLevelReq * 0.2f);
			engineeringBoost += (engineeringLevel/10);
		}

		if(medicalExp >= medicalLevelReq) {
			medicalLevel += 1;
			medicalExp = 0;
			medicalLevelReq += (medicalLevelReq * 0.2f);
			medicalBoost += (medicalLevel/10);
		}


		if(rangedExp >= rangedLevelReq) {
			if(rangedLevel < 5){ 
			rangedLevel += 1;
			rangedLevelReq += (rangedLevelReq * 0.2f);
			rangedBoost += 0.2f;
			GetComponent<defendArea>().LevelUpCombatStats(rangedBoost);
			rangedExp = 0;
			}
		}
	}


}
