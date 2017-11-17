using UnityEngine;
using System.Collections;

public class AdvancedAIC : MonoBehaviour {
	public float Distance;
	public Transform Target;
	public float lookAtDistance = 25.0f;
	public float chaseRange = 15.0f;
	public float attackRange = 1.5f;
	public float moveSpeed = 5.0f;
	public float Damping = 6.0f;
	public int attackRepeatTime = 1;

	public int TheDammage = 40;

	private float attackTime;

	public CharacterController controller;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	void Start ()
	{
		attackTime = Time.time;
	}

	void Update(){
		Distance = Vector3.Distance (Target.position, transform.position);

		if(Distance < lookAtDistance){
			transform.LookAt (Target);
		}

		if(Distance > lookAtDistance){
			GetComponent<Renderer> ().material.color = Color.green;
		}

		if(Distance < attackRange){
			attack ();
		}

		else if (Distance < chaseRange)
		{
			chase ();
		}
	}

	void lookAt(){
		Quaternion rotation = Quaternion.LookRotation (Target.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * Damping);
	}

	void chase ()
	{
		GetComponent<Renderer> ().material.color = Color.red;

		moveDirection = transform.forward;
		moveDirection *= moveSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void attack ()
	{
		if (Time.time > attackTime)
		{
			Target.SendMessage("ApplyDammage", TheDammage, SendMessageOptions.DontRequireReceiver);
			Debug.Log("The Enemy Has Attacked");
			attackTime = Time.time + attackRepeatTime;
		}
	}

	void ApplyDammage ()
	{
		chaseRange += 30;
		moveSpeed += 2;
		lookAtDistance += 40;
	}


}
