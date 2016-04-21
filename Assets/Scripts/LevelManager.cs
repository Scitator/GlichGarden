using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public float autoLoadNextLeveAfter;

	void Start () {
		if (autoLoadNextLeveAfter <= 0) {
			Debug.Log ("Level auto load disabled");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLeveAfter);
		}
	}

	public void LoadLevel (string levelName) {
		Application.LoadLevel (levelName);
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void QuitRequest () {
		Application.Quit ();
	}
}
