using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour
{

	public int CurrentWeapon = 0;
	public int maxWeapons = 3;
	public Animator theAnimator;

	public static bool check;
	public static bool axe = false;

	int counter;

	void Awake ()
	{
		SelectWeapon (0);
	}


	void Update ()
	{
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			
			if (CurrentWeapon + 1 <= maxWeapons) {
				CurrentWeapon++;
			} else {
				CurrentWeapon = 0;
			}
			SelectWeapon (CurrentWeapon);
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (CurrentWeapon - 1 >= 0) {
				CurrentWeapon--;
			} else {
				CurrentWeapon = maxWeapons;
			}
			SelectWeapon (CurrentWeapon);
		}

		if (CurrentWeapon == maxWeapons + 1) {
			CurrentWeapon = 0;
		}

		if (CurrentWeapon == -1) {
			CurrentWeapon = maxWeapons;
		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			counter++;
			counter = counter % 4;
		}

		if (counter == 0) {
			CurrentWeapon = 0;
			SelectWeapon (CurrentWeapon);
		}

		if (counter == 1) {
			CurrentWeapon = 1;
			SelectWeapon (CurrentWeapon);
		}

		if (counter == 2) {
			CurrentWeapon = 2;
			SelectWeapon (CurrentWeapon);
		}

		if (counter == 3) {
			CurrentWeapon = 3;
			SelectWeapon (CurrentWeapon);
		}

		if (Input.GetKeyDown (KeyCode.R) && theAnimator.GetBool("WeaponIsOn") == false) {
			theAnimator.Play ("Hit01");
			check = false;
		}

		if (Input.GetKeyDown (KeyCode.T) && theAnimator.GetBool("WeaponIsOn") == false) {
			theAnimator.Play ("Hit02");
			check = false;
		}

		if (Input.GetKeyDown (KeyCode.R) && theAnimator.GetBool("WeaponIsOn") == true) {
			theAnimator.Play ("Swing01");
			check = true;
		}

		if (Input.GetKeyDown (KeyCode.T) && theAnimator.GetBool("WeaponIsOn") == true) {
			theAnimator.Play ("Swing02");
			check = true;
		}

			
	}

	void SelectWeapon (int index)
	{
		for (int i = 0; i < transform.childCount; i++) {
			//Activate the selected weapon
			if (i == index) {
				if (transform.GetChild (i).name == "Fists") {
					theAnimator.SetBool ("WeaponIsOn", false);
				} else {
					theAnimator.SetBool ("WeaponIsOn", true);
				}
				transform.GetChild (i).gameObject.SetActive (true);
				if (transform.GetChild (i).name == "Axe")
					axe = true;
			} else {
				transform.GetChild (i).gameObject.SetActive (false);
			}
		}
	}
}
