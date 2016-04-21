using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		attacker = gameObject.GetComponent<Attacker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;
		if (!obj.GetComponent<Defender> ()) {
			return;
		}

		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("JumpTrigger");
		} else {
			anim.SetBool("IsAttacking", true);
			attacker.Attack(obj);
		}

		Debug.Log ("Fox collided with " + collider);


	}
}
