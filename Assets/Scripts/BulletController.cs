using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed = 5f;
    public Transform target;
    public float damage = 1f;
    public float radius = 0;

    void Start() {

    }

    void Update() {
        if(target == null) {
            Destroy(this);
            return;
        }

		Vector3 direction = target.position - this.transform.localPosition;
		float distanceCurrentFrame = speed * Time.deltaTime;

		if(direction.magnitude <= distanceCurrentFrame) {
			// We reached the node
			DoBulletHit();
		} else {
			this.transform.Translate(direction.normalized * distanceCurrentFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}
	}

    void DoBulletHit() {
        if(radius == 0) {
            target.GetComponent<MetallKeferController>().TakeDamage(damage);
        } else {
            Collider[] collider = Physics.OverlapSphere(transform.position, radius);

			foreach(Collider c in collider) {
				MetallKeferController e = c.GetComponent<MetallKeferController>();
				if(e != null) {
					e.GetComponent<MetallKeferController>().TakeDamage(damage);
				}
			}
        }
        
        Destroy(this);
    }
}
