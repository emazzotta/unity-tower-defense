using UnityEngine;
using System.Collections;

public class TowerPlacementController : MonoBehaviour {

	public GameObject towerToPlace;

	void OnMouseUp() {
		GameObject tower = Instantiate (towerToPlace);
		tower.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y+0.1f, this.transform.position.z);
	}
}
