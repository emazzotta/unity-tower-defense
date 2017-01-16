using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject originalTowerBase;
	public GameObject gameField;

	private GameObject[,] towerBases;
	private GameObject[] waypoints;

	private int gameFieldWidth = 0;
	private int gameFieldHeight = 0;
	private Color wayColor;

	void Awake () {
		this.wayColor = Color.Lerp(Color.red, Color.green, 0F);
		this.gameFieldWidth = (int)(gameField.transform.localScale.x);
		this.gameFieldHeight = (int)(gameField.transform.localScale.z);
		this.towerBases = new GameObject[this.gameFieldWidth, this.gameFieldHeight];
		this.waypoints = new GameObject[this.gameFieldWidth];

		this.initGamePlatform ();
		this.drawWaypoint ();
	}

	void initGamePlatform() {
		for (int x = 0; x < this.gameFieldWidth; x++) {
			for (int z = 0; z < this.gameFieldHeight; z++) {
				GameObject newTowerBase = Instantiate (originalTowerBase);
				newTowerBase.GetComponent<TowerBaseController>().setBuildable(true); 
				newTowerBase.transform.position = new Vector3 (originalTowerBase.transform.position.x + x, 0.1f, originalTowerBase.transform.position.z - z);
				this.towerBases [x, z] = newTowerBase;
			}
		}
	}

	void drawWaypoint() {
		for (int x = 0; x < this.gameFieldWidth; x++) {
			GameObject baseZ = this.towerBases [x, 5];
			baseZ.GetComponent<Renderer> ().material.color = wayColor;
			baseZ.GetComponent<TowerBaseController>().setBuildable(false);
			this.waypoints[x] = baseZ;
		}
	}

	public GameObject[] getWaypoints() {
		return this.waypoints;
	}
}
