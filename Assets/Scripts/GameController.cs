using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public	GameObject towerBase;
	public 	GameObject gameField;
	private GameObject[,] towerBases;
	private int gameFieldWidth = 0;
	private int gameFieldHeight = 0;

	void Start () {
		this.gameFieldWidth = (int)(gameField.transform.localScale.x);
		this.gameFieldHeight = (int)(gameField.transform.localScale.z);
		this.towerBases = new GameObject[this.gameFieldWidth, this.gameFieldHeight];
		this.initGamePlatform ();
	}

	void initGamePlatform() {

		for (int x = 0; x < this.gameFieldWidth; x++) {
			for (int z = 0; z < this.gameFieldHeight; z++) {
				GameObject newTowerBase = Instantiate (towerBase);
				newTowerBase.AddComponent<Rigidbody> ();
				newTowerBase.transform.position = new Vector3 (towerBase.transform.position.x+x, 0.1f, towerBase.transform.position.z-z);
				this.towerBases [x, z] = newTowerBase;
			}
		}

	}
}
