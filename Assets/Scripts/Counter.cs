using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {

	void OnTriggerEnter (Collider info) {
		Destroy(gameObject);
		ScoreCount.gscore += 3;
	}
}
