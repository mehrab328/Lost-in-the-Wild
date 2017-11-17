using UnityEngine;
using System.Collections;

public class AISimple : MonoBehaviour {
	public Transform player;
	float distancefrom_player;
	public float look_range = 20.0f;
	public float agro_range = 10.0f;
	public float move_speed = 5.0f;
	public float damping = 6.0f;

	void Update(){
		distancefrom_player = Vector3.Distance (player.position, transform.position);

		if(distancefrom_player < look_range){
			transform.LookAt (player);
			GetComponent<Renderer> ().material.color = Color.yellow;
		}

		if(distancefrom_player > look_range){
			GetComponent<Renderer> ().material.color = Color.green;
		}

		if(distancefrom_player < agro_range){
			GetComponent<Renderer> ().material.color = Color.red;
			attack ();
		}
	}

	void lookAt(){
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void attack(){
		transform.Translate (Vector3.forward * move_speed * Time.deltaTime);
	}
}
