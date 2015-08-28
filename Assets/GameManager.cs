using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool playerAlive;
	public bool coreDestroyed;
	public bool gameActive;

	public GameObject end1;
	public GameObject end2;
	public GameObject end3;
	public GameObject end4;
	public GameObject start;
	public GameObject image;

	void Awake() {
		// Poor man's singleton
		if (instance == null) {
			instance = this;
		}
		playerAlive = true;
		coreDestroyed = false;
		gameActive = false;
	}

	void Update() {
		if (!gameActive && Input.anyKeyDown) {
			gameActive = true;
			image.SetActive(false);
			start.SetActive(false);
		}
	}

	public void ObjectDestroyed(GameObject gameObject) {
		if (gameObject.tag == "core") {
			CoreDestroyed();
			Destroy (gameObject);
		} else if (gameObject.tag == "Player") {
			PlayerKilled(gameObject);
		}
		else if (gameObject.tag == "enemy") {
			EnemyKilled();
			Destroy(gameObject);
		}

	}

	void CoreDestroyed() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Attack a = player.GetComponent<Attack>();
		image.SetActive(true);
		coreDestroyed = true;

		if (!a.hasAttackedZergy) {
			end2.SetActive(true);
		} else if (playerAlive) {
			end1.SetActive(true);
		} else {
			end3.SetActive(true);
		}

	}
	void PlayerKilled(GameObject player) {
		playerAlive = false;
		player.GetComponent<SpriteRenderer>().enabled = false;
	}

	void EnemyKilled() {
		bool allCleared = true;
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Respawn")){
			Spawner s = g.GetComponent<Spawner>();
			if (s.spawned != s.num) {
				allCleared = false;
			}
		}
		if (allCleared) {
			image.SetActive(true);
			end4.SetActive(true);
		}
	}
}
