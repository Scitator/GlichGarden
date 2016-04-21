using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {
	
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
		anim.SetBool ("IsAttacking", true);
		attacker.Attack (obj);
		
	}
}
