using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projecttileParent;

	private Animator animator;
	private Spawner laneSpawner;

	void Start() {
		animator = GameObject.FindObjectOfType<Animator> ();

		projecttileParent = GameObject.Find("Projectiles");
		if (!projecttileParent) {
			projecttileParent = new GameObject("Projectiles");
		}

		setLaneSpawner ();
	}

	void Update() {
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("IsAttacking", true);
		} else {
			animator.SetBool("IsAttacking", false);
		}
	}

	// Look through all spawner, and set laneSpawner if found
	void setLaneSpawner () {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				laneSpawner = spawner;
				return;
			}
		}
		Debug.LogError ("No spawner in lane");
	}

	bool IsAttackerAheadInLane() {
		//return (laneSpawner && laneSpawner.transform.childCount > 0);
		if (laneSpawner.transform.childCount < 1) {
			return false;
		}

		foreach (Transform attacker in laneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		return false;
	}

	private void Fire() {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projecttileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
