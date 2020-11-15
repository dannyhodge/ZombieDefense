using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponStock : MonoBehaviour {

	public int pistol = 0;
	public int shotgun = 0;
	public int sniper = 0;
	public int AssaultRifle = 0;
	public int NailGun = 0;
	public int Minigun = 0;
	public int LazerRifle = 0;
	public int LazerMinigun = 0;

	public int pistolCost = 1;
	public int shotgunCost = 1;
	public int sniperCost = 1;
	public int AssaultRifleCost = 1;
	public int NailGunCost = 1;
	public int MinigunCost = 1;
	public int LazerRifleCost = 1;
	public int LazerMinigunCost = 1;


	public GameObject PistolUI;
	public GameObject ShotgunUI;
	public GameObject SniperUI;
	public GameObject ARUI;
	public GameObject NailGunUI;
	public GameObject MiniGunUI;
	public GameObject LazerRifleUI;
	public GameObject LazerMinigunUI;

	public Sprite pistolSprite;
	public Sprite shotgunSprite;
	public Sprite sniperSprite;
	public Sprite AssaultRifleSprite;
	public Sprite NailGunSprite;
	public Sprite MiniGunSprite;
	public Sprite LazerRifleSprite;
	public Sprite LazerMinigunSprite;

	void Start() {


		UpdateUI();
	}

	public void UpdateUI() {
		PistolUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Pistol: " + pistol + " in stock";
		ShotgunUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Shotgun: " + shotgun + " in stock";
		SniperUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Sniper: " + sniper + " in stock";
		ARUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Assault Rifle: " + AssaultRifle + " in stock";
		NailGunUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Nail Gun: " + NailGun + " in stock";
		MiniGunUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Minigun: " + Minigun + " in stock";
		LazerRifleUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Lazer Rifle: " + LazerRifle + " in stock";
		LazerMinigunUI.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Lazer Minigun: " + LazerMinigun + " in stock";


		if(pistol==0) {
			PistolUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			PistolUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}


		if(shotgun==0) {
			ShotgunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			ShotgunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}


		if(sniper==0) {
			SniperUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			SniperUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}



		if(AssaultRifle==0) {
			ARUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			ARUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}



		if(NailGun==0) {
			NailGunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			NailGunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}



		if(Minigun==0) {
			MiniGunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			MiniGunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}


		if(LazerRifle==0) {
			LazerRifleUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			LazerRifleUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}


		if(LazerMinigun==0) {
			LazerMinigunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Buy?";
		}
		else {
			LazerMinigunUI.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Text>().text = "Equip?";
		}


	}

	public void RemoveCurrentWeapon(GameObject weapon) {
		
		if(	weapon.GetComponent<weaponStats>().weapon == "Pistol") {
			pistol++;
		}

		if(	weapon.GetComponent<weaponStats>().weapon == "Shotgun") {
			shotgun++;
		}

		if(	weapon.GetComponent<weaponStats>().weapon == "Sniper") {
			sniper++;
		}

		if(	weapon.GetComponent<weaponStats>().weapon == "AssaultRifle") {
			AssaultRifle++;
		}

		if(	weapon.GetComponent<weaponStats>().weapon == "NailGun") {
			NailGun++;
		}

		if(	weapon.GetComponent<weaponStats>().weapon == "MiniGun") {
			Minigun++;
		}

		if(	weapon.GetComponent<weaponStats>().weapon == "LazerRifle") {
			LazerRifle++;
		}

		if(	weapon.GetComponent<weaponStats>().weapon == "LazerMinigun") {
			LazerMinigun++;
		}




	
	}

	public void BuyPistol() {
		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "Pistol"){
		if(pistol == 0) {
			GetComponent<gameMechanics>().supplies -= pistolCost;
		}
			else {
				pistol--;
			}

		  
			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "Pistol";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 10;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 1;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 20;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = pistolSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			//PistolUI.transform.GetChild(1).GetComponent<Button>().interactable = false;

			UpdateUI();
			}
	}

	public void BuyShotgun() {

		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "Shotgun"){


		if(shotgun == 0) {
			GetComponent<gameMechanics>().supplies -= shotgunCost;
		}

			else {
				shotgun--;
			}
				

			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "Shotgun";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 40;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 3f;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 15;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = shotgunSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			UpdateUI();

		}
	}
	public void BuySniper() {

		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "Sniper"){


			if(sniper == 0) {
				GetComponent<gameMechanics>().supplies -= sniperCost;
			}

			else {
				sniper--;
			}


			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "Sniper";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 70;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 4f;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 25;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = sniperSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			UpdateUI();

		}
	}

	public void BuyAssaultRifle() {

		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "AssaultRifle"){


			if(AssaultRifle == 0) {
				GetComponent<gameMechanics>().supplies -= AssaultRifleCost;
			}

			else {
				AssaultRifle--;
			}


			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "AssaultRifle";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 40;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 1f;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 20;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = AssaultRifleSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			UpdateUI();

		}
	}

	public void BuyNailGun() {

		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "NailGun"){


			if(NailGun == 0) {
				GetComponent<gameMechanics>().supplies -= NailGunCost;
			}

			else {
				NailGun--;
			}


			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "NailGun";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 50;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 1f;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 20;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = NailGunSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			UpdateUI();

		}
	}

	public void BuyMiniGun() {

		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "MiniGun"){


			if(Minigun == 0) {
				GetComponent<gameMechanics>().supplies -= MinigunCost;
			}

			else {
				Minigun--;
			}


			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "MiniGun";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 50;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 0.5f;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 20;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = MiniGunSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			UpdateUI();

		}
	}
			
	public void BuyLazerRifle() {

		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "LazerRifle"){


			if(LazerRifle == 0) {
				GetComponent<gameMechanics>().supplies -= LazerRifleCost;
			}

			else {
				LazerRifle--;
			}


			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "LazerRifle";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 100;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 1f;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 25;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = LazerRifleSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			UpdateUI();

		}
	}


	public void BuyLazerMinigun() {

		if(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon != "LazerMinigun"){


			if(LazerMinigun == 0) {
				GetComponent<gameMechanics>().supplies -= LazerMinigunCost;
			}

			else {
				LazerMinigun--;
			}


			RemoveCurrentWeapon(GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject);

			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().weapon = "LazerMinigun";
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().damage = 100;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().attackSpeed = 0.5f;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().range = 20;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = LazerMinigunSprite;
			GetComponent<gameMechanics>().activeChar.transform.GetChild(2).GetComponent<weaponStats>().UpdateStats();

			UpdateUI();

		}
	}


	}











