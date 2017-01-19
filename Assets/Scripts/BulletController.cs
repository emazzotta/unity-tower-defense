using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed = 2f;
    public Transform target;
    public int damage = 1;
    public float radius = 0;

    void Update() {
		Vector3 direction = target.position - this.transform.position;
		float distanceCurrentFrame = speed * Time.deltaTime;

		if(direction.magnitude <= distanceCurrentFrame) {
			// We reached the node
			DoBulletHit();
		} else {
			this.transform.Translate(direction.normalized * distanceCurrentFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*speed);
		}
	}

    void DoBulletHit() {
        if(radius == 0) {
			if (target != null) {
				target.GetComponent<MetallKeferController>().TakeDamage(damage);
			}
        } else {
            Collider[] collider = Physics.OverlapSphere(transform.position, radius);

			foreach(Collider c in collider) {
				MetallKeferController e = c.GetComponent<MetallKeferController>();
				if(e != null) {
					e.GetComponent<MetallKeferController>().TakeDamage(damage);
				}
			}
        }
    }
}
