using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Vector2 size = new Vector2 (120, 20);

	//health vars
	public Vector2 healthPos = new Vector2 (20, 20);
	public float healthBarDisplay = 1f;
	public Texture2D healthBarEmpty;
	public Texture2D healthBarFull;

	//stamina vars
	public Vector2 staminaPos = new Vector2 (20, 60);
	public float staminaBarDisplay = 1f;
	public Texture2D staminaBarEmpty;
	public Texture2D staminaBarFull; 


	//fall rate
	public int healthFallRate = 150;
	public int staminaFallRate = 35;


	private UnityStandardAssets.Characters.FirstPerson.FirstPersonController chMotor;
	private CharacterController controller;


	public bool canJump = false;
	float jumpTimer = 0.7f;

	void Start(){
		chMotor = gameObject.GetComponent ("UnityStandardAssets.Characters.FirstPerson.FirstPersonController") as UnityStandardAssets.Characters.FirstPerson.FirstPersonController;
		controller = gameObject.GetComponent<CharacterController>();
	} 

	void OnGUI(){

		//health GUI
		GUI.BeginGroup (new Rect (healthPos.x, healthPos.y, size.x, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), healthBarEmpty);

		GUI.BeginGroup (new Rect (0, 0, size.x * healthBarDisplay, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), healthBarFull);

		GUI.EndGroup ();
		GUI.EndGroup ();

		//stamina GUI
		GUI.BeginGroup (new Rect (staminaPos.x, staminaPos.y, size.x, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), staminaBarEmpty);

		GUI.BeginGroup (new Rect (0, 0, size.x * staminaBarDisplay, size.y));
		GUI.Box(new Rect(0,0,size.x,size.y), staminaBarFull);

		GUI.EndGroup ();
		GUI.EndGroup ();
	}

	void Update()
	{
		

		//STAMINA CONTROL SECTION
		if(controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
		{
			chMotor.m_RunSpeed = 10;
			//chMotor.movement.maxSidewaysSpeed = 10;
			staminaBarDisplay -= Time.deltaTime / staminaFallRate;
		}

		else
		{
			chMotor.m_WalkSpeed = 6;
			//chMotor.movement.maxSidewaysSpeed = 6;
			staminaBarDisplay += Time.deltaTime / staminaFallRate;
		}

		//JUMPING SECTION
		if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
		{
			staminaBarDisplay -= 0.02f;
			Wait();
		}

		if(canJump == false)
		{
			//jumpTimer -= Time.deltaTime;
			chMotor.m_Jump = false;
		}

		//if(jumpTimer <= 0)
		if(controller.isGrounded)
		{
			canJump = true;
			//chMotor.m_Jumping = true;
			//chMotor.m_Jump = true;
			//jumpTimer = 0.7f;
		}

		if(staminaBarDisplay >= 1)
		{
			staminaBarDisplay = 1;
		}

		if(staminaBarDisplay <= 0)
		{
			staminaBarDisplay = 0;
		}

		if(staminaBarDisplay <= 0.3f)
		{

			//staminaBarDisplay = 0;
			chMotor.m_RunSpeed = chMotor.m_WalkSpeed;
			canJump = false;
			//chMotor.m_Jump = false;
			//chMotor.m_Jumping = false;
			//chMotor.m_Jumping = false;
			//chMotor.m_WalkSpeed = 6;
			//chMotor.movement.maxSidewaysSpeed = 6;
		}

	}

	void ApplyDammage(int TheDammage){
		healthBarDisplay -= Time.deltaTime / TheDammage * 40;

		if (healthBarDisplay <= 0) {
			Dead ();
		}
	}

	void Dead(){
		Destroy (gameObject);

	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.1f);
		canJump = false;
	}



	void Increase(int TheIncrease)
	{
		healthBarDisplay += Time.deltaTime / TheIncrease * 20;
	}


		
}
