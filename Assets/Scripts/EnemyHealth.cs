using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int Health; // Number of hits so the tree would fall
	public GameObject Enemy; // refrence to our prefab in the assets
	public Camera myCamera; // So we can raycast


	void Start () {
		myCamera = GameObject.FindObjectOfType<Camera>();

	}
	void Update ()
	{

		if(Health > 0)
		{
			if(Vector3.Distance(transform.position, myCamera.transform.root.transform.position) < 10f)
			{
				if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.T))
				{
					Ray ray = new Ray(myCamera.transform.position,myCamera.transform.forward);
					RaycastHit hit;
					if(Physics.Raycast(ray,out hit,10f))
					{
						if(hit.collider.gameObject == gameObject)
						{
							--Health;
						}
					}
				}
			}
		}

		if(Health <= 0)
		{
			Health =0;
			Destroy(gameObject);

		}
	}
}
