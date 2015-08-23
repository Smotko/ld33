using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject monster;
	public int cooldown; // In seconds
	public float offset;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		offset -= Time.deltaTime;
		if (offset < 0) {
			offset = cooldown;
			Spawn();
		}
		
	}
	void Spawn() {
		Instantiate(monster, transform.position, Quaternion.identity);
	}
}
