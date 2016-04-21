using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	private Button[] buttonArray;
	public GameObject defenderPrefab;

	public static GameObject selectedDefender;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		costText = GetComponentInChildren<Text> ();
		if (!costText) {
			Debug.LogWarning(name + " has no costText");
		}
		costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}


}
