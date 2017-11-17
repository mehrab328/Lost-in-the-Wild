using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {

	public static int gscore = 0;

	void OnGUI()
	{
		GUI.Label (new Rect (800, 10, 100, 20), ("Wood: " + gscore), "Red");
	}
}
