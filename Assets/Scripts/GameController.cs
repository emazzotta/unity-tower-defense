using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject towerBase;
	public GameObject gameField;

	void Start () {
		Debug.Log ("GameController: Game Started");
		this.initGamePlatform ();
	}

	void Update () {
	}

	void initGamePlatform() {
<<<<<<< Updated upstream
		for (int x = 0; x < gameField.transform.localScale.x; x++) {
			for (int z = 0; z < gameField.transform.localScale.z; z++) {
				GameObject newTowerBase = Instantiate (towerBase);
				newTowerBase.AddComponent<Rigidbody> ();
				newTowerBase.transform.position = new Vector3 (towerBase.transform.position.x+x, 0.1f, towerBase.transform.position.z-z);
=======
		// Create Cube
		for (int x = 0; x < fieldWidth; x++) {
			for (int z = 0; z < fieldHeight; z++) {
				GameObject newCube = Instantiate (cube);
				Transform parent = cube.transform;
				newCube.transform.parent = parent;

				newCube.AddComponent<Rigidbody> ();
				newCube.transform.position = new Vector3 (cube.transform.position.x+x, 0.1f, cube.transform.position.z-z);
>>>>>>> Stashed changes
			}
		}
	}
}
