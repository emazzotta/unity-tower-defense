using UnityEngine;
using System.Collections;

public class AntController : MonoBehaviour {

	private GameObject baseStart;

	// Use this for initialization
	void Start () {
		this.FindInititalWaypoint ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FindInitialWaypoint() {
		Debug.Log ("Ant Controller Start");
	}
}
