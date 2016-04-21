using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;
	private Slider slider;
	private LevelManager levelManager;

	private GameObject winLabel;

	private bool isEndOfLevel = false;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		winLabel = GameObject.Find ("YouWin");
		if (!winLabel) {
			Debug.LogWarning("Create YouWin object");
		}
		winLabel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		isEndOfLevel = true;
		winLabel.SetActive (true);
		DestroqAllTaggedIbject();
		audioSource.Play ();
		Invoke ("LoadNextLevel", audioSource.clip.length);
	}

	void DestroqAllTaggedIbject() {
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("destroyOnWin");
		for (int i = gameObjects.Length; i > 0; i--) {
			Destroy(gameObjects[i]);
		}

	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
}
