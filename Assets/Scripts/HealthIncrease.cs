using UnityEngine;
using System.Collections;

public class HealthIncrease : MonoBehaviour {

	public float Distance;
	public Transform Target;

	public float Damping = 6.0f;
	public int attackRepeatTime = 1;

	public int TheDammage = 40;

	private float attackTime;

	public CharacterController controller;
	public float gravity = 20.0f;

	void Start () {
		attackTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance (Target.position, transform.position);
		if (Distance < 2.0) {
			GetComponent<Renderer> ().material.color = Color.cyan;
			healthIncrease ();
		} else {
			GetComponent<Renderer> ().material.color = Color.white;
		}
	}

	void healthIncrease(){
		if (Time.time > attackTime)
		{
			Target.SendMessage("Increase", TheDammage, SendMessageOptions.DontRequireReceiver);
			Debug.Log("The Player's Health Has Been Increased");
			attackTime = Time.time + attackRepeatTime;
		}
	}


}
