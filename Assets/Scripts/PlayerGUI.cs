using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public Vector2 size = new Vector2 (120, 20);

	//health vars
	public Vector2 healthPos = new Vector2 (20, 20);
	public float healthBarDisplay = 1f;
	public Texture2D healthBarEmpty;
	public Texture2D healthBarFull;


	//hunger vars
	public Vector2 hungerPos = new Vector2 (20, 60);
	public float hungerBarDisplay = 1f;
	public Texture2D hungerBarEmpty;
	public Texture2D hungerBarFull;

	//thirst vars
	public Vector2 thirstPos = new Vector2 (20, 100);
	public float thirstBarDisplay = 1f;
	public Texture2D thirstBarEmpty;
	public Texture2D thirstBarFull; 

	//stamina vars
	public Vector2 staminaPos = new Vector2 (20, 140);
	public float staminaBarDisplay = 1f;
	public Texture2D staminaBarEmpty;
	public Texture2D staminaBarFull; 
	/*
	//stamina2 vars
	public Vector2 stamina2Pos = new Vector2 (20, 140);
	public float stamina2BarDisplay = 1f;
	public Texture2D stamina2BarEmpty;
	public Texture2D stamina2BarFull;
	*/
	//fall rate
	public int healthFallRate = 150;
	public int hungerFallRate = 150;
	public int thirstFallRate = 100;
	public int staminaFallRate = 35;
	public int stamina2FallRate = 150;

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
		GUI.Box(new Rect(0,0,size.x,size.y), healthBarFull);

		GUI.EndGroup ();
		GUI.EndGroup ();

		//hunger GUI
		GUI.BeginGroup (new Rect (hungerPos.x, hungerPos.y, size.x, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), hungerBarEmpty);
		
		GUI.BeginGroup (new Rect (0, 0, size.x * hungerBarDisplay, size.y));
		GUI.Box(new Rect(0,0,size.x,size.y), hungerBarFull);
		
		GUI.EndGroup ();
		GUI.EndGroup ();

		//thirst GUI
		GUI.BeginGroup (new Rect (thirstPos.x, thirstPos.y, size.x, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), thirstBarEmpty);
		
		GUI.BeginGroup (new Rect (0, 0, size.x * thirstBarDisplay, size.y));
		GUI.Box(new Rect(0,0,size.x,size.y), thirstBarFull);

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

	void ApplyDammage(int TheDammage){
		healthBarDisplay -= Time.deltaTime / TheDammage * 40;

		if (healthBarDisplay <= 0) {
			Dead ();
		}
	}

	void Dead(){
		//Destroy (gameObject);
	}

	void Update(){

		//HEALTH CONTROL SECTION
		if(hungerBarDisplay <= 0 && (thirstBarDisplay <= 0))
		{
			healthBarDisplay -= Time.deltaTime / healthFallRate * 2;
		}
		
		else
		{
			if(hungerBarDisplay <= 0 || thirstBarDisplay <= 0)
			{
				healthBarDisplay -= Time.deltaTime / healthFallRate;
			}
		}
		
		if(healthBarDisplay <= 0)
		{
			//Destroy (gameObject);
		}
		
		//HUNGER CONTROL SECTION
		if(hungerBarDisplay >= 0)
		{
			hungerBarDisplay -= Time.deltaTime / hungerFallRate;
		}
		
		if(hungerBarDisplay <= 0)
		{
			hungerBarDisplay = 0;
		}
		
		if(hungerBarDisplay >= 1)
		{
			hungerBarDisplay = 1;
		}
		
		//THIRST CONTROL SECTION
		if(thirstBarDisplay >= 0)
		{
			thirstBarDisplay -= Time.deltaTime / thirstFallRate;
		}
		
		if(thirstBarDisplay <= 0)
		{
			thirstBarDisplay = 0;
		}
		
		if(thirstBarDisplay >= 1)
		{
			thirstBarDisplay = 1;
		}
		
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

		/*
		//STAMINA2 CONTROL SECTION
		if(stamina2BarDisplay >= 0)
		{
			stamina2BarDisplay -= Time.deltaTime / stamina2FallRate;
		}
		
		if(stamina2BarDisplay <= 0)
		{
			stamina2BarDisplay = 0;
		}
		
		if(stamina2BarDisplay >= 1)
		{
			stamina2BarDisplay = 1;
		} */
		
		//JUMPING SECTION
		if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
		{
			staminaBarDisplay -= 0.2f;
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
		

		//if(staminaBarDisplay <= 0.05)
		//{
		//canJump = false;
		//chMotor.jumping.enabled = false;
		//}
		
		//else
		//{
		//canJump = true;
		//chMotor.jumping.enabled = true;
		//}
		
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


	void CharacterDeath()
	{
		if (healthBarDisplay <= 0f) {
			Application.LoadLevel("scene");
		}

	}
	
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.1f);
		canJump = false;
	}
	

}
