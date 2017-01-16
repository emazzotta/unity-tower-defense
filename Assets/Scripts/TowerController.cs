using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {

	Transform towerTransform;

	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	float fireCooldown = 0.5f;
	float fireCooldownLeft = 0;

	public float damage = 1;
	public float radius = 0;

	void Start () {
		towerTransform = transform.Find("Tower");
	}
	
	void Update () {
		// TODO: Optimize this!
		MetallKeferController[] enemies = GameObject.FindObjectsOfType<MetallKeferController>();

		MetallKeferController nearestMetallKeferController = null;
		float dist = Mathf.Infinity;

		foreach(MetallKeferController e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestMetallKeferController == null || d < dist) {
				nearestMetallKeferController = e;
				dist = d;
			}
		}

		if(nearestMetallKeferController == null) {
			Debug.Log("No enemies?");
			return;
		}

		Vector3 dir = nearestMetallKeferController.transform.position - this.transform.position;

		Quaternion lookRot = Quaternion.LookRotation( dir );

		//Debug.Log(lookRot.eulerAngles.y);
		towerTransform.rotation = Quaternion.Euler( 0, lookRot.eulerAngles.y, 0 );

		fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt(nearestMetallKeferController);
		}

	}

	void ShootAt(MetallKeferController e) {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		BulletController b = bulletGO.GetComponent<BulletController>();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;
	}
}

