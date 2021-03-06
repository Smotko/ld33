﻿using UnityEngine;
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
	public Light sun;

	private int DAY_LENGTH = 260;

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
		sun.intensity = ((DAY_LENGTH - Time.time) / DAY_LENGTH);
	}

	public void ObjectDestroyed(GameObject gameObject) {
		if (gameObject.tag == "core") {
			CoreDestroyed();
			Destroy (gameObject);
		} else if (gameObject.tag == "Player") {
			PlayerKilled(gameObject);
		}
		else if (gameObject.tag == "enemy") {
			EnemyKilled(gameObject);

		}

	}

	void CoreDestroyed() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Attack a = player.GetComponent<Attack>();
		image.SetActive(true);
		coreDestroyed = true;
		if (!playerAlive) {
			return;
		}
		if (!a.hasAttackedZergy) {
			end2.SetActive(true);
		} else {
			end1.SetActive(true);
		}

	}
	void PlayerKilled(GameObject player) {
		end3.SetActive(true);
		image.SetActive(true);
		playerAlive = false;
		player.GetComponent<SpriteRenderer>().enabled = false;
	}

	void EnemyKilled(GameObject enemey) {
		bool allCleared = true;
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Respawn")){
			Spawner s = g.GetComponent<Spawner>();
			if (s.spawned != s.num) {
				allCleared = false;
			}
		}
		Destroy(enemey);
		allCleared = allCleared && GameObject.FindGameObjectsWithTag("enemy").Length <= 1;
		if (allCleared) {
			image.SetActive(true);
			end4.SetActive(true);
		}
	}
}
