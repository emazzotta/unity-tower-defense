using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {

	public GameObject towerToPlace;
	public bool buildable;

	private GameObject towerFolder;

	void Start() {
		this.towerFolder = GameObject.Find("Towers"); 
	}

	void OnMouseUp() {
		if (buildable) {
			GameObject tower = Instantiate (towerToPlace);
			tower.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
			tower.transform.SetParent (towerFolder.transform);
		}
	}

	public void setBuildable(bool buildable) {
		this.buildable = buildable;
	}

	public bool isBuildable() {
		return this.buildable;
	}
}
