﻿using UnityEngine;
using System.Collections;

public class HealthBars : MonoBehaviour {

	public GameObject bar;
	private GameObject[] bars = new GameObject[10];
	private float step;
	private Health g;

	// Use this for initialization
	void Start () {
		g = transform.parent.GetComponent<Health>();
		step = g.health/10f;
		for (int i = 0; i < 10; i++){
			Vector3 pos = new Vector3(transform.position.x+0.0625f*i, transform.position.y);
			GameObject b = Instantiate (bar, pos, Quaternion.identity) as GameObject;
			b.transform.parent = transform;
			bars[i] = b;
		}
	}
	
	// Update is called once per frame
	void Update () {

		for (int i =0; i < 10; i++) {
			SpriteRenderer sr = bars[i].GetComponent<SpriteRenderer>();
			sr.enabled = g.health / step > i;
		}
	}
}
