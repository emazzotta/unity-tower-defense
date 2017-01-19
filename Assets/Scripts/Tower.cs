using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	Transform towerTransform;

	public float range = 10f;
	public GameObject bulletPrefab;

	public int cost = 5;

	public int damage = 10;
	public float radius = 0;

	private MetallKefer nearestMetallKefer;

	void Start () {
		InvokeRepeating("AimAtTarget", 0, 0.5f);
		this.nearestMetallKefer = null;
		towerTransform = transform.Find("Tower");
	}

	void AimAtTarget() {
		MetallKefer[] enemies = GameObject.FindObjectsOfType<MetallKefer>();
		this.nearestMetallKefer = GetClosestEnemy(enemies);

		if(nearestMetallKefer != null) {
			if (nearestMetallKefer != null && nearestMetallKefer.GetHealth () > 0) {
				ShootAt (nearestMetallKefer);
			}

			Vector3 lookRotation = nearestMetallKefer.transform.position - this.transform.position;
			if (lookRotation != Vector3.zero) {
				var targetRotation = Quaternion.LookRotation(lookRotation);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
			}
		}
	}


	void ShootAt(MetallKefer metallKefer) {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
		bulletGO.transform.SetParent (this.transform);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = metallKefer;
		b.damage = damage;
	}

	MetallKefer GetClosestEnemy(MetallKefer[] enemies) {
   		MetallKefer tMin = null;
   		float minDist = Mathf.Infinity;
    	Vector3 currentPos = transform.position;
    	foreach (MetallKefer enemy in enemies) {
        	float dist = Vector3.Distance(enemy.transform.position, currentPos);
        	if (dist < minDist)	{
            	tMin = enemy;
            	minDist = dist;
        	}
    	}
    	return tMin;
	}
}

