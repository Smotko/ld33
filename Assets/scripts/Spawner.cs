using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject monster;
	public int cooldown; // In seconds
	public float offset;
	public int num;
	public int spawned;

	private Transform parent;

	void Start () {
		parent = new GameObject("Monsters").transform;
		parent.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.gameActive || GameManager.instance.coreDestroyed){
			return;
		}
		offset -= Time.deltaTime;
		if (offset < 0 && spawned < num) {
			offset = cooldown;
			spawned += 1;
			Spawn();
		}
		
	}
	void Spawn() {
		GameObject m = Instantiate(monster, transform.position, Quaternion.identity) as GameObject;
		m.transform.parent = parent;
	}
}
