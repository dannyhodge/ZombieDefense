using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchItem {
	public bool researched = false;
	public int order = 0;
	public int cost = 0;
	public GameObject UI;
	public GameObject storeUI;
}


public class techTree : MonoBehaviour {

	public int currentOrder = 0;
	public List<ResearchItem> researchitems = new List<ResearchItem>();

	public GameObject pistolUI;
	public GameObject shotgunUI;
	public GameObject sniperUI;
	public GameObject assaultRifleUI;
	public GameObject nailgunUI;
	public GameObject minigunUI;
	public GameObject lazerrifleUI;
	public GameObject lazerminigunUI;

	public GameObject shotgunStoreUI;
	public GameObject sniperStoreUI;
	public GameObject assaultRifleStoreUI;
	public GameObject nailgunStoreUI;
	public GameObject minigunStoreUI;
	public GameObject lazerrifleStoreUI;
	public GameObject lazerMinigunStoreUI;



	void Start() {

		ResearchItem pistol = new ResearchItem();
		pistol.UI = pistolUI;
		pistol.order = 0;
		pistol.researched = true;
		researchitems.Add(pistol);

		ResearchItem shotgun = new ResearchItem();
		shotgun.order = 1;
		shotgun.researched = false;
		shotgun.cost = 10;
		shotgun.UI = shotgunUI;
		shotgun.storeUI = shotgunStoreUI;
		researchitems.Add(shotgun);

		ResearchItem sniper = new ResearchItem();
		sniper.order = 2;
		sniper.researched = false;
		sniper.cost = 15;
		sniper.UI = sniperUI;
		sniper.storeUI = sniperStoreUI;
		researchitems.Add(sniper);

		ResearchItem assaultrifle = new ResearchItem();
		assaultrifle.order = 3;
		assaultrifle.researched = false;
		assaultrifle.cost = 20;
		assaultrifle.UI = assaultRifleUI;
		assaultrifle.storeUI = assaultRifleStoreUI;
		researchitems.Add(assaultrifle);

		ResearchItem nailgun = new ResearchItem();
		nailgun.order = 4;
		nailgun.researched = false;
		nailgun.cost = 25;
		nailgun.UI = nailgunUI;
		nailgun.storeUI = nailgunStoreUI;
		researchitems.Add(nailgun);


		ResearchItem minigun = new ResearchItem();
		minigun.order = 5;
		minigun.researched = false;
		minigun.cost = 30;
		minigun.UI = minigunUI;
		minigun.storeUI = minigunStoreUI;
		researchitems.Add(minigun);


		ResearchItem lazerrifle = new ResearchItem();
		lazerrifle.order = 6;
		lazerrifle.researched = false;
		lazerrifle.cost = 35;
		lazerrifle.UI = lazerrifleUI;
		lazerrifle.storeUI = lazerrifleStoreUI;
		researchitems.Add(lazerrifle);


		ResearchItem lazerminigun = new ResearchItem();
		lazerminigun.order = 7;
		lazerminigun.researched = false;
		lazerminigun.cost = 40;
		lazerminigun.UI = lazerminigunUI;
		lazerminigun.storeUI = lazerMinigunStoreUI;
		researchitems.Add(lazerminigun);



	}

	public void Update() {

		foreach(ResearchItem item in researchitems) {
			if(item.order - 1 == currentOrder) {
				item.UI.GetComponent<Button>().interactable = true;
			}
			else {
				item.UI.GetComponent<Button>().interactable = false;
			}
		}

	}

	public void ResearchIt() {

		foreach(ResearchItem item in researchitems) {

			if((item.order-1) == currentOrder) {
				if(GetComponent<gameMechanics>().researchPoints >= item.cost) {
				item.storeUI.GetComponent<Button>().interactable = true;
				GetComponent<gameMechanics>().researchPoints -= item.cost;
				currentOrder++;
				}
			}

		}





	}





}
