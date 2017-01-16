using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject originalBase;
	public GameObject baseFolder;

	private GameObject gameField;
	private GameObject[,] bases;
	private GameObject[] waypoints;

	private int gameFieldWidth = 0;
	private int gameFieldHeight = 0;
	private Color wayColor;

	void Awake () {
		this.wayColor = Color.Lerp(Color.red, Color.green, 0F);
		this.gameField = GameObject.Find("Ground");   
		this.gameFieldWidth = (int)(gameField.transform.localScale.x);
		this.gameFieldHeight = (int)(gameField.transform.localScale.z);
		this.bases = new GameObject[this.gameFieldWidth, this.gameFieldHeight];
		this.waypoints = new GameObject[this.gameFieldWidth];

		this.initGamePlatform ();
		this.drawWaypoint ();
	}

	void initGamePlatform() {
		for (int x = 0; x < this.gameFieldWidth; x++) {
			for (int z = 0; z < this.gameFieldHeight; z++) {
				GameObject newTowerBase = Instantiate (originalBase);
				newTowerBase.transform.SetParent (baseFolder.transform);
				newTowerBase.GetComponent<TowerBaseController>().setBuildable(true); 
				newTowerBase.transform.position = new Vector3 (originalBase.transform.position.x + x, 0.1f, originalBase.transform.position.z - z);
				this.bases [x, z] = newTowerBase;
			}
		}
	}

	void drawWaypoint() {
		for (int x = 0; x < this.gameFieldWidth; x++) {
			GameObject baseZ = this.bases [x, 5];
			baseZ.GetComponent<Renderer> ().material.color = wayColor;
			baseZ.GetComponent<TowerBaseController>().setBuildable(false);
			this.waypoints[x] = baseZ;
		}
	}

	public GameObject[] getWaypoints() {
		return this.waypoints;
	}
}
