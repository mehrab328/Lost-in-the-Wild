using UnityEngine;
using System.Collections;

public class AxeDestroy : MonoBehaviour {

	public static int AxeHealth = 2;
	public GameObject Axe;

	void Start () {
	
	}
	

	void Update () {
		if (AxeHealth == 0)
			Destroy (gameObject);
	}
}
