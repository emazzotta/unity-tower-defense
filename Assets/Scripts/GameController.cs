using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject originalBase;
	public GameObject baseFolder;
	public GameObject scoreLabel;

	private GameObject gameField;
	private GameObject[,] bases;
	private GameObject[] waypoints;

	private int gameFieldWidth = 0;
	private int gameFieldHeight = 0;
	private Color wayColor;

	void Awake () {
		this.wayColor = Color.Lerp(Color.green, Color.green, 0F);
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
				newTowerBase.GetComponent<Base>().setBuildable(true); 
				newTowerBase.transform.position = new Vector3 (originalBase.transform.position.x + x, 0.1f, originalBase.transform.position.z - z);
				this.bases [x, z] = newTowerBase;
			}
		}
	}

	void drawWaypoint() {
		int zAxis = 5;
		int x = 0;
		while (x < this.gameFieldWidth) {
			GameObject baseZ = this.bases[x, zAxis];
			baseZ.GetComponent<Renderer> ().material.color = wayColor;
			baseZ.GetComponent<Base>().setBuildable(false);
			this.waypoints[x] = baseZ;

			float randNumber = (float)Math.Round(UnityEngine.Random.Range(-1.0f, 1.0f));

			if ( randNumber != 0 ) {
				x += 1;
			}

			if ( zAxis >= -1 && zAxis <= this.gameFieldHeight + 1 ) {
				zAxis += (int)randNumber;
			} 

			if ( zAxis < 1 ) {
				zAxis += 1;
			}

			if ( zAxis >= this.gameFieldHeight ) {
				zAxis -= 1;
			}
		}
	}

	public GameObject[] getWaypoints() {
		return this.waypoints;
	}

	public void increaseScore(int newScore) {
		int newSumscore = 0;
		Text score = scoreLabel.GetComponent<Text>();
		int currentScore = int.Parse(score.text);
		newSumscore = currentScore + newScore;
		score.text = newSumscore.ToString();
	}
}
