using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		//Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		//myRigidbody.isKinematic = true;
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("IsAttacking", false);
		}
	} 

	void OnTriggerEnter2D() {
		//Debug.Log (name + " trigger enter");
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	// Called from Animator at the time of attack
	public void StrikeCurrentTarget (float damage){
		//Debug.Log(name + " caused damage: " + damage);
		if (currentTarget) {
			Health healt = currentTarget.GetComponent<Health> ();
			if (healt) {
				healt.DealDamage (damage);
			}

		}
	}

	public void Attack (GameObject obj){
		currentTarget = obj;

	}
}


