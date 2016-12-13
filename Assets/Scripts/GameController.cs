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
		for (int x = 0; x < gameField.transform.localScale.x; x++) {
			for (int z = 0; z < gameField.transform.localScale.z; z++) {
				GameObject newTowerBase = Instantiate (towerBase);
				newTowerBase.AddComponent<Rigidbody> ();
				newTowerBase.transform.parent = towerBase.transform;
				newTowerBase.transform.position = new Vector3 (towerBase.transform.position.x+x, 0.1f, towerBase.transform.position.z-z);
			}
		}
	}
}
