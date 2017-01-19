using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[HideInInspector]
	public MetallKeferController target;

    public float speed = 2f;
    public int damage;
	private int timeToLiveFrames = 60;

    void Update() {
		timeToLiveFrames -= 1;

		if (timeToLiveFrames <= 0) {
			this.DestroyBullet ();
		}

		Vector3 direction = target.transform.position - this.transform.position;
		float distanceCurrentFrame = speed * Time.deltaTime;
		

		if(direction.magnitude <= distanceCurrentFrame) {
			DoBulletHit();
			this.DestroyBullet ();
		} else {
			this.transform.Translate(direction.normalized * distanceCurrentFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*speed);
		}
	}

    void DoBulletHit() {
		MetallKeferController e = target.GetComponent<MetallKeferController>();
		if(e != null) {
			e.GetComponent<MetallKeferController>().TakeDamage(damage);
		}
    }

	void DestroyBullet() {
		Destroy (this.gameObject);
	}
}
