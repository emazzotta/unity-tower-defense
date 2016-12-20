using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public  GameObject towerBaseWrap;
	public	GameObject towerBase;
	public 	GameObject gameField;
	private GameObject[,] towerBases;
	private int gameFieldWidth = 0;
	private int gameFieldHeight = 0;
	private Color wayColor;

	void Start () {
		this.wayColor = Color.Lerp(Color.red, Color.green, 0F);
		this.gameFieldWidth = (int)(gameField.transform.localScale.x);
		this.gameFieldHeight = (int)(gameField.transform.localScale.z);
		this.towerBases = new GameObject[this.gameFieldWidth, this.gameFieldHeight];
		this.initGamePlatform ();
		this.drawWaypoint ();
	}

	void initGamePlatform() {

		for (int x = 0; x < this.gameFieldWidth; x++) {
			for (int z = 0; z < this.gameFieldHeight; z++) {
				GameObject newTowerBase = Instantiate (towerBase);
				newTowerBase.GetComponent<TowerBaseController>().setBuildable(true); 
				newTowerBase.transform.position = new Vector3 (towerBase.transform.position.x + x, 0.1f, towerBase.transform.position.z - z);
				this.towerBases [x, z] = newTowerBase;
				newTowerBase.transform.SetParent (towerBaseWrap.transform);
			}
		}

		// We don't need the initial prefab element anymore, it's replaced by a cloned tower.
		Destroy (towerBase);
			
	}

	void drawWaypoint() {
		for (int x = 0; x < this.gameFieldWidth; x++) {
			GameObject baseZ = this.towerBases [x, 5];
			baseZ.GetComponent<Renderer> ().material.color = wayColor;
			baseZ.GetComponent<TowerBaseController>().setBuildable(false);
		}
	}
}
