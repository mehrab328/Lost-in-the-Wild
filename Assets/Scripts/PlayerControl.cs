using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson{
public class PlayerControl : MonoBehaviour {

	private bool hasAxe = false;

	private bool canSwing = true;
	private bool isSwinging = false;
	public float swingTimer = 0.7f;

	private CharacterController controller ;
	private PlayerGUI playerGUI;

	// Use this for initialization
	void Start () {
			
			hasAxe = true;
			//controller = GameObject.Find("First Person Controller").GetComponent(CharacterController);
			//playerGUI = GameObject.Find("First Person Controller").GetComponent(PlayerGUI);

			controller = GameObject.FindGameObjectWithTag("Player").GetComponent ("CharacterController") as CharacterController; //I'm not shure if this is right but it's work perfect for me
			playerGUI = GameObject.FindGameObjectWithTag("Player").GetComponent ("PlayerGUI") as PlayerGUI; //I'm not shure if this is right but it's work perfect for me
	}
	
	// Update is called once per frame
	void Update () {
			//If we aren't moving and if we aren't swinging, then we idle!

			if(controller.velocity.magnitude <= 0 && isSwinging == false)
			{
				GetComponent<Animation>().Play("Idle");
				GetComponent<Animation>()["Idle"].wrapMode = WrapMode.Loop;
				GetComponent<Animation>()["Idle"].speed = 0.2f;
			}

			//If we're holding shift and moving, then sprint!

			if(controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
			{
				GetComponent<Animation>().Play("Sprint");
				GetComponent<Animation>()["Sprint"].wrapMode = WrapMode.Loop;
			}

			//WOODCUTTING SECTION
			if(hasAxe == true && canSwing == true)
			{
				if(Input.GetMouseButtonDown(0))
				{
					//Stamina reduction applied to the PlayerGUI script
					playerGUI.staminaBarDisplay -= 0.1f;

					//Swinging animation
					GetComponent<Animation>().Play("Swing");
					GetComponent<Animation>()["Swing"].speed = 2f;
					isSwinging = true;
					canSwing = false;
				}
			}

			if(canSwing == false)
			{
				swingTimer -= Time.deltaTime;
			}

			if(swingTimer <= 0)
			{
				swingTimer = 1;
				canSwing = true;
				isSwinging = false;
			}
		}
}
}
