using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform towerTransform;

	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	//float fireCooldown = 0.5f;
	//float fireCooldownLeft = 0;

	public int damage = 10;
	public float radius = 0;

	//private float dist = Mathf.Infinity;
	private MetallKefer nearestMetallKefer;

	void Start () {
		this.nearestMetallKefer = null;
		towerTransform = transform.Find("Tower");
	}
	
	void Update () {
		MetallKefer[] enemies = GameObject.FindObjectsOfType<MetallKefer>();

		foreach(MetallKefer e in enemies) {
			if (e != null && e.GetHealth () > 0) {
				ShootAt (e);
			}
		}
//
//		if(nearestMetallKefer == null) {
//			Debug.Log("No enemies?");
//			return;
//		}
//
//		Vector3 dir = nearestMetallKefer.transform.position - this.transform.position;
//
//		Quaternion lookRot = Quaternion.LookRotation( dir );
//
//		//Debug.Log(lookRot.eulerAngles.y);
//
	}

	void ShootAt(MetallKefer metallKefer) {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
		bulletGO.transform.SetParent (this.transform);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = metallKefer;
		b.damage = damage;
	}
}

