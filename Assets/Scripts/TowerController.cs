using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {

	Transform towerTransform;

	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	//float fireCooldown = 0.5f;
	//float fireCooldownLeft = 0;

	public int damage = 10;
	public float radius = 0;

	//private float dist = Mathf.Infinity;
	private MetallKeferController nearestMetallKeferController;

	void Start () {
		this.nearestMetallKeferController = null;
		towerTransform = transform.Find("Tower");
	}
	
	void Update () {
		MetallKeferController[] enemies = GameObject.FindObjectsOfType<MetallKeferController>();

		foreach(MetallKeferController e in enemies) {
			if (e != null && e.GetHealth () > 0) {
				ShootAt (e);
			}
		}
//
//		if(nearestMetallKeferController == null) {
//			Debug.Log("No enemies?");
//			return;
//		}
//
//		Vector3 dir = nearestMetallKeferController.transform.position - this.transform.position;
//
//		Quaternion lookRot = Quaternion.LookRotation( dir );
//
//		//Debug.Log(lookRot.eulerAngles.y);
//
	}

	void ShootAt(MetallKeferController metallKefer) {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
		bulletGO.transform.SetParent (this.transform);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = metallKefer;
		b.damage = damage;
	}
}

