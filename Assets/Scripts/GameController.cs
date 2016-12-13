using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {
		Debug.Log ("GameController: Game Started");

		this.initGamePlatform ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void initGamePlatform() {
		// Create Cube
		for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 5; x++) {
				GameObject newCube = Instantiate (cube);
				newCube.AddComponent<Rigidbody> ();
				newCube.transform.position = new Vector3 (x, y, 0);
			}
		}
	}
}
