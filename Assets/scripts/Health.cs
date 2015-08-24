using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 100;
	public bool hasShield = false;
	private Attack attack;

	public GameObject end1;
	public GameObject end2;
	public GameObject end3;
	public GameObject end4;
	// Use this for initialization
	void Start () {
		if (hasShield) {
			attack = GetComponent<Attack>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Hurt(int amount) {

		if (hasShield && attack.isShielded()) {
			return;
		}

		health -= amount;
		if (health < 0) {
			if (gameObject.tag == "core"){
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				Attack a = player.GetComponent<Attack>();
				if (a.hasAttackedZergy) {
					// Condition 1

					end1.SetActive(true);
					//Application.LoadLevel (Application.loadedLevelName);
				} else {
					end2.SetActive(true);
//					Application.LoadLevel (Application.loadedLevelName);
				}
			} else if (gameObject.tag == "Player") {

				end3.SetActive(true);
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				return;
				//Application.LoadLevel (Application.loadedLevelName);
			}
			else if (gameObject.tag == "enemy") {
				bool allCleared = true;
				foreach(GameObject g in GameObject.FindGameObjectsWithTag("Respawn")){
					Spawner s = g.GetComponent<Spawner>();
					if (s.spawned != s.num) {
						allCleared = false;
					}
				}
				if (allCleared) {
					end4.SetActive(true);
				}
			}
			Destroy (gameObject);
		}
	}
}
