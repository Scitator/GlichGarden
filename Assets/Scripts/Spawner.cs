using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackerPrefabArray) {
			if (isTimeToSpawn(attacker)) {
				Spawn(attacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float spawnDelay = attacker.seenEverySeconds;
		float spawnPerSecond = 1 / spawnDelay;

		if (Time.deltaTime > spawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}

		float threshold = spawnPerSecond * Time.deltaTime/5f;

		return Random.value < threshold;
	}

	void Spawn(GameObject gameObject) {
		GameObject attacker = Instantiate (gameObject) as GameObject;
		attacker.transform.parent = transform;
		attacker.transform.position = transform.position;
	}
}
