using UnityEngine;
using System.Collections;

public class TreeHealth : MonoBehaviour
{

	public int Health;
	// Number of hits so the tree would fall
	public GameObject FallenTree;
	// refrence to our prefab in the assets
	public Camera myCamera;
	// So we can raycast

	public Transform coconut;
	public Transform logs;


	void Start ()
	{
		myCamera = GameObject.FindObjectOfType<Camera> ();

	}

	void Update ()
	{
		
		if (Health > 0) {
			if (Vector3.Distance (transform.position, myCamera.transform.root.transform.position) < 10f) {
				if (Input.GetKeyDown (KeyCode.R) && WeaponSwitching.check == true && WeaponSwitching.axe == true) {
					Ray ray = new Ray (myCamera.transform.position, myCamera.transform.forward);
					RaycastHit hit;
					if (Physics.Raycast (ray, out hit, 10f)) {
						if (hit.collider.gameObject == gameObject) {
							--Health;
						}
					}
				}
			}
		}

		if (Health <= 0) {
			Health = 0;
			Destroy (gameObject);
			Vector3 position = new Vector3 (Random.Range (-1.0f, 1.0f), 0, Random.Range (-1.0f, 1.0f));
			//Instantiate(FallenTree,transform.position,transform.rotation);
			Instantiate (logs, transform.position + new Vector3 (0, 0, 0) + position, Quaternion.identity);
			Instantiate (logs, transform.position + new Vector3 (1, 0, 0) + position, Quaternion.identity);
			Instantiate (logs, transform.position + new Vector3 (2, 0, 0) + position, Quaternion.identity);


		}
	}
}
