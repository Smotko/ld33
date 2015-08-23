using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Hurt(int amount) {
		Debug.Log(health, gameObject);
		health -= amount;
		if (health < 0) {
			Destroy (gameObject);
		}
	}
}
