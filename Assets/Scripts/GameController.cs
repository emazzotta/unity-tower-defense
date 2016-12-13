using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cube;
	private int fieldWidth;
	private int fieldHeight;

	// Use this for initialization
	void Start () {
		Debug.Log ("GameController: Game Started");
		fieldWidth = 20;
		fieldHeight = 10;
		this.initGamePlatform ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void initGamePlatform() {
		// Create Cube
		for (int x = 0; x < fieldWidth; x++) {
			for (int z = 0; z < fieldHeight; z++) {
				GameObject newCube = Instantiate (cube);
				newCube.AddComponent<Rigidbody> ();
				newCube.transform.position = new Vector3 (cube.transform.position.x+x, 0.1f, cube.transform.position.z-z);
			}
		}
	}
}
