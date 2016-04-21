using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera gameCamera;

	private GameObject parent;
	private StarDisplay starDisplay;
	
	void Start() {
		parent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		
		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Vector2 pos = SnapToGrid (CalculateWorldPointOfMouseClick());
		int defenderCost = Button.selectedDefender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			GameObject defender = Instantiate (Button.selectedDefender, pos, Quaternion.identity) as GameObject;
			defender.transform.parent = parent.transform;
		}
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 triplet = new Vector3(mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = gameCamera.ScreenToWorldPoint (triplet);

		return worldPos;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		return new Vector2 (Mathf.RoundToInt (rawWorldPos.x),
		                   Mathf.RoundToInt (rawWorldPos.y));
	}
}
