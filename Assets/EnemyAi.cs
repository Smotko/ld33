using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

	private GameObject player;
	private Attack a;
	private GameObject core;
	private float lastAttack = 0;
	private float ATTACK_COOLDOWN = 1;

	// Use this for initialization
	void Start () {

		core = GameObject.FindGameObjectWithTag("core");
		player = GameObject.FindGameObjectWithTag("Player");
		a = player.GetComponent<Attack>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject target = core;
		if (a.hasAttackedZergy) {
			// Decide whether to attack the player or the core
			target = player;
		}

		float dist = Vector3.Distance(transform.position, target.transform.position);
		lastAttack -= Time.deltaTime;
		Debug.Log (dist);
		if (dist > 1f) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime);
		} else {
			if (lastAttack < 0) {
				target.SendMessage("Hurt", 10);
				lastAttack = ATTACK_COOLDOWN;
			}
		}

	}
}
