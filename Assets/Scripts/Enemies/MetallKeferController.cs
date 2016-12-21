using UnityEngine;
using System.Collections;

public class MetallKeferController : MonoBehaviour {

	public GameObject gameControllerObject;
	private GameController gameController;
	private GameObject[] towerBasesBuildable;

	void Start () {
		this.gameController = this.gameControllerObject.GetComponent<GameController>();
		this.FindInititalWaypoint ();
	}
	
	void FindInititalWaypoint() {
		
	}
}
