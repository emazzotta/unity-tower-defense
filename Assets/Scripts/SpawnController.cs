using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject EnemiesFolder;
	public GameObject originalEnemy;
	public int amountOfEnemies;
	
	void Start () {
		for (int i = 0; i < amountOfEnemies; i++) {
			GameObject anEnemy = Instantiate (originalEnemy);
			anEnemy.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
			anEnemy.transform.SetParent (EnemiesFolder.transform);
		}
	}
}
