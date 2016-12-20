using UnityEngine;
using System.Collections;

public class MetallKeferController : MonoBehaviour {

	public GameObject towerBasesWaypoint;
	private GameObject baseStart;

	// Use this for initialization
	void Start () {
		this.FindInititalWaypoint ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FindInititalWaypoint() {
		Debug.Log ("MetallKefer Controller Start");
	}
}
