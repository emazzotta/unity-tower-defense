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
		Metallkefer[] enemies = GameObject.FindObjectsOfType<Metallkefer>();

		Metallkefer nearestMetallkefer = null;
		float dist = Mathf.Infinity;

		foreach(Metallkefer e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestMetallkefer == null || d < dist) {
				nearestMetallkefer = e;
				dist = d;
			}
		}

		if(nearestMetallkefer == null) {
			Debug.Log("No enemies?");
			return;
		}

		Vector3 dir = nearestMetallkefer.transform.position - this.transform.position;

		Quaternion lookRot = Quaternion.LookRotation( dir );

		//Debug.Log(lookRot.eulerAngles.y);
		towerTransform.rotation = Quaternion.Euler( 0, lookRot.eulerAngles.y, 0 );

		fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && dir.magnitude <= range) {
			fireCooldownLeft = fireCooldown;
			ShootAt(nearestMetallkefer);
		}

	}

	void ShootAt(Metallkefer e) {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.transform;
		b.damage = damage;
		b.radius = radius;
	}
}

