using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private int hp = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Attack(int amount) {
		Debug.Log(gameObject + " getting hurt for " + amount);
	}
}
