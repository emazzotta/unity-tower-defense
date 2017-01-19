using UnityEngine;
using System.Collections;

public class MetallKefer : MonoBehaviour {

	private Game game;
	private GameObject[] baseBuildable;
	private GameObject nextWaypiont;
    private int health;
	private int currentWaypointIndex = 0;
	private int movementSpeed = 2;

	void Start () {
        this.health = 100;
		this.game = GameObject.FindObjectOfType<Game>();
		this.nextWaypiont = this.game.getWaypoints () [this.currentWaypointIndex];
		this.setInitialPosition ();
	}
	
	void Update() {
		this.moveToNextWaypoint ();

		if (this.transform.position.Equals( this.nextWaypiont.transform.position )) {
			this.SetNextWaypoint ();
		}
	}

	void SetNextWaypoint() {
		if (this.currentWaypointIndex < this.game.getWaypoints ().Length - 1) {
			this.currentWaypointIndex += 1;
			this.nextWaypiont = this.game.getWaypoints () [this.currentWaypointIndex];
			this.nextWaypiont.GetComponent<Renderer> ().material.color = Utils.getRandomColor();
		}
	}

	private void setInitialPosition() {
		this.transform.position = this.nextWaypiont.transform.position;
	}

	private void moveToNextWaypoint() {
		float step = movementSpeed * Time.deltaTime;

		Vector3 lookRotation = this.nextWaypiont.transform.position - transform.position;
		if (lookRotation != Vector3.zero) {
			var targetRotation = Quaternion.LookRotation(lookRotation);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
			this.transform.position = Vector3.MoveTowards(transform.position, this.nextWaypiont.transform.position, step);
		}

	}

	public void TakeDamage(int damage) {
		health -= damage;
		if (this.gameObject && health <= 0) {
			Destroy (this.gameObject);
		}
    }

	public int GetHealth() {
		return this.health;
	}
}
