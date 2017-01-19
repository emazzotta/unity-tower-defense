using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject enemiesFolder;
	public GameObject originalEnemy;
	public int enemiesToSpawn;
    private int enemiesSpawned;
	
	void Start () {
        enemiesSpawned = 0;
        InvokeRepeating("SpawnEnemy", 0, 2f);
	}

    void SpawnEnemy() {
       if(enemiesSpawned < enemiesToSpawn) { 
			GameObject anEnemy = Instantiate (originalEnemy);
			anEnemy.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
			anEnemy.transform.SetParent (enemiesFolder.transform);
			enemiesSpawned += 1;
		}
    }
}
