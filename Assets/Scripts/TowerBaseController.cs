using UnityEngine;
using System.Collections;

public class TowerBaseController : MonoBehaviour {

	public GameObject towerToPlace;
	public bool buildable;

	void OnMouseUp() {
		if (buildable) {
			GameObject tower = Instantiate (towerToPlace);
			tower.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
		}
	}

	public void setBuildable(bool buildable) {
		this.buildable = buildable;
	}

	public bool isBuildable() {
		return this.buildable;
	}
}
