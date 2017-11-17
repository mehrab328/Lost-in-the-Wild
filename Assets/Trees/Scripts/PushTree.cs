using UnityEngine;
using System.Collections;

public class PushTree : MonoBehaviour {

	public float Force;
	public Camera MyCamera;

	void Start ()
	{
		MyCamera = GameObject.FindObjectOfType<Camera>();
		GetComponent<Rigidbody>().AddTorque(MyCamera.transform.right * Force,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
